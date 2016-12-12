using Kosmos.ProcesserServer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmos.ProcesserServer.ModelDbMappings
{
    public class DownloadedResultMap : EntityTypeConfiguration<DownloadedResult>
    {
        public DownloadedResultMap()
        {
            this.HasKey(downloadedResult => downloadedResult.ResultHashCode);
            this.Property(downloadedResult => downloadedResult.ResultHashCode)
                .HasMaxLength(32);
        }
    }
}
