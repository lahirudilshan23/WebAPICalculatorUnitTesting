using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using Newtonsoft.Json;
using WebAPICalculatorUnitTesting.Models;

namespace WebAPICalculatorUnitTesting
{
    [TestFixture]
    public class Tests
    {
        private HttpClient client;
        private HttpResponseMessage response;
        private string apiKey = "07519e3c-3f2e-4d79-99ef-2b9851f976b0";

        [SetUp]
        public void SetUP()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7099/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            response = client.GetAsync("contacts/get").Result;

        }

        [Test]
        public void Addition()
        {
            double a = 5, b = 6, correctResult = 11;

            response = client.GetAsync("api/Calculator/Addition?a=" + a + "&b=" + b).Result;
            APIResponse aPIResponse = JsonConvert.DeserializeObject<APIResponse>(response.Content.ReadAsStringAsync().Result);
            double apiResult = Convert.ToDouble(aPIResponse.Response);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(correctResult, apiResult);
            Assert.IsNotNull(response);
            Assert.NotNull(response.Content);

        }

        [Test]
        public void Subtraction()
        {
            double a = 5, b = 6, correctResult = -1;

            response = client.GetAsync("api/Calculator/Subtraction?a=" + a + "&b=" + b).Result;
            APIResponse aPIResponse = JsonConvert.DeserializeObject<APIResponse>(response.Content.ReadAsStringAsync().Result);
            double apiResult = Convert.ToDouble(aPIResponse.Response);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(correctResult, apiResult);
            Assert.IsNotNull(response);
            Assert.NotNull(response.Content);

        }

        [Test]
        public void Multiplication()
        {
            double a = 5, b = 6, correctResult = 30;

            response = client.GetAsync("api/Calculator/Multiplication?a=" + a + "&b=" + b).Result;
            APIResponse aPIResponse = JsonConvert.DeserializeObject<APIResponse>(response.Content.ReadAsStringAsync().Result);
            double apiResult = Convert.ToDouble(aPIResponse.Response);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(correctResult, apiResult);
            Assert.IsNotNull(response);
            Assert.NotNull(response.Content);
        }

        [Test]
        public void Division()
        {
            double a = 12, b = 4, correctResult = 3;

            response = client.GetAsync("api/Calculator/Division?a=" + a + "&b=" + b).Result;
            APIResponse aPIResponse = JsonConvert.DeserializeObject<APIResponse>(response.Content.ReadAsStringAsync().Result);
            double apiResult = Convert.ToDouble(aPIResponse.Response);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(correctResult, apiResult);
            Assert.IsNotNull(response);
            Assert.NotNull(response.Content);
        }

        [Test]
        public void DivisionZero()
        {
            double a = 5, b = 0;

            response = client.GetAsync("api/Calculator/Division?a=" + a + "&b=" + b).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            Assert.NotNull(response.Content);
        }
    }
}