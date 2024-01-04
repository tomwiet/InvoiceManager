namespace InvoiceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FiXInvoiceCommentsField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "Comments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "Comments");
        }
    }
}
