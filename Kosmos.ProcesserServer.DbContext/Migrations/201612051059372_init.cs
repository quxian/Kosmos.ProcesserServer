namespace Kosmos.ProcesserServer.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DownloadedResults",
                c => new
                    {
                        ResultHashCode = c.String(nullable: false, maxLength: 32),
                        Domain = c.String(),
                        Url = c.String(),
                        Result = c.String(),
                        Depth = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultHashCode);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DownloadedResults");
        }
    }
}
