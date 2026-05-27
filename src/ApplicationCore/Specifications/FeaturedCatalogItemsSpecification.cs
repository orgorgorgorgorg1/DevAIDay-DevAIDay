using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications;

public class FeaturedCatalogItemsSpecification : Specification<CatalogItem>
{
    public FeaturedCatalogItemsSpecification(int take)
    {
        Query
            .OrderBy(item => item.Id)
            .Take(take);
    }
}
