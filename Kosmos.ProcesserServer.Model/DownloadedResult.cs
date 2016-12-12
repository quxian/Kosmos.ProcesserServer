using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmos.ProcesserServer.Model
{
    public class DownloadedResult
    {
        /// <summary>
        /// 把下载结果的HashCode作为ID
        /// </summary>
        public string ResultHashCode { get; set; }
        /// <summary>
        /// 下载结果所属站点
        /// </summary>
        public string Domain { get; set; }
        /// <summary>
        /// 从该URL下载内容
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// URI对用的内容
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 该结果的深度
        /// </summary>
        public int Depth { get; set; }

        public override bool Equals(object obj)
        {
            if (null == obj)
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            var o = obj as DownloadedResult;
            return o?.ResultHashCode == ResultHashCode;
        }
        public override int GetHashCode()
        {
            return ResultHashCode.GetHashCode();
        }
    }
}
