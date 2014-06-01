namespace ServiceHub.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rowversionfixed : DbMigration
    {
        public override void Up()
        {

            AddColumn("dbo.Credentials", "RowVersion", c => c.Binary());
            AddColumn("dbo.Service", "RowVersion", c => c.Binary());

            AddColumn("dbo.Machine", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));

        }
        
        public override void Down()
        {
            DropColumn("dbo.Service", "RowVersion");
            DropColumn("dbo.Credentials", "RowVersion");
            DropColumn("dbo.Machine", "RowVersion");
        }
    }
}
