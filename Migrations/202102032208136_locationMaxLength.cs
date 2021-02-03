namespace CummingsAssessment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationMaxLength : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        City = c.String(maxLength: 100),
                        State = c.String(nullable: false, maxLength: 100),
                        Country = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Agencies", "City", c => c.String(maxLength: 100));
            AlterColumn("dbo.Agencies", "State", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Agencies", "Country", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Agencies", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.Agencies", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Agencies", "City", c => c.String());
            DropTable("dbo.Jails");
        }
    }
}
