namespace Sample.Services.Data.Contracts
{
    using System.Linq;
    using System.Threading.Tasks;
    using Common.Contracts;
    using Sample.Data.Models.Models;
    using Server.DataTransferModels.Sample;
    using System.Collections.Generic;

    public interface ISampleService : IService
    {
        IQueryable<SampleModel> All();

        Task<List<SampleDataTransferModel>> GetAll();

        Task<SampleDataTransferModel> GetById(int id);

        Task<SampleDataTransferModel> GetById(string id);

        Task<List<SampleDataTransferModel>> GetPage(int page);

        Task<int> Add(SampleDataTransferModel model);

        Task<bool> Remove(SampleDataTransferModel model);

        Task<bool> RemoveById(int id);
    }
}