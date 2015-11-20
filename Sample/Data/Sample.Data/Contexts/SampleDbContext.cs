namespace Sample.Data.Contexts
{
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.Models;

    public class SampleDbContext : IdentityDbContext<User>, ISampleDbContext
    {
        public SampleDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static SampleDbContext Create()
        {
            return new SampleDbContext();
        }
    }
}