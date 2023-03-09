using Application.Common.Interfaces;
using Application.Features.ProductCategories.Models;
using Application.Features.Products.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Web.ViewModels;

namespace Web.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;

        [BindProperty]
        public EditProductViewModel CreateProductViewModel { get; set; } = new EditProductViewModel();

        public IEnumerable<SelectListItem>? SelectListProductCategories { get; set; }

        public CreateModel(IProductService productService)
        {
            this._productService = productService;
        }

        public void OnGet()
        {
            SetupDropdown();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                SetupDropdown();
                return Page();
            }

            IFormFile? upload = CreateProductViewModel.UploadFile;
            if (upload != null)
            {
                await _productService.AddProduct(
                    (string)CreateProductViewModel.ProductNumber,
                    (string)CreateProductViewModel.Name,
                    (string)CreateProductViewModel.Color!,
                    (decimal)CreateProductViewModel.Price,
                    (string)CreateProductViewModel.Size!,
                    (decimal?)CreateProductViewModel.Weight,
                    $"{Guid.NewGuid()}.{Path.GetExtension(upload.FileName)}",
                    upload.OpenReadStream(),
                    CreateProductViewModel.CategoryId);
            }
            else
            {
                await _productService.AddProduct(CreateProductViewModel.Adapt<CreateProductDTO>());
            }

            return RedirectToPage("Index");
        }

        private void SetupDropdown()
        {
            List<SelectListItem>? items = GetCategories().Select(
                c => new SelectListItem() { 
                    Text = c.Name,
                    Value = c.ProductCategoryId.ToString()
                }
                ).ToList();

            items.Insert(0, new SelectListItem()
            {
                Text = "Pick one",
                Value = string.Empty,
                Selected = true
            });

            SelectListProductCategories = items;
        }

        private IEnumerable<ProductCategoryDTO> GetCategories()
        {
            return new List<ProductCategoryDTO>() {
                                new ProductCategoryDTO
                                {
                                    Name = "Bikes",
                                    ProductCategoryId = 1,
                                },
                                new ProductCategoryDTO
                                {
                                    Name = "Components",
                                    ProductCategoryId = 2,
                                },
                                new ProductCategoryDTO
                                {
                                    Name = "Clothing",
                                    ProductCategoryId = 3,
                                },
                                new ProductCategoryDTO
                                {
                                    Name = "Accessories",
                                    ProductCategoryId = 4,
                                }

                };
        }
    }
}