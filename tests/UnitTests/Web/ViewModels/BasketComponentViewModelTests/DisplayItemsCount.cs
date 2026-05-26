using Microsoft.eShopWeb.Web.ViewModels;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.Web.ViewModels.BasketComponentViewModelTests;

public class DisplayItemsCount
{
    [Fact]
    public void ReturnsItemsCountWhenValueIsLessThan100()
    {
        var viewModel = new BasketComponentViewModel
        {
            ItemsCount = 42
        };

        var result = viewModel.DisplayItemsCount;

        Assert.Equal("42", result);
    }

    [Fact]
    public void Returns99PlusWhenValueIsGreaterThan99()
    {
        var viewModel = new BasketComponentViewModel
        {
            ItemsCount = 100
        };

        var result = viewModel.DisplayItemsCount;

        Assert.Equal("99+", result);
    }
}
