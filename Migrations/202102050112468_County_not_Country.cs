namespace CummingsAssessment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class County_not_Country : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jails", "County", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.ProvidingAgencies", "County", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.RequestingAgencies", "County", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Jails", "Country");
            DropColumn("dbo.ProvidingAgencies", "Country");
            DropColumn("dbo.RequestingAgencies", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RequestingAgencies", "Country", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.ProvidingAgencies", "Country", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Jails", "Country", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.RequestingAgencies", "County");
            DropColumn("dbo.ProvidingAgencies", "County");
            DropColumn("dbo.Jails", "County");
        }
    }
}
