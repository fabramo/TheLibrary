namespace FrontEnd.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateBookAuthors : DbMigration
    {
        private const string SCHEMA = "dbo";
        private const string TABLE_BOOK_AUTHORS = "BookAuthors";
        private const string TABLE_BOOKS = "Books";
        private const string TABLE_AUTHORS = "Authors";

        public override void Up()
        {
            CreateTable(
                $"{SCHEMA}.{TABLE_BOOK_AUTHORS}",
                 c => new
                 {
                     ID = c.String(nullable: false),
                     BookId = c.String(nullable: false),
                     AuthorId = c.String(nullable: false)
                 })
                .PrimaryKey(t => t.ID)
                .ForeignKey($"{SCHEMA}.{TABLE_BOOKS}", t => t.BookId)
                .ForeignKey($"{SCHEMA}.{TABLE_AUTHORS}", t => t.AuthorId);

            AddForeignKey("dbo.BookAuthors", "AuthorId", "dbo.Authors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey($"{SCHEMA}.{TABLE_BOOK_AUTHORS}", "BookId", $"{SCHEMA}.{TABLE_BOOKS}");
            DropForeignKey($"{SCHEMA}.{TABLE_BOOK_AUTHORS}", "AuthorId", $"{SCHEMA}.{TABLE_AUTHORS}");

            DropTable($"{SCHEMA}.{TABLE_BOOK_AUTHORS}");
        }
    }
}
