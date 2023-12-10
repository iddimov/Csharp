using CatFacts.Connections;
using RestSharp;

namespace CatFacts.Helpers.Get
{
    public static class ApiHelper
    {
        readonly static RestClient _baseURL = ApiConnections.BaseURL();

        public static RestResponse GetCatFacts()
        {
            var request = new RestRequest("/facts", Method.Get);
            RestResponse response = _baseURL.Execute(request);
            return response;
        }
    }
}
