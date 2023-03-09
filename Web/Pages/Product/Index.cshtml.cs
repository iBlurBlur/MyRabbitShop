using Application.Commom.Interfaces;
using Application.Common.Interfaces;
using Application.Features.Products.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IEnumerable<ProductResponseDTO> Products { get; set; } = Enumerable.Empty<ProductResponseDTO>();
   

        public IndexModel(IProductService productService)
        {
            this._productService = productService;
        }

        public async Task OnGet()
        {
            Products = await _productService.GetProducts();  
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            await _productService.DeleteProduct(id);
            return RedirectToPage();
        }
    }
}
