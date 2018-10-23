namespace FrontEnd.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBookValue : DbMigration
    {
        private const string SCHEMA = "dbo";
        private const string TABLE_BOOKS = "Books";

        public override void Up()
        {
            AlterColumn($"{SCHEMA}.{TABLE_BOOKS}", "Title", c => c.String(nullable: false, maxLength: 10));
            AlterColumn($"{SCHEMA}.{TABLE_BOOKS}", "Author", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            
        }
    }
}
