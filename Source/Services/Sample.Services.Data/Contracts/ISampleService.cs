namespace Sample.Services.Data.Contracts
{
    using System.Linq;
    using System.Threading.Tasks;
    using Common.Contracts;
    using Sample.Data.Models.Models;
    using Server.DataTransferModels.Sample;

    public interface ISampleService : IService
    {
        IQueryable<SampleModel> GetAll();

        Task<SampleModel> GetById(int id);

        Task<int> Add(SampleDataTransferModel model);

        Task<bool> Remove(SampleModel model);

        Task<bool> RemoveById(int id);
    }
}