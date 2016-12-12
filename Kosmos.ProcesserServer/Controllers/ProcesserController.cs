using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kosmos.ProcesserServer.Controllers
{
    public class ProcesserController : ApiController
    {
        [HttpGet]
        [Route("api/Processer/AddSchedulerServerAddress")]
        public async Task<IHttpActionResult> AddSchedulerServerAddress(string address)
        {
            if (SchedulerServersAddressCache.Urls?.IndexOf(address) >= 0)
                return Ok();
            SchedulerServersAddressCache.Urls.Add(address);
            return Ok();
        }

        [HttpGet]
        [Route("api/Processer/AddSchedulerServerAddress/List")]
        public async Task<IHttpActionResult> ListSchedulerServerAddress()
        {
            return Ok(SchedulerServersAddressCache.Urls);
        }

        [HttpGet]
        [Route("api/Processer/AddSchedulerServerAddress/Delete")]
        public async Task<IHttpActionResult> DeleteSchedulerServerAddress(string address)
        {
            SchedulerServersAddressCache.Urls.Remove(address);
            return Ok(address);
        }

        [HttpPost]
        [Route("api/Processer/AddSchedulerServerAddress")]
        public async Task<IHttpActionResult> AddSchedulerServerAddress(List<string> address)
        {
            var newAddress = address.Except(SchedulerServersAddressCache.Urls);
            SchedulerServersAddressCache.Urls.AddRange(newAddress);
            return Ok();
        }


        [HttpGet]
        [Route("api/Processer/AddPipelineServerAddress")]
        public async Task<IHttpActionResult> AddPipelineServerAddress(string address)
        {
            if (PipelineServersAddressCache.Urls.IndexOf(address) >= 0)
                return Ok();
            PipelineServersAddressCache.Urls.Add(address);
            return Ok();
        }

        [HttpGet]
        [Route("api/Processer/AddPipelineServerAddress/List")]
        public async Task<IHttpActionResult> ListPipelineServerAddress()
        {
            return Ok(PipelineServersAddressCache.Urls);
        }

        [HttpGet]
        [Route("api/Processer/AddPipelineServerAddress/Delete")]
        public async Task<IHttpActionResult> DeletePipelineServerAddress(string address)
        {
            PipelineServersAddressCache.Urls.Remove(address);
            return Ok(address);
        }

        [HttpPost]
        [Route("api/Processer/AddPipelineServerAddress")]
        public async Task<IHttpActionResult> AddPipelineServerAddress(List<string> address)
        {
            var newAddress = address.Except(PipelineServersAddressCache.Urls);
            PipelineServersAddressCache.Urls.AddRange(newAddress);
            return Ok();
        }
    }
}
