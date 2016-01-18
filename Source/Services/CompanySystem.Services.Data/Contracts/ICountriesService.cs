namespace CompanySystem.Services.Data.Contracts
{
    using System.Linq;
    using System.Threading.Tasks;
    using CompanySystem.Data.Models.Models;
    using Common.Contracts;

    public interface ICountriesService : IService
    {
        IQueryable<Country> All();

        Task<Country> GetByName(string name);

        Task<int> Add(Country country);
    }
}