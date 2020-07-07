namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemberShipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenbershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SingUpFee = c.Int(nullable: false),
                        DurationInMonths = c.Int(nullable: false),
                        DiscountRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MenbershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MenbershipTypeId");
            AddForeignKey("dbo.Customers", "MenbershipTypeId", "dbo.MenbershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MenbershipTypeId", "dbo.MenbershipTypes");
            DropIndex("dbo.Customers", new[] { "MenbershipTypeId" });
            DropColumn("dbo.Customers", "MenbershipTypeId");
            DropTable("dbo.MenbershipTypes");
        }
    }
}
