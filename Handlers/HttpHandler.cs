using DotNetTestProject.Context;
using RestSharp;
using TechTalk.SpecFlow;

namespace DotNetTestProject.Handlers
{
    [Binding]
    public class HttpHandler
    {
        private readonly TestRunContext _testRunContext;

        public HttpHandler(
            TestRunContext testRunContext)
        {
            _testRunContext = testRunContext;
        }

        public RestResponse GetResponseData(string countryCode, string postCode)
        {
            RestClient client = new RestClient(_testRunContext.Base_URL);
            RestRequest request = new RestRequest($"{countryCode}/{postCode}", Method.Get);
            RestResponse response = client.Execute(request);
            return response;
        }        
    }
}
