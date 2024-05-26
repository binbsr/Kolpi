using Kolpi.Server;
using Kolpi.WebShared;
using Kolpi.WebShared.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace Kolpi.FunctionalTests.Api
{
    public class ApiTagsList : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient client;

        public ApiTagsList(CustomWebApplicationFactory<Program> applicationFactory)
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
        public async Task ReturnTags()
        {
            var response = await client.GetAsync("/api/tags");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            
            var result = JsonConvert.DeserializeObject<IEnumerable<TagViewModel>>(stringResponse);

            Assert.Equal(2, result.Count());
            Assert.Contains(result, i => i.Name == SeedData.Tag1.Name 
                && i.Details == SeedData.Tag1.Details);
            Assert.Contains(result, i => i.Name == SeedData.Tag2.Name 
                && i.Details == SeedData.Tag2.Details);
        }
    }
}
