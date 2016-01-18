namespace CompanySystem.Server.API.App_Start
{
    using System.Data.Entity;
    using Data.Contexts;
    using Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanySystemDbContext, Configuration>());
            CompanySystemDbContext.Create().Database.Initialize(true);
        }
    }
}