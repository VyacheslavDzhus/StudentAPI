using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StudentAPI.Models;
using Xunit;

namespace StudentAPI.IntegrationTest
{
    public class StudentApiIntegrationTests
    {
        [Fact]
        public async Task Test_Get_All()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/students");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
        [Fact]
        public async Task Test_Get_Specific()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/students/1");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task Test_Post()
        {
           
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("/api/students"
                    ,new StringContent
                    (JsonConvert.SerializeObject(new Student() { Id = 122, Name = "Tom", LastName = "Vercetti" }), Encoding.UTF8,"application/json"));

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        [Fact]
        public async Task Test_Put()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PutAsync("/api/students"
                    , new StringContent
                        (JsonConvert.SerializeObject(new Student() { Id = 1, Name = "Tom", LastName = "Vercetti" }), Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task Test_Delete_Specific()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.DeleteAsync("/api/students/2");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

    }
}
