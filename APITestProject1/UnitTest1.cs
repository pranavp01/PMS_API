using NUnit.Framework;
using System;
using System.Net.Http;
using PMS_API.Model;
using PMS_API.Services;
using PMS_Business.Interfaces ;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using PMS_Repository.Interfaces;
using PMS_Repository.Implementations;
using PMS_Repository.Dtos;
using System.Collections.Generic;

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
        private IUserRepository userRepository;

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient { BaseAddress = new Uri(ServiceUrl) };
            userRepository = new UserRepository();
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
            var response = _client.PostAsJsonAsync("api/user/login", authenticateModel).Result;
            var res = response.Content.ReadAsStringAsync().Result;
            UserApiModel userApiModel = JsonConvert.DeserializeObject<UserApiModel>(res);
            Token = userApiModel.Token;
        }


        [Test]
        public  void TetUserRepository()
        {
            var user=  userRepository.GetUsers();
            Assert.IsNotNull(user);
            Assert.That(user, Is.InstanceOf<Task<IEnumerable<User>>>());  
        }

     

    }
}