namespace Sample.Server.API.Tests.ControllerTests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Controllers;
    using Factories;
    using DataTransferModels.Sample;
    using Data.Models.Models;
    using Services.Data.Contracts;
    using MyTested.WebApi;
    using System.Web.Http;
    using System.Threading.Tasks;
    using App_Start;
    using System.Reflection;
    using Common.Constants;
    using System.Web.Http.Results;
    using Infrastructure;

    [TestClass]
    public class SampleControllerTests
    {
        [TestInitialize]
        public void Initialize()
        {
            AutoMapperConfig.RegisterMappings(Assembly.Load(Assemblies.ServerDataTransferModels));
        }

        [TestMethod]
        public void SampleControllerGetActionShouldReturnAllSamples()
        {
            var service = TestObjectsFactory.SampleControllerObjects.GetSampleService();

            MyWebApi.Controller<SampleController>()
                .WithResolvedDependencyFor(service)
                .CallingAsync(x => x.Get())
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<SampleDataTransferModel>>()
                .Passing(x => x.Count == 3);
        }

        [TestMethod]
        public void SampleControllerGetByIdActionShouldReturnCorrectSampleWhenCalledWithExistingId()
        {
            var service = TestObjectsFactory.SampleControllerObjects.GetSampleService();

            MyWebApi.Controller<SampleController>()
                .WithResolvedDependencyFor(service)
                .CallingAsync(x => x.GetById(1))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<SampleDataTransferModel>()
                .Passing(x => x.Description == "Test Description 2");
        }

        [TestMethod]
        public void SampleControllerGetByIdActionShouldReturNullSampleWhenCalledWithNonExistantId()
        {
            var service = TestObjectsFactory.SampleControllerObjects.GetSampleService();

            MyWebApi.Controller<SampleController>()
                .WithResolvedDependencyFor(service)
                .CallingAsync(x => x.GetById(999))
                .ShouldReturn()
                .BadRequest();
        }

        [TestMethod]
        public void SampleControllerPostActionShouldReturnInvalidModelStateWhenCalledWithInvalidModel()
        {
            var service = TestObjectsFactory.SampleControllerObjects.GetSampleService();
            var model = TestObjectsFactory.SampleControllerObjects.GetInvalidSampleDataTransferModel();

            MyWebApi.Controller<SampleController>()
                .WithResolvedDependencyFor(service)
                .CallingAsync(x => x.Add(model))
                .ShouldHave()
                .InvalidModelState();
        }

        [TestMethod]
        public void SampleControllerPostActionShouldReturnValidModelStateWhenCalledWithValidModel()
        {
            var service = TestObjectsFactory.SampleControllerObjects.GetSampleService();
            var model = TestObjectsFactory.SampleControllerObjects.GetValidSampleDataTransferModel();

            MyWebApi.Controller<SampleController>()
                .WithResolvedDependencyFor(service)
                .CallingAsync(x => x.Add(model))
                .ShouldHave()
                .ValidModelState();
        }

        [TestMethod]
        public void SampleControllerPostActionShouldReturnOkNegotiatedContentResultWhenCalledWithInvalidModel()
        {
            var service = TestObjectsFactory.SampleControllerObjects.GetSampleService();
            var model = TestObjectsFactory.SampleControllerObjects.GetInvalidSampleDataTransferModel();

            MyWebApi.Controller<SampleController>()
                .WithResolvedDependencyFor(service)
                .CallingAsync(x => x.Add(model))
                .ShouldReturn()
                .ResultOfType<OkNegotiatedContentResult<int>>();
        }

        [TestMethod]
        public void SampleControllerPostActionShouldReturnOkWhenCalledWithValidModel()
        {
            var service = TestObjectsFactory.SampleControllerObjects.GetSampleService();
            var model = TestObjectsFactory.SampleControllerObjects.GetValidSampleDataTransferModel();

            MyWebApi
                .Controller<SampleController>()
                .WithResolvedDependencyFor(service)
                .CallingAsync(x => x.Add(model))
                .ShouldReturn()
                .Ok();
        }

        [TestMethod]
        public void SampleControllerRemoveActionShouldReturnOkNegotiatedContentResultWhenCalledWithInvalidModel()
        {
            var service = TestObjectsFactory.SampleControllerObjects.GetSampleService();
            var model = TestObjectsFactory.SampleControllerObjects.GetInvalidSampleDataTransferModel();

            MyWebApi
                .Controller<SampleController>()
                .WithResolvedDependencyFor(service)
                .CallingAsync(x => x.Remove(model))
                .ShouldReturn()
                .ResultOfType<OkNegotiatedContentResult<ResponseResultObject>>();
        }
    }
}