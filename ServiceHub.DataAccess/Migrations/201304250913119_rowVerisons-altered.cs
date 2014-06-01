namespace ServiceHub.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rowVerisonsaltered : DbMigration
    {
        public override void Up()
        {
            //strange - changed the DB to compact, and caused the RV column to change (to maxLength 4000)
            //this changes it back to the SQL proper

            //the moral - avoid SQL Compact, it's different from SQL proper

            AlterColumn("dbo.Credentials", "RowVersion", c => c.Binary());
            AlterColumn("dbo.Service", "RowVersion", c => c.Binary());
        }
        
        public override void Down()
        {

            AlterColumn("dbo.Service", "RowVersion", c => c.Binary(maxLength: 4000));
            AlterColumn("dbo.Credentials", "RowVersion", c => c.Binary(maxLength: 4000));
        }
    }
}
