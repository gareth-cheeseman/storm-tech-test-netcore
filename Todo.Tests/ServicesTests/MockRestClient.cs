using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Moq;
using RestSharp;

namespace Todo.Tests.ServicesTests
{
    public class MockRestClient : Mock<IRestClient>
    {
        public Uri BaseUrl { get; set; }
        public string UserAgent { get; set; }

        public MockRestClient()
        {
            SetupProperty(m => m.BaseUrl);
            SetupProperty(m => m.UserAgent);
            BaseUrl = base.Object.BaseUrl;
            UserAgent = base.Object.UserAgent;
        }

        public MockRestClient ExecuteTaskAsync(IRestResponse output)
        {
            Setup(m => m.ExecuteTaskAsync(It.IsAny<RestRequest>())).ReturnsAsync(output);
            return this;
        }

        public MockRestClient ExecuteTaskAsyncSequence(IRestResponse firstOutput, IRestResponse secondOutput)
        {
            SetupSequence(m => m.ExecuteTaskAsync(It.IsAny<RestRequest>()))
                .ReturnsAsync(firstOutput)
                .ReturnsAsync(secondOutput);
            return this;
        }
    }
}