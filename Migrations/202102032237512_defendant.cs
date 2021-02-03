namespace CummingsAssessment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class defendant : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Defendants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(maxLength: 100),
                        DOB = c.DateTime(nullable: false),
                        SSN = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Defendants");
        }
    }
}
