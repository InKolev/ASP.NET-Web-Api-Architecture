namespace Sample.Services.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using Contracts;
    using Sample.Data.Models.Models;
    using Server.DataTransferModels.Sample;
    using Sample.Data.Contracts;
    using AutoMapper.QueryableExtensions;

    public class SampleService : ISampleService
    {
        private readonly IRepository<SampleModel> samples;

        public SampleService(IRepository<SampleModel> samples)
        {
            this.samples = samples;
        }

        public IQueryable<SampleModel> All()
        {
            return this.samples.All();
        }

        public async Task<List<SampleDataTransferModel>> GetAll()
        {
            var result = await this.samples.All()
                .ProjectTo<SampleDataTransferModel>()
                .ToListAsync();

            return result;
        }

        public async Task<SampleDataTransferModel> GetById(int id)
        {
            var sample = await this.samples.All().SingleOrDefaultAsync(s => s.Id == id);
            var result = Mapper.Map<SampleDataTransferModel>(sample);

            return result;
        }

        public async Task<SampleDataTransferModel> GetById(string id)
        {
            int searchedId = -1;
            int.TryParse(id.Trim(), out searchedId);

            SampleDataTransferModel result = null;

            if (searchedId > -1)
            {
                var sample = await this.samples.All().SingleOrDefaultAsync(s => s.Id == searchedId);
                result = Mapper.Map<SampleDataTransferModel>(sample);
            }

            return result;
        }

        public async Task<List<SampleDataTransferModel>> GetPage(int page)
        {
            var itemsPerPage = 10;

            var result = await this.samples.All()
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ProjectTo<SampleDataTransferModel>()
                .ToListAsync();

            return result;
        }

        public async Task<int> Add(SampleDataTransferModel model)
        {
            var modelToAdd = Mapper.Map<SampleModel>(model);

            this.samples.Add(modelToAdd);
            await this.samples.SaveChangesAsync();

            return modelToAdd.Id;
        }

        public async Task<bool> Remove(SampleDataTransferModel model)
        {
            var sampleToDelete = await this.samples.All()
                .Where(s => s.Description == model.Description)
                .FirstOrDefaultAsync();

            var modelExistsInDatabase = false;
            var modelStillExists = false;

            if (sampleToDelete != null)
            {
                modelExistsInDatabase = true;
                this.samples.Delete(sampleToDelete);
                await this.samples.SaveChangesAsync();

                modelStillExists = await this.samples.All().AnyAsync(s => s.Id == sampleToDelete.Id);
            }

            return (!modelStillExists && modelExistsInDatabase);
        }

        public async Task<bool> RemoveById(int id)
        {
            var modelExists = await this.samples.All().AnyAsync(s => s.Id == id);

            if (modelExists)
            {
                this.samples.Delete(id);
                await this.samples.SaveChangesAsync();
            }

            var modelStillExists = await this.samples.All().AnyAsync(s => s.Id == id);

            return (!modelStillExists && modelExists);
        }

    }
}