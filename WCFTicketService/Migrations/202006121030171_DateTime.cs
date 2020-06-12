namespace WCFTicketService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "StartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Tickets", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
