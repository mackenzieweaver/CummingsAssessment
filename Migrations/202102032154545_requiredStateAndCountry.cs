namespace CummingsAssessment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredStateAndCountry : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agencies", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Agencies", "Country", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Agencies", "Country", c => c.String());
            AlterColumn("dbo.Agencies", "State", c => c.String());
        }
    }
}
