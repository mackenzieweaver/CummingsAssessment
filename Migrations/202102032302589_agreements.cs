namespace CummingsAssessment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agreements : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agreements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdditionalInformation = c.String(maxLength: 1000),
                        BondTransfer_Id = c.Int(),
                        Defendant_Id = c.Int(),
                        Indemnitor_Id = c.Int(),
                        Jail_Id = c.Int(),
                        ProvidingAgency_Id = c.Int(),
                        RequestingAgency_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BondTransfers", t => t.BondTransfer_Id)
                .ForeignKey("dbo.Defendants", t => t.Defendant_Id)
                .ForeignKey("dbo.Indemnitors", t => t.Indemnitor_Id)
                .ForeignKey("dbo.Jails", t => t.Jail_Id)
                .ForeignKey("dbo.ProvidingAgencies", t => t.ProvidingAgency_Id)
                .ForeignKey("dbo.RequestingAgencies", t => t.RequestingAgency_Id)
                .Index(t => t.BondTransfer_Id)
                .Index(t => t.Defendant_Id)
                .Index(t => t.Indemnitor_Id)
                .Index(t => t.Jail_Id)
                .Index(t => t.ProvidingAgency_Id)
                .Index(t => t.RequestingAgency_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agreements", "RequestingAgency_Id", "dbo.RequestingAgencies");
            DropForeignKey("dbo.Agreements", "ProvidingAgency_Id", "dbo.ProvidingAgencies");
            DropForeignKey("dbo.Agreements", "Jail_Id", "dbo.Jails");
            DropForeignKey("dbo.Agreements", "Indemnitor_Id", "dbo.Indemnitors");
            DropForeignKey("dbo.Agreements", "Defendant_Id", "dbo.Defendants");
            DropForeignKey("dbo.Agreements", "BondTransfer_Id", "dbo.BondTransfers");
            DropIndex("dbo.Agreements", new[] { "RequestingAgency_Id" });
            DropIndex("dbo.Agreements", new[] { "ProvidingAgency_Id" });
            DropIndex("dbo.Agreements", new[] { "Jail_Id" });
            DropIndex("dbo.Agreements", new[] { "Indemnitor_Id" });
            DropIndex("dbo.Agreements", new[] { "Defendant_Id" });
            DropIndex("dbo.Agreements", new[] { "BondTransfer_Id" });
            DropTable("dbo.Agreements");
        }
    }
}
