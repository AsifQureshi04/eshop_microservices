using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shopping.Web.Pages
{
    public class IndexModel
        (ICatalogService catalogService, IBasketService basketService, ILogger<IndexModel> logger)
        : PageModel
    {
        public IEnumerable<ProductModel> ProductList { get; set; } = new List<ProductModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            logger.LogInformation("Index page visited");
            var result = await catalogService.GetProducts();
            //var result = await catalogService.GetProducts(2, 3);
            ProductList = result.Products;
            return Page();
        }
    }
}
