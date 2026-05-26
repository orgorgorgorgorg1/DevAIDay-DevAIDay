using Microsoft.eShopWeb.Web.ViewModels;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.Web.ViewModels.BasketComponentViewModelTests;

public class DisplayItemsCount
{
    [Theory]
    [InlineData(0, "0")]
    [InlineData(42, "42")]
    [InlineData(99, "99")]
    public void ReturnsItemsCountWhenValueIsLessThan100(int itemsCount, string expectedDisplayCount)
    {
        var viewModel = new BasketComponentViewModel
        {
            ItemsCount = itemsCount
        };

        var result = viewModel.DisplayItemsCount;

        Assert.Equal(expectedDisplayCount, result);
    }

    [Fact]
    public void Returns99PlusWhenValueIsAtLeast100()
    {
        var viewModel = new BasketComponentViewModel
        {
            ItemsCount = 100
        };

        var result = viewModel.DisplayItemsCount;

        Assert.Equal("99+", result);
    }
}
