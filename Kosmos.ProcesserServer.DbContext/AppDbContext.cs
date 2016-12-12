using Kosmos.ProcesserServer.Model;
using Kosmos.ProcesserServer.ModelDbMappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmos.ProcesserServer.DbContext
{
    public class AppDbContext : System.Data.Entity.DbContext
    {
        public AppDbContext() : base("ProcesserServerDbConnection") { }

        public DbSet<DownloadedResult> DownloadedResults { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DownloadedResultMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
