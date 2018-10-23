namespace FrontEnd.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AuthorsAddColumnIsAlive : DbMigration
    {
        private const string SCHEMA = "dbo";
        private const string TABLE_AUTHORS = "Authors";

        public override void Up()
        {
            AddColumn($"{SCHEMA}.{TABLE_AUTHORS}", "IsAlive", c => c.Boolean(false, false));
        }
        
        public override void Down()
        {
            DropColumn($"{SCHEMA}.{TABLE_AUTHORS}", "IsAlive");
        }
    }
}
