using System.Globalization;

namespace Microsoft.eShopWeb.Web.ViewModels;

public class BasketComponentViewModel
{
    public int ItemsCount { get; set; }

    public string DisplayItemsCount => ItemsCount > 99
        ? "99+"
        : ItemsCount.ToString(CultureInfo.InvariantCulture);
}
