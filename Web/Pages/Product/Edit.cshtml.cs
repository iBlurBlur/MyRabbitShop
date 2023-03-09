using Application.Common.Interfaces;
using Application.Features.ProductCategories.Models;
using Application.Features.Products.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.ViewModels;


namespace Web.Pages.Product
{   
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;

        [BindProperty]
        public EditProductViewModel EditProductViewModel { get; set; } = new EditProductViewModel();

        public IEnumerable<SelectListItem>? SelectListProductCategories { get; set; }

        public EditModel(IProductService productService)
        {
            this._productService = productService;
        }

        public async Task OnGet(int id)
        {
           await SetupWidgets(id);
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                SetupDropdown();
                return Page();
            }

            IFormFile? upload = EditProductViewModel.UploadFile;
            if (upload != null)
            {
                await _productService.EditProduct(
                    id,
                    EditProductViewModel.ProductId,
                    EditProductViewModel.ProductNumber,
                    EditProductViewModel.Name,
                    EditProductViewModel.Color!,
                    EditProductViewModel.Price,
                    EditProductViewModel.Size!,
                    EditProductViewModel.Weight,
                    $"{Guid.NewGuid()}.{Path.GetExtension(upload.FileName)}",
                    upload.OpenReadStream(),
                    EditProductViewModel.CategoryId);
            }
            else
            {
                await _productService.EditProduct(id, EditProductViewModel.Adapt<EditProductDTO>());
            }

            return RedirectToPage("Index");
        }

        private void SetupDropdown()
        {
            List<SelectListItem>? items = GetCategories().Select(
                c => new SelectListItem()
                {
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


        private async Task<IActionResult> SetupWidgets(int id)
        {
            ProductResponseDTO? product = await _productService.GetProductByID(id);
            if (product == null)
            {
                return RedirectToPage("Index");
            }

            EditProductViewModel = MapEditProductViewModel(product);
            SetupDropdown();
            return RedirectToPage();
        }

        private EditProductViewModel MapEditProductViewModel(ProductResponseDTO productViewModel)
        {
            TypeAdapterConfig<ProductResponseDTO, EditProductViewModel>
                   .NewConfig()
                   .Map(dest => dest.CategoryId, src => src.ProductCategory!.ProductCategoryId);

            return TypeAdapter.Adapt<ProductResponseDTO, EditProductViewModel>(productViewModel);
        }
    }   
}