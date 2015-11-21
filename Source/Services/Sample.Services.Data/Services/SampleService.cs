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
    using Sample.Data.Common.Contracts;
    using Sample.Data.Models.Models;
    using Server.DataTransferModels.Sample;

    public class SampleService : ISampleService
    {
        private readonly IRepository<Sample> samples;

        public SampleService(IRepository<Sample> samples)
        {
            this.samples = samples;
        }

        public IQueryable<Sample> GetAll()
        {
            return this.samples.All();
        }

        public async Task<Sample> GetById(int id)
        {
            var sample = await this.samples.All().SingleOrDefaultAsync(s => s.Id == id);

            return sample;
        }

        public async Task<int> Add(SampleDataTransferModel model)
        {
            var modelToAdd = Mapper.Map<Sample>(model);

            this.samples.Add(modelToAdd);

            await this.samples.SaveChangesAsync();

            return modelToAdd.Id;
        }

        public async Task<bool> Remove(Sample model)
        {
            this.samples.Delete(model);
            await this.samples.SaveChangesAsync();

            var modelExists = await this.samples.All().AnyAsync(s => s.Id == model.Id);

            return !modelExists;
        }

        public async Task<bool> RemoveById(int id)
        {
            this.samples.Delete(id);
            await this.samples.SaveChangesAsync();

            var modelExists = await this.samples.All().AnyAsync(s => s.Id == id);

            return !modelExists;
        }
    }
}