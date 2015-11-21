namespace Sample.Data.Contexts
{
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.Models;

    public class SampleDbContext : IdentityDbContext<User>, ISampleDbContext
    {
        // TODO: Rename SampleConnection to your desired connection string name.
        public SampleDbContext()
            : base("SampleConection", throwIfV1Schema: false)
        {
        }

        public static SampleDbContext Create()
        {
            return new SampleDbContext();
        }
    }
}