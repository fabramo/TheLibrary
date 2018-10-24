namespace FrontEnd.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateAuthors : DbMigration
    {
        private const string SCHEMA = "dbo";
        private const string TABLE_AUTHORS = "Authors";

        public override void Up()
        {
            CreateTable(
               $"{SCHEMA}.{TABLE_AUTHORS}",
                c => new
                    {
                        ID = c.String(nullable: false),
                        Name = c.String(),
                        Gender = c.String(),
                        State = c.String(),
                        IsAlive = c.Boolean()
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable($"{SCHEMA}.{TABLE_AUTHORS}");
        }
    }
}
