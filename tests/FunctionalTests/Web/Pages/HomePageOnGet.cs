using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.eShopWeb.FunctionalTests.Web;
using Xunit;

namespace Microsoft.eShopWeb.FunctionalTests.WebRazorPages;

[Collection("Sequential")]
public class HomePageOnGet : IClassFixture<TestApplication>
{
    public HomePageOnGet(TestApplication factory)
    {
        Client = factory.CreateClient();
    }

    public HttpClient Client { get; }

    [Fact]
    public async Task ReturnsHomePageWithProductListing()
    {
        // Arrange & Act
        var response = await Client.GetAsync("/");
        response.EnsureSuccessStatusCode();
        var stringResponse = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.Contains("Sale &mdash; 50% korting this week", stringResponse);
        Assert.Contains("Featured products", stringResponse);
        Assert.Contains("Browsing 12 products", stringResponse);
        Assert.Contains(".NET Bot Black Sweatshirt", stringResponse);
        Assert.Contains(".NET Black &amp; White Mug", stringResponse);
        Assert.Contains("Prism White T-Shirt", stringResponse);

        var featuredProductsMarkup = stringResponse[
            stringResponse.IndexOf("Featured products")..
            stringResponse.IndexOf("Browsing 12 products")];

        Assert.Equal(3, Regex.Matches(featuredProductsMarkup, "Shop now").Count);
    }
}
