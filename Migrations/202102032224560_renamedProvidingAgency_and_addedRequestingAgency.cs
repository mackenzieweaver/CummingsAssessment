namespace CummingsAssessment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamedProvidingAgency_and_addedRequestingAgency : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Agencies", newName: "ProvidingAgencies");
            CreateTable(
                "dbo.RequestingAgencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgencyName = c.String(nullable: false, maxLength: 100),
                        MobileNumber = c.String(nullable: false),
                        City = c.String(maxLength: 100),
                        State = c.String(nullable: false, maxLength: 100),
                        Country = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RequestingAgencies");
            RenameTable(name: "dbo.ProvidingAgencies", newName: "Agencies");
        }
    }
}
