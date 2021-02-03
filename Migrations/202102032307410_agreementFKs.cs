namespace CummingsAssessment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agreementFKs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agreements", "BondTransfer_Id", "dbo.BondTransfers");
            DropForeignKey("dbo.Agreements", "Defendant_Id", "dbo.Defendants");
            DropForeignKey("dbo.Agreements", "Indemnitor_Id", "dbo.Indemnitors");
            DropForeignKey("dbo.Agreements", "Jail_Id", "dbo.Jails");
            DropForeignKey("dbo.Agreements", "ProvidingAgency_Id", "dbo.ProvidingAgencies");
            DropForeignKey("dbo.Agreements", "RequestingAgency_Id", "dbo.RequestingAgencies");
            DropIndex("dbo.Agreements", new[] { "BondTransfer_Id" });
            DropIndex("dbo.Agreements", new[] { "Defendant_Id" });
            DropIndex("dbo.Agreements", new[] { "Indemnitor_Id" });
            DropIndex("dbo.Agreements", new[] { "Jail_Id" });
            DropIndex("dbo.Agreements", new[] { "ProvidingAgency_Id" });
            DropIndex("dbo.Agreements", new[] { "RequestingAgency_Id" });
            RenameColumn(table: "dbo.Agreements", name: "BondTransfer_Id", newName: "BondTransferId");
            RenameColumn(table: "dbo.Agreements", name: "Defendant_Id", newName: "DefendantId");
            RenameColumn(table: "dbo.Agreements", name: "Indemnitor_Id", newName: "IndemnitorId");
            RenameColumn(table: "dbo.Agreements", name: "Jail_Id", newName: "JailId");
            RenameColumn(table: "dbo.Agreements", name: "ProvidingAgency_Id", newName: "ProvidingAgencyId");
            RenameColumn(table: "dbo.Agreements", name: "RequestingAgency_Id", newName: "RequestingAgencyId");
            AlterColumn("dbo.Agreements", "BondTransferId", c => c.Int(nullable: false));
            AlterColumn("dbo.Agreements", "DefendantId", c => c.Int(nullable: false));
            AlterColumn("dbo.Agreements", "IndemnitorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Agreements", "JailId", c => c.Int(nullable: false));
            AlterColumn("dbo.Agreements", "ProvidingAgencyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Agreements", "RequestingAgencyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Agreements", "ProvidingAgencyId");
            CreateIndex("dbo.Agreements", "JailId");
            CreateIndex("dbo.Agreements", "BondTransferId");
            CreateIndex("dbo.Agreements", "RequestingAgencyId");
            CreateIndex("dbo.Agreements", "DefendantId");
            CreateIndex("dbo.Agreements", "IndemnitorId");
            AddForeignKey("dbo.Agreements", "BondTransferId", "dbo.BondTransfers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Agreements", "DefendantId", "dbo.Defendants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Agreements", "IndemnitorId", "dbo.Indemnitors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Agreements", "JailId", "dbo.Jails", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Agreements", "ProvidingAgencyId", "dbo.ProvidingAgencies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Agreements", "RequestingAgencyId", "dbo.RequestingAgencies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agreements", "RequestingAgencyId", "dbo.RequestingAgencies");
            DropForeignKey("dbo.Agreements", "ProvidingAgencyId", "dbo.ProvidingAgencies");
            DropForeignKey("dbo.Agreements", "JailId", "dbo.Jails");
            DropForeignKey("dbo.Agreements", "IndemnitorId", "dbo.Indemnitors");
            DropForeignKey("dbo.Agreements", "DefendantId", "dbo.Defendants");
            DropForeignKey("dbo.Agreements", "BondTransferId", "dbo.BondTransfers");
            DropIndex("dbo.Agreements", new[] { "IndemnitorId" });
            DropIndex("dbo.Agreements", new[] { "DefendantId" });
            DropIndex("dbo.Agreements", new[] { "RequestingAgencyId" });
            DropIndex("dbo.Agreements", new[] { "BondTransferId" });
            DropIndex("dbo.Agreements", new[] { "JailId" });
            DropIndex("dbo.Agreements", new[] { "ProvidingAgencyId" });
            AlterColumn("dbo.Agreements", "RequestingAgencyId", c => c.Int());
            AlterColumn("dbo.Agreements", "ProvidingAgencyId", c => c.Int());
            AlterColumn("dbo.Agreements", "JailId", c => c.Int());
            AlterColumn("dbo.Agreements", "IndemnitorId", c => c.Int());
            AlterColumn("dbo.Agreements", "DefendantId", c => c.Int());
            AlterColumn("dbo.Agreements", "BondTransferId", c => c.Int());
            RenameColumn(table: "dbo.Agreements", name: "RequestingAgencyId", newName: "RequestingAgency_Id");
            RenameColumn(table: "dbo.Agreements", name: "ProvidingAgencyId", newName: "ProvidingAgency_Id");
            RenameColumn(table: "dbo.Agreements", name: "JailId", newName: "Jail_Id");
            RenameColumn(table: "dbo.Agreements", name: "IndemnitorId", newName: "Indemnitor_Id");
            RenameColumn(table: "dbo.Agreements", name: "DefendantId", newName: "Defendant_Id");
            RenameColumn(table: "dbo.Agreements", name: "BondTransferId", newName: "BondTransfer_Id");
            CreateIndex("dbo.Agreements", "RequestingAgency_Id");
            CreateIndex("dbo.Agreements", "ProvidingAgency_Id");
            CreateIndex("dbo.Agreements", "Jail_Id");
            CreateIndex("dbo.Agreements", "Indemnitor_Id");
            CreateIndex("dbo.Agreements", "Defendant_Id");
            CreateIndex("dbo.Agreements", "BondTransfer_Id");
            AddForeignKey("dbo.Agreements", "RequestingAgency_Id", "dbo.RequestingAgencies", "Id");
            AddForeignKey("dbo.Agreements", "ProvidingAgency_Id", "dbo.ProvidingAgencies", "Id");
            AddForeignKey("dbo.Agreements", "Jail_Id", "dbo.Jails", "Id");
            AddForeignKey("dbo.Agreements", "Indemnitor_Id", "dbo.Indemnitors", "Id");
            AddForeignKey("dbo.Agreements", "Defendant_Id", "dbo.Defendants", "Id");
            AddForeignKey("dbo.Agreements", "BondTransfer_Id", "dbo.BondTransfers", "Id");
        }
    }
}
