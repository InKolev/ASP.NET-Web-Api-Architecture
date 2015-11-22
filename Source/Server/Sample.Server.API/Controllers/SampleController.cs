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
    using Infrastructure;
    using Common.Constants;
    using System.Web.Http.Cors;
    using AutoMapper.QueryableExtensions;

    // [Authorize] the whole controller or only some of his methods.
    // TODO: Try returning ResponseResultObject() for each method;
    // TODO: Consider optimizing Remove methods.
    [RoutePrefix("api/Sample")]
    public class SampleController : ApiController
    {
        private ISampleService samples;

        public SampleController(ISampleService samples)
        {
            this.samples = samples;
        }

        // When CORS is enabled with this parameter list,
        // Every external request can get access to this route.
        [HttpGet]
        [EnableCors("*", "*", "*")]
        [Route("Get")]
        public async Task<IHttpActionResult> Get()
        {
            var result = await this.samples.GetAll();

            return this.Ok(result);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var result = await this.samples.GetById(id);

            if(result == null)
            {
                return this.BadRequest();
            }

            return this.Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            var result = await this.samples.GetById(id);

            if (result == null)
            {
                return this.BadRequest();
            }

            return this.Ok(result);
        }

        [HttpGet]
        [Route("Get/{page}")]
        public async Task<IHttpActionResult> GetPage(int page)
        {
            var result = await this.samples.GetPage(page);

            return this.Ok(result);
        }

        [HttpPost]
        [ValidateRequestModel]
        [Route("Add")]
        public async Task<IHttpActionResult> Add(SampleDataTransferModel sample)
        {
            int result = await this.samples.Add(sample);

            return this.Ok(result);
        }

        [HttpDelete]
        [ValidateRequestModel]
        [Route("Remove")]
        public async Task<IHttpActionResult> Remove([FromBody] SampleDataTransferModel sample)
        {
            var result = await this.samples.Remove(sample);

            var responseMessage = ServerConstants.RemoveSuccessful;
            if (result != true)
            {
                responseMessage = ServerConstants.RemoveFailed;
            }

            return this.Ok(new ResponseResultObject(result, responseMessage, result));
        }

        [HttpDelete]
        [Route("RemoveById/{id}")]
        public async Task<IHttpActionResult> RemoveById(int id)
        {
            var result = await this.samples.RemoveById(id);

            var responseMessage = ServerConstants.RemoveSuccessful;
            if (result != true)
            {
                responseMessage = ServerConstants.RemoveFailed;
            }

            return this.Ok(new ResponseResultObject(result, responseMessage, result));
        }
    }
}