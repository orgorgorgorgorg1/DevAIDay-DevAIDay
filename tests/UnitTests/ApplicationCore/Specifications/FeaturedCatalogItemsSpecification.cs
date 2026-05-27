using System.Collections.Generic;
using System.Linq;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications;

public class FeaturedCatalogItemsSpecification
{
    [Fact]
    public void ReturnsFirstThreeCatalogItemsOrderedById()
    {
        var spec = new eShopWeb.ApplicationCore.Specifications.FeaturedCatalogItemsSpecification(3);

        var result = spec.Evaluate(GetTestCollection()).ToList();

        Assert.Equal(3, result.Count);
        Assert.Equal(new[] { "Item 1", "Item 2", "Item 3" }, result.Select(item => item.Name));
    }

    private static List<CatalogItem> GetTestCollection()
    {
        return new List<CatalogItem>
        {
            new TestCatalogItem(3, "Item 3"),
            new TestCatalogItem(1, "Item 1"),
            new TestCatalogItem(4, "Item 4"),
            new TestCatalogItem(2, "Item 2")
        };
    }

    private sealed class TestCatalogItem : CatalogItem
    {
        public TestCatalogItem(int id, string name)
            : base(1, 1, name, name, id, $"TestUri{id}")
        {
            Id = id;
        }
    }
}
