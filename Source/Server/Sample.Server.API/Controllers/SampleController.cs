namespace Sample.Server.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Services.Data.Contracts;
    using DataTransferModels.Sample;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using Infrastructure.Validation;
    using Data.Models.Models;
    using AutoMapper;

    // [Authorize] the whole controller or only some of his methods.
    // TODO: Try returning ResponseResultObject() for each method;
    // TODO: Consider optimizing Remove methods.
    public class SampleController : ApiController
    {
        private ISampleService samples;

        public SampleController(ISampleService samples)
        {
            this.samples = samples;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var result = await this.samples.GetAll()
                .Select(s => Mapper.Map<SampleDataTransferModel>(s))
                .ToListAsync();

            return this.Ok(result);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var sample = await this.samples.GetById(id);
            var result = Mapper.Map<SampleDataTransferModel>(sample);

            return this.Ok(result);
        }

        [HttpPost]
        [ValidateRequestModel]
        public async Task<IHttpActionResult> Post(SampleDataTransferModel sample)
        {
            int result = await this.samples.Add(sample);

            return this.Ok(result);
        }
    
        [HttpPost]
        [ValidateRequestModel]
        public async Task<IHttpActionResult> Remove(SampleDataTransferModel sample)
        {
            var sampleToRemove = Mapper.Map<SampleModel>(sample);
            var result = await this.samples.Remove(sampleToRemove);

            return this.Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> RemoveById(int id)
        {
            var result = await this.samples.RemoveById(id);

            return this.Ok(result);
        }
    }
}