namespace FrontEnd.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<FrontEnd.Models.LibraryDBContext>
    {
        public Configuration()
        {
           AutomaticMigrationsEnabled = false;
           ContextKey = "FrontEnd.Models.LibraryDBContext";
        }

        protected override void Seed(FrontEnd.Models.LibraryDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
