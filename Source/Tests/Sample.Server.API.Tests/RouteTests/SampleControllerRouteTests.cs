namespace Sample.Server.API.Tests.RouteTests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using System.Net.Http;
    using Controllers;
    using Factories;
    using System.Web.Http;

    [TestClass]
    public class SampleControllerRouteTests
    {
        [TestInitialize]
        public void Initialize()
        {
            WebApiConfig.Register(new HttpConfiguration());
        }

        [TestMethod]
        public void SampleControllerPostActionShouldMapCorrectly()
        {
            var model = TestObjectFactory.SampleControllerObjects.GetValidSampleDataTransferModel();

            MyWebApi
                .Routes(WebApiConfig.Configuration)
                .ShouldMap("api/Sample/Add")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{""Description"" : ""Valid data transfer model""}")
                .To<SampleController>(x => x.Add(model));
        }

        [TestMethod]
        public void SampleControllerRemoveActionShouldMapCorrectly()
        {
            var model = TestObjectFactory.SampleControllerObjects.GetValidSampleDataTransferModel();

            MyWebApi
                .Routes(WebApiConfig.Configuration)
                .ShouldMap("api/Sample/Remove")
                .WithHttpMethod(HttpMethod.Delete)
                .WithJsonContent(@"{""Description"" : ""Valid data transfer model""}")
                .To<SampleController>(x => x.Remove(model));
        }

        [TestMethod]
        public void SampleControllerRemoveByIdActionShouldMapCorrectly()
        {
            MyWebApi
                .Routes(WebApiConfig.Configuration)
                .ShouldMap("api/Sample/RemoveById/2")
                .WithHttpMethod(HttpMethod.Delete)
                .To<SampleController>(x => x.RemoveById(2));
        }
    }
}