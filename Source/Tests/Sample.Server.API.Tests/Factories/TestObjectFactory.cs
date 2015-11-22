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

    public class TestObjectsFactory
    {
        public static SampleControllerTestObjectsFactory SampleControllerObjects { get; set; } = new SampleControllerTestObjectsFactory();
    }
}