using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Moq;
using RestSharp;
using Shouldly;
using Todo.Services;
using Xunit;

namespace Todo.Tests.ServicesTests
{
    public class WhenGettingGravatarProfileApiDown
    {
        private MockRestClient mockRestClient;
        private Gravatar gravatar;
        private readonly IRestResponse responseBadRequest;
        private readonly RestResponse responseTimedOut;
        private readonly RestResponse responseSuccessful;


        public WhenGettingGravatarProfileApiDown()
        {
            responseBadRequest = new RestResponse {StatusCode = HttpStatusCode.BadRequest};
            responseTimedOut = new RestResponse {StatusCode = 0, ResponseStatus = ResponseStatus.TimedOut};
            responseSuccessful = new RestResponse
            {
                StatusCode = HttpStatusCode.OK,
                ResponseStatus = ResponseStatus.Completed,
                Content =
                    "{\"entry\":[{\"id\":\"129395703\",\"hash\":\"1234\",\"requestHash\":\"1234\",\"profileUrl\":\"http:\\/\\/gravatar.com\\/mockDisplayName\",\"preferredUsername\":\"mockDisplayName\",\"thumbnailUrl\":\"https:\\/\\/secure.gravatar.com\\/avatar\\/1234\",\"photos\":[{\"value\":\"https:\\/\\/secure.gravatar.com\\/avatar\\/1234\",\"type\":\"thumbnail\"}],\"name\":[],\"displayName\":\"mockDisplayName\",\"urls\":[]}]}"
            };
        }

        [Fact]
        public void WhenGravatarApiBadRequest()
        {
            mockRestClient = new MockRestClient().ExecuteTaskAsync(responseBadRequest);
            gravatar = new Gravatar(new GravatarUrl(), mockRestClient.Object);

            gravatar.GetGravatarName("1234").Result.ShouldBe("Gravatar unavailable");
        }

        [Fact]
        public void WhenGravatarApiTimeOut()
        {
            mockRestClient = new MockRestClient().ExecuteTaskAsync(responseTimedOut);
            gravatar = new Gravatar(new GravatarUrl(), mockRestClient.Object);

            gravatar.GetGravatarName("1234").Result.ShouldBe("Gravatar unavailable");
        }


        [Fact]
        public void WhenGravatarWorksSecondTime()
        {
            mockRestClient = new MockRestClient().ExecuteTaskAsyncSequence(responseBadRequest, responseSuccessful);
            gravatar = new Gravatar(new GravatarUrl(), mockRestClient.Object);

            gravatar.GetGravatarName("1234").Result.ShouldBe("mockDisplayName");
        }
    }
}
