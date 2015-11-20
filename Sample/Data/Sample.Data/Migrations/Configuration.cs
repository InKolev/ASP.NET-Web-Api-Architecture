namespace Sample.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Sample.Data.Contexts.SampleDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // For development processes set to true. Set to false after deployment.
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Sample.Data.Contexts.SampleDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}