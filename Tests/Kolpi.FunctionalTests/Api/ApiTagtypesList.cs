using Kolpi.Server;
using Kolpi.WebShared;
using Kolpi.WebShared.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace Kolpi.FunctionalTests.Api
{
    public class ApiTagtypesList : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient client;

        public ApiTagtypesList(CustomWebApplicationFactory<Startup> applicationFactory)
        {
            client = applicationFactory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddAuthentication("Test")
                        .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                            "Test", options => { });
                });
            })
            .CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false,
            });

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Test");
        }

        [Fact]
        public async Task ReturnTagtypes()
        {
            var response = await client.GetAsync("/api/tagtypes");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<TagTypeViewModel>>(stringResponse);

            Assert.Equal(2, result.Count());
            Assert.Contains(result, i => i.Name == SeedData.TagType1.Name
                && i.Details == SeedData.TagType1.Details);
            Assert.Contains(result, i => i.Name == SeedData.TagType2.Name
                && i.Details == SeedData.TagType2.Details);
        }
    }
}
