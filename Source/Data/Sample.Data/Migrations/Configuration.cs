namespace Sample.Data.Migrations
{
    using Contexts;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models.Models;

    public sealed class Configuration : DbMigrationsConfiguration<SampleDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // For development processes set to true. Set to false after deployment.
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SampleDbContext context)
        {
            var samplesExist = context.Samples.Any();

            if (!samplesExist)
            {
                var sampleData = new SampleModel[40];

                for (int i = 0; i < sampleData.Length; i++)
                {
                    sampleData[i] = new SampleModel();
                    sampleData[i].Description = String.Format("Sample description {0}", i);
                    context.Samples.Add(sampleData[i]);
                }

                context.SaveChanges();
            }
        }
    }
}