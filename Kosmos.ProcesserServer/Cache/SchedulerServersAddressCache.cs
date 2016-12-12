using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosmos.ProcesserServer
{
    public static class SchedulerServersAddressCache
    {
        public static List<string> Urls { get; set; }
        static SchedulerServersAddressCache()
        {
            Urls = new List<string>();
        }
    }
}