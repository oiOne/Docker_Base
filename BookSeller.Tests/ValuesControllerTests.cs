using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace BookSeller.Tests
{
    public class ValuesControllerTests
    {
        /*
         *
         * docker-compose -f docker-compose-bookseller-test.yml -f docker-compose-bookseller-test.override.yml up
         */
        [Fact]
        public void Check_Tests_Availability()
        {
            var actual = 22;
            var expected = 22;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Test_2()
        {
            var client = new HttpClient();

            using (var response = await client.GetAsync("http://bookseller-api/api/values"))
            {
                Assert.True(response.IsSuccessStatusCode);

                var respString = await response.Content.ReadAsStringAsync();
                var respModel = JsonConvert.DeserializeObject<string[]>(respString);

                Assert.NotNull(respModel);
                Assert.NotEmpty(respModel);
            }

            using (var response = await client.GetAsync("http://bookwriter-api/api/values"))
            {
                Assert.True(response.IsSuccessStatusCode);

                var respString = await response.Content.ReadAsStringAsync();
                var respModel = JsonConvert.DeserializeObject<string[]>(respString);

                Assert.NotNull(respModel);
                Assert.NotEmpty(respModel);
            }
        }

        [Fact]
        public async Task Test_3()
        {
            var client = new HttpClient();
            string[] respModel_Seller;
            string[] respModel_Writer;
            using (var response = await client.GetAsync("http://bookseller-api/api/values"))
            {
                Assert.True(response.IsSuccessStatusCode);

                var respString = await response.Content.ReadAsStringAsync();
                respModel_Seller = JsonConvert.DeserializeObject<string[]>(respString);

                Assert.NotNull(respModel_Seller);
                Assert.NotEmpty(respModel_Seller);
            }

            using (var response = await client.GetAsync("http://bookwriter-api/api/values"))
            {
                Assert.True(response.IsSuccessStatusCode);

                var respString = await response.Content.ReadAsStringAsync();
                respModel_Writer = JsonConvert.DeserializeObject<string[]>(respString);

                Assert.NotNull(respModel_Writer);
                Assert.NotEmpty(respModel_Writer);
            }

            Assert.True(respModel_Seller.Length == respModel_Writer.Length);
            Assert.True(respModel_Seller[0].Equals(respModel_Writer[0]));
        }
    }
}
