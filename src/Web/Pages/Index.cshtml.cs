using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using Microsoft.eShopWeb.Web.Services;
using Microsoft.eShopWeb.Web.ViewModels;
using Microsoft.Extensions.Options;

namespace Microsoft.eShopWeb.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ICatalogViewModelService _catalogViewModelService;
    private readonly IReadRepository<CatalogItem> _catalogItemRepository;
    private readonly IUriComposer _uriComposer;
    public SettingsViewModel SettingsModel { get; }
    public int TotalCatalogItems { get; private set; }

    public IndexModel(
        ICatalogViewModelService catalogViewModelService,
        IReadRepository<CatalogItem> catalogItemRepository,
        IUriComposer uriComposer,
        IOptionsSnapshot<SettingsViewModel> options)
    {
        _catalogViewModelService = catalogViewModelService;
        _catalogItemRepository = catalogItemRepository;
        _uriComposer = uriComposer;
        SettingsModel = options.Value;
    }

    public required CatalogIndexViewModel CatalogModel { get; set; } = new CatalogIndexViewModel();
    public IReadOnlyCollection<CatalogItemViewModel> FeaturedCatalogItems { get; private set; } = Array.Empty<CatalogItemViewModel>();

    public async Task OnGet(CatalogIndexViewModel catalogModel, int? pageId)
    {
        CatalogModel = await _catalogViewModelService.GetCatalogItems(pageId ?? 0, Constants.ITEMS_PER_PAGE, catalogModel.BrandFilterApplied, catalogModel.TypesFilterApplied);
        FeaturedCatalogItems = (await _catalogItemRepository.ListAsync(new FeaturedCatalogItemsSpecification(3)))
            .Select(item => new CatalogItemViewModel
            {
                Id = item.Id,
                Name = item.Name,
                PictureUri = _uriComposer.ComposePicUri(item.PictureUri),
                Price = item.Price
            })
            .ToList();
        TotalCatalogItems = CatalogModel.PaginationInfo?.TotalItems ?? 0;
    }
}
