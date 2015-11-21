namespace Sample.Services.Data.Contracts
{
    using System.Linq;
    using Common.Contracts;
    using Sample.Data.Models.Models;
    using System.Threading.Tasks;

    public interface ISampleService : IService
    {
        IQueryable<Sample> GetAll();

        Sample GetById(int id);

        Task<int> Add(Sample model);

        void Remove(Sample model);

        void RemoveById(int id);

        void Update(Sample model);
    }
}