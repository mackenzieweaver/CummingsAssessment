namespace CummingsAssessment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgencyStrings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agencies", "City", c => c.String());
            AddColumn("dbo.Agencies", "State", c => c.String());
            AddColumn("dbo.Agencies", "Country", c => c.String());
            DropColumn("dbo.Agencies", "City_DataGroupField");
            DropColumn("dbo.Agencies", "City_DataTextField");
            DropColumn("dbo.Agencies", "City_DataValueField");
            DropColumn("dbo.Agencies", "State_DataGroupField");
            DropColumn("dbo.Agencies", "State_DataTextField");
            DropColumn("dbo.Agencies", "State_DataValueField");
            DropColumn("dbo.Agencies", "Country_DataGroupField");
            DropColumn("dbo.Agencies", "Country_DataTextField");
            DropColumn("dbo.Agencies", "Country_DataValueField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agencies", "Country_DataValueField", c => c.String());
            AddColumn("dbo.Agencies", "Country_DataTextField", c => c.String());
            AddColumn("dbo.Agencies", "Country_DataGroupField", c => c.String());
            AddColumn("dbo.Agencies", "State_DataValueField", c => c.String());
            AddColumn("dbo.Agencies", "State_DataTextField", c => c.String());
            AddColumn("dbo.Agencies", "State_DataGroupField", c => c.String());
            AddColumn("dbo.Agencies", "City_DataValueField", c => c.String());
            AddColumn("dbo.Agencies", "City_DataTextField", c => c.String());
            AddColumn("dbo.Agencies", "City_DataGroupField", c => c.String());
            DropColumn("dbo.Agencies", "Country");
            DropColumn("dbo.Agencies", "State");
            DropColumn("dbo.Agencies", "City");
        }
    }
}
