using RestSharp;

namespace CatFacts.Connections
{
    public class ApiConnections
    {
        public static RestClient BaseURL() => new RestClient("https://catfact.ninja");
    }
}
