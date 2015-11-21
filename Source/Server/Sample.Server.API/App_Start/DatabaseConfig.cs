namespace Sample.Server.API.App_Start
{
    using System.Data.Entity;
    using Data.Contexts;
    using Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SampleDbContext, Configuration>());
            SampleDbContext.Create().Database.Initialize(true);
        }
    }
}