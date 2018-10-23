namespace FrontEnd.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<FrontEnd.Models.BookDBContext>
    {
        public Configuration()
        {
           AutomaticMigrationsEnabled = false;
           ContextKey = "FrontEnd.Models.BookDBContext";
        }

        protected override void Seed(FrontEnd.Models.BookDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
