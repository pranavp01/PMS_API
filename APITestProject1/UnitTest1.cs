using NUnit.Framework;
using System;
using System.Net.Http;
using PMS_API.Model;
using PMS_API.Services;
using PMS_Business.Interfaces ;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using PMS_Models;
using System.Text.Json;
using Newtonsoft.Json;
//using System.Net.Http.Formatting.dll;

namespace APITestProject1
{
    public class Tests
    {
        private UserService userService1;
        private HttpClient _client;
        private readonly IUserBusiness userBusiness;
        private string ServiceUrl = "https://localhost:5001";
        private IOptions<AppSettings> appSettings;
        private string Token = "";

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient { BaseAddress = new Uri(ServiceUrl) };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Test]
        public void Test1()
        {
            HttpResponseMessage response = _client.GetAsync("api/user/getallusers").Result;
            Assert.IsNotNull(response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(200,(int)response.StatusCode);
        }


        [Test]
        public void AuthenticationTest()
        {
            GetToken();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",Token);
            HttpResponseMessage response = _client.GetAsync("api/Patient").Result;
            Assert.AreEqual(200, (int)response.StatusCode);
        }

        public void GetToken()
        {
            
            AuthenticateModel authenticateModel = new AuthenticateModel()
            {
                Password = "buttabommamachi",
                Username = "pranav.peddi@citiustech.com"
            };
            var response = _client.PostAsJsonAsync("api/user", authenticateModel).Result;
            var res = response.Content.ReadAsStringAsync().Result;
            var jsonSeriaziaer = new JsonSerializer();
            UserApiModel userApiModel = (UserApiModel)JsonConvert.DeserializeObject(res);
            Token= userApiModel.Token;
        }

    }
}