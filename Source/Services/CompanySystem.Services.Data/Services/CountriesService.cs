namespace CompanySystem.Services.Data.Services
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CompanySystem.Data.Models.Models;
    using CompanySystem.Data.Contracts;
    using System.Data.Entity;
    using Common.Constants;

    public class CountriesService : ICountriesService
    {
        private IRepository<Country> countries;

        public CountriesService(IRepository<Country> countries)
        {
            this.countries = countries;
        }

        public IQueryable<Country> All()
        {
            return this.countries.All();
        }

        public async Task<Country> GetByName(string name)
        {
            return await this.countries.All().SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task<int> Add(Country country)
        {
            this.countries.Add(country);
            await this.countries.SaveChangesAsync();

            var countryId = country.ID;

            return countryId != 0 ? countryId : ServicesConstants.DbModelInsertionFailed;
        }
    }
}