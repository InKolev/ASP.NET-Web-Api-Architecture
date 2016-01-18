namespace CompanySystem.Data.Migrations
{
    using Contexts;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models.Models;

    public sealed class Configuration : DbMigrationsConfiguration<CompanySystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CompanySystemDbContext context)
        {
            // Seed initial data here
        }
    }
}