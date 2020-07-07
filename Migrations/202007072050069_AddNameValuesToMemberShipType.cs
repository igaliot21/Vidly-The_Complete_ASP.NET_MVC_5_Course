namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameValuesToMemberShipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MenbershipTypes SET Name = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MenbershipTypes SET Name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MenbershipTypes SET Name = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MenbershipTypes SET Name = 'Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
 