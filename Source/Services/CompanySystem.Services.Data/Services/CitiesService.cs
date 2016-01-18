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

    public class CitiesService : ICitiesService
    {
        private IRepository<City> cities;

        public CitiesService(IRepository<City> cities)
        {
            this.cities = cities;
        }
        
        public IQueryable<City> All()
        {
            return this.cities.All();
        }

        public async Task<City> GetByName(string name)
        {
            return await this.cities.All().SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task<int> Add(City city)
        {
            this.cities.Add(city);
            await this.cities.SaveChangesAsync();

            var cityId = city.ID;

            return cityId != 0 ? cityId : ServicesConstants.DbModelInsertionFailed;
        }
    }
}