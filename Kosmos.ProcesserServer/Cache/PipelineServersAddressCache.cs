using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosmos.ProcesserServer
{
    public static class PipelineServersAddressCache
    {
        public static List<string> Urls { get; set; }
        static PipelineServersAddressCache()
        {
            Urls = new List<string>();
        }
    }
}