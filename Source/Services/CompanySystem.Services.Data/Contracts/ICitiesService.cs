namespace CompanySystem.Services.Data.Contracts
{
    using Common.Contracts;
    using CompanySystem.Data.Models.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICitiesService : IService
    {
        IQueryable<City> All();

        Task<City> GetByName(string name);

        Task<int> Add(City city);
    }
}
