namespace Sample.Server.API.Tests.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data.Models.Models;
    using Moq;
    using Services.Data.Contracts;
    using DataTransferModels.Sample;
    using AutoMapper;
    using System.Net;

    public class SampleControllerTestObjectsFactory
    {
        private List<SampleDataTransferModel> samples = new List<SampleDataTransferModel>
        {
                new SampleDataTransferModel { Description = "Test Description 1" },
                new SampleDataTransferModel { Description = "Test Description 2" },
                new SampleDataTransferModel { Description = "Test Description 3" }
        };

        // Setup Sample Service Mocked object.
        public ISampleService GetSampleService()
        {
            var sampleService = new Mock<ISampleService>();

            sampleService.Setup(x => x.GetAll())
                .Returns(Task.FromResult(this.samples));

            sampleService.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    SampleDataTransferModel result = null;

                    if (id < 0 || id >= this.samples.Count)
                    {
                        return Task.FromResult(result);
                    }

                    result = this.samples[id];
                    return Task.FromResult(result);
                });

            sampleService.Setup(x => x.Add(It.IsAny<SampleDataTransferModel>()))
                .Returns((SampleDataTransferModel sample) =>
                {
                    samples.Add(sample);
                    return Task.FromResult(samples.Count);
                });

            sampleService.Setup(x => x.Remove(It.IsAny<SampleDataTransferModel>()))
                .Returns((SampleDataTransferModel model) =>
                {
                    var itemsBeforeRemoval = this.samples.Count;
                    var sampleToRemove = this.samples.FirstOrDefault(x => x.Description == model.Description);
                    this.samples.Remove(sampleToRemove);

                    var itemsAfterRemoval = this.samples.Count;
                    var result = itemsBeforeRemoval > itemsAfterRemoval ? true : false;

                    return Task.FromResult(result);
                });

            sampleService.Setup(x => x.RemoveById(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    if (id >= this.samples.Count && id < 0)
                    {
                        return Task.FromResult(false);
                    }

                    var itemsCountBeforeRemoval = this.samples.Count;

                    var sampleToRemove = this.samples[id];
                    this.samples.Remove(sampleToRemove);

                    var itemsCountAfterRemoval = this.samples.Count;

                    var result = itemsCountBeforeRemoval > itemsCountAfterRemoval ? true : false;

                    return Task.FromResult(result);
                });

            return sampleService.Object;
        }

        // Setup Sample Models
        public SampleDataTransferModel GetValidSampleDataTransferModel()
        {
            var model = new SampleDataTransferModel
            {
                Description = "Valid data transfer model"
            };

            return model;
        }

        public SampleDataTransferModel GetInvalidSampleDataTransferModel()
        {
            var model = new SampleDataTransferModel
            {
                Description = String.Empty
            };

            return model;
        }

        public SampleModel GetValidSampleModel()
        {
            var model = new SampleModel
            {
                Id = 999,
                Description = "Valid data transfer model"
            };

            return model;
        }

        public SampleModel GetInvalidSampleModel()
        {
            var model = new SampleModel
            {
                Id = 1,
                Description = String.Empty
            };

            return model;
        }
    }
}