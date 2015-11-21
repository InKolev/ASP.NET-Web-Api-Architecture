namespace Sample.Services.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;
    using Sample.Data.Common.Contracts;
    using Sample.Data.Models.Models;

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

        public Sample GetById(int id)
        {
            var sample = this.samples.All().SingleOrDefault(s => s.Id == id);

            return sample;
        }

        public async Task<int> Add(Sample model)
        {
            this.samples.Add(model);
            await this.samples.SaveChangesAsync();

            return model.Id;
        }

        public async void Remove(Sample model)
        {
            this.samples.Delete(model);
            await this.samples.SaveChangesAsync();
        }

        public async void RemoveById(int id)
        {
            this.samples.Delete(id);
            await this.samples.SaveChangesAsync();
        }

        public async void Update(Sample model)
        {
            this.samples.Update(model);
            await this.samples.SaveChangesAsync();
        }
    }
}