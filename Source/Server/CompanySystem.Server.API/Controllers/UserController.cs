namespace CompanySystem.Server.API.Controllers
{
    using AutoMapper.QueryableExtensions;
    using DataTransferModels.Users;
    using Infrastructure.Validation;
    using Services.Data.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Cors;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private IUsersService users;

        public UserController(IUsersService users)
        {
            this.users = users;
        }

        [HttpGet]
        [Route("GetUserData")]
        //[ValidateRequestModel]
        public async Task<IHttpActionResult> GetUserData([FromUri]UserBriefDataTransferModel model)
        {
            var userData = await this.users.All()
                .Where(x => x.UserName == model.UserName)
                .ProjectTo<UserDetailedDataTransferModel>()
                .SingleOrDefaultAsync();

            return this.Ok(userData);
        }
    }
}