namespace Sample.Data.Contexts
{
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.Models;
    using System.Data.Entity;

    public class SampleDbContext : IdentityDbContext<User>, ISampleDbContext
    {
        // TODO: Rename connection string.
        public SampleDbContext()
            : base("SampleConection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<SampleModel> Samples { get; set; }

        public static SampleDbContext Create()
        {
            return new SampleDbContext();
        }
    }
}