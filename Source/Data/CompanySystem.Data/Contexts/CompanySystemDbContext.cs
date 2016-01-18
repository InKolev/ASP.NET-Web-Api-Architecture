namespace CompanySystem.Data.Contexts
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.Models;
    using Contracts;
    using System.Data.Entity;
    using System;

    public class CompanySystemDbContext : IdentityDbContext<User>, ICompanySystemDbContext
    {
        public CompanySystemDbContext()
            : base("CompanySystem", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public static CompanySystemDbContext Create()
        {
            return new CompanySystemDbContext();
        }
    }
}