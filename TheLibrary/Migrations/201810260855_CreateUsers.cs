namespace FrontEnd.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateUsers : DbMigration
    {
        private const string SCHEMA = "dbo";
        private const string TABLE_USERS = "Users";

        public override void Up()
        {
            CreateTable(
                $"{SCHEMA}.{TABLE_USERS}",
                 c => new
                 {
                     Email = c.String(nullable: false),
                     Name = c.String(nullable: false),
                     Surname = c.String(nullable: false),
                     DateOfBirth = c.DateTime(nullable: false),
                     Password = c.String(nullable: false)
                 })
                .PrimaryKey(t => t.Email);
        }
        
        public override void Down()
        {
              DropTable($"{SCHEMA}.{TABLE_USERS}");
        }
    }
}
