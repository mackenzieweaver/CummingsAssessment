namespace CummingsAssessment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class indemnitors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Indemnitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        Middle = c.String(),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Alias = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        Ethnicity = c.String(nullable: false),
                        SSN = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        MobileNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Indemnitors");
        }
    }
}
