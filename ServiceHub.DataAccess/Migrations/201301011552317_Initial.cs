namespace ServiceHub.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Machine",
                c => new
                    {
                        MachineId = c.Int(nullable: false, identity: true),
                        FriendlyName = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 20),
                        CredentialsId = c.Int(),
                    })
                .PrimaryKey(t => t.MachineId)
                .ForeignKey("dbo.Credentials", t => t.CredentialsId)
                .Index(t => t.CredentialsId)
                .Index(t => t.Name,true);
            
            CreateTable(
                "dbo.Credentials",
                c => new
                    {
                        CredentialsId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CredentialsId);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        FriendlyName = c.String(nullable: false, maxLength: 50),
                        ServiceName = c.String(nullable: false, maxLength: 250),
                        ExecutableName = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ServiceId);
            
            CreateTable(
                "dbo.MachineService",
                c => new
                    {
                        MachineServiceId = c.Int(nullable: false, identity: true),
                        MachineId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MachineServiceId)
                .ForeignKey("dbo.Machine", t => t.MachineId, cascadeDelete: true)
                .ForeignKey("dbo.Service", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.MachineId)
                .Index(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.MachineService", new[] { "ServiceId" });
            DropIndex("dbo.MachineService", new[] { "MachineId" });
            DropIndex("dbo.Machine", new[] { "CredentialsId" });
            DropForeignKey("dbo.MachineService", "ServiceId", "dbo.Service");
            DropForeignKey("dbo.MachineService", "MachineId", "dbo.Machine");
            DropForeignKey("dbo.Machine", "CredentialsId", "dbo.Credentials");
            DropTable("dbo.MachineService");
            DropTable("dbo.Service");
            DropTable("dbo.Credentials");
            DropTable("dbo.Machine");
        }
    }
}
