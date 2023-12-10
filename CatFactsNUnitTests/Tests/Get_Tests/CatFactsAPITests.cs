using CatFacts.Helpers.Get;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace CatFacts.Tests.Get_Tests
{
    [TestFixture]
    public class Tests
    {
        readonly RestResponse response = ApiHelper.GetCatFacts();

        private JObject GetJsonData => JObject.Parse(response.Content);

        private string GetResponseUri => $"API endpoint: {response.ResponseUri}\n";

        [SetUp]
        public void Setup()
        {
        }

        //1. Test functionality - 200, OK, body contains expected data, response format (JSON, XML)
        [Test]
        public void VerifyCatFacts_StatusOK()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"{GetResponseUri} Expected Status Code: OK");
        }

        [Test]
        public void VerifyCatFacts_NotNull()
        {
            string? jsonResponse = GetJsonData["data"]?[0]?["fact"]?.ToString();
            Assert.That(!string.IsNullOrEmpty(jsonResponse), Is.True, $"{GetResponseUri} Cat fact is empty or null");
        }

        //2. Test Error handling - non existent resource (404), invalid query param (400), unauthorised (401), invalid auth - forbidden (403)
        //3. Edge cases - extereme values as parameters
        //4. Verify Multiple time requests returns the same result
        //5. Headers and Content Negotiation - responds correctly to different headers (JSON,XML, 'Content-Type'...)
        //6. Test Pagination (if applicable)
        //7. Sorting & filtering (if applicable)
        //8. Caching - verify caching headers (if applicable)
        //9. Performance - get large dataset (if applicable)
        //10. Concurrency - behavior on multiple requests in the same time and verify data consistency 
        //11. Security - no sensitive info exposed, SQL injection, Cross-Origin Resource Sharing (CORS)...
        //12. Rate limiting - behavior when the rate limit is exceeded (if applicable)



        [TearDown]
        public void Cleanup()
        {
            // Cleanup steps if needed
        }
    }
}