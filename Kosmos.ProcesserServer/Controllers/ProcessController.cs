using HtmlAgilityPack;
using Kosmos.ProcesserServer.DbContext;
using Kosmos.ProcesserServer.Model;
using Kosmos.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kosmos.ProcesserServer.Controllers
{
    public class ProcessController : ApiController
    {
        private readonly AppDbContext _dbContext;
        private readonly HttpClient _httpClient;

        public ProcessController(AppDbContext dbContext, HttpClient httpClient)
        {
            _dbContext = dbContext;
            _httpClient = httpClient;
        }


        public async Task<IHttpActionResult> Post(DownloadedResult downloadedResult)
        {
            //取消数据库保存行为
            //if (null == await _dbContext.DownloadedResults?.FindAsync(downloadedResult.ResultHashCode))
            //{
            //    _dbContext.DownloadedResults.Add(downloadedResult);
            //    await _dbContext.SaveChangesAsync();
            //}

            var pipelineTasks = Task.Run(() => PipelineServersAddressCache.Urls
                                    .AsParallel()
                                    .ForAll(async url =>
                                    {
                                        try
                                        {
                                            await _httpClient.PostAsJsonAsync($"{url}api/Extract", downloadedResult);
                                        }
                                        catch (Exception e)
                                        {
                                            SingleHttpClient.PostException(e);
                                        }
                                    }));

            var task = Task.Run(async () =>
            {
                await ExtractUrl(downloadedResult);
            });

            return Ok();
        }

        private async Task ExtractUrl(DownloadedResult downloadedResult)
        {
            try
            {
                var doc = new HtmlDocument();
                doc.LoadHtml(downloadedResult.Result);

                var urls = doc?.DocumentNode
                    .SelectNodes("//a[@href]")
                    .AsParallel()
                    .Select(link => link?.Attributes["href"]?.Value)
                    .Where(url => null != url && !url.Contains("javascript") && url.IndexOf("http") < 1)
                    .Select(url =>
                    {
                        var value = url;
                        if (url.IndexOf("http") != 0)
                        {
                            value = new Uri(new Uri(downloadedResult.Url), url).ToString();
                        }
                        var index = value.IndexOf("#");
                        if(index > -1)
                        {
                            value = value.Substring(0, index);
                        }
                        return new
                        {
                            Value = value,
                            Depth = downloadedResult.Depth + 1,
                            Domain = downloadedResult.Domain,
                            Parent = downloadedResult.Url
                        };
                    })
                    .ToList();

                await Task.Run(async () =>
                {
                    try
                    {
                        await _httpClient.PostAsJsonAsync($"{SchedulerServersAddressCache.Urls.First()}api/Url", urls);
                    }
                    catch (Exception e)
                    {
                        SingleHttpClient.PostException(e);
                    }
                });
            }
            catch (Exception e)
            {
                SingleHttpClient.PostException(e);
            }
        }
    }
}
