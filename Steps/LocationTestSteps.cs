using DotNetTestProject.Handlers;
using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;
using static DotNetTestProject.Models.LocationProperties;

namespace DotNetTestProject.Steps
{
    [Binding]
    public class LocationTestSteps
    {
        private readonly HttpHandler _httpHandler;
        private RestResponse _response;


        public LocationTestSteps(HttpHandler httpHandler)
        {
            _httpHandler = httpHandler;
        }

        [When(@"I request for a (.*) and a (.*)")]
        public void WhenIRequestForACountryPostalArea(string countryCode, string postCode)
        {   
            _response = _httpHandler.GetResponseData(countryCode, postCode);
        }

        [Then(@"I get a response (.*) back from the server")]
        public void ThenIGetAResponseBackFromTheServer(HttpStatusCode httpStatusCode)
        {
            _response.StatusCode.Should().Be(httpStatusCode, $"The reponse should have returned {httpStatusCode} successfully.");
        }

        [Then(@"I get a city (.*) content back from the server")]
        public void ThenIGetACityContentBackFromTheServer(string city)
        {
            //temporarly using newtonsoft deserializer as restsharp is returning null for some of the attributes
            var rootLocation = JsonConvert.DeserializeObject<RootLocation>(_response.Content);
            rootLocation.places[0].placeName.ToLowerInvariant().Should().Be(city.ToLowerInvariant(), $"The reponse should have returned {city} successfully.");
        }
    }
}
