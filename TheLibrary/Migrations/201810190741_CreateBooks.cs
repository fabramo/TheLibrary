namespace FrontEnd.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateBooks : DbMigration
    {
        private const string SCHEMA = "dbo";
        private const string TABLE_BOOKS = "Books";

        public override void Up()
        {
            CreateTable(
                $"{SCHEMA}.{TABLE_BOOKS}",
                c => new
                    {
                        ID = c.String(nullable: false),
                        Title = c.String(),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable($"{SCHEMA}.{TABLE_BOOKS}");
        }
    }
}
