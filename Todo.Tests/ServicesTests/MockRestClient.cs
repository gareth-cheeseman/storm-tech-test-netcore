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
        public Uri BaseUrl
        {
            get => base.Object.BaseUrl;
            set => base.Object.BaseUrl = value;
        }

        public string UserAgent
        {
            get => base.Object.UserAgent;
            set => base.Object.UserAgent = value;
        }

        public int Timeout
        {
            get => base.Object.Timeout;
            set => base.Object.Timeout = value;
        }

        public MockRestClient()
        {
            SetupProperty(m => m.BaseUrl);
            SetupProperty(m => m.UserAgent);
            SetupProperty(m => m.Timeout);
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