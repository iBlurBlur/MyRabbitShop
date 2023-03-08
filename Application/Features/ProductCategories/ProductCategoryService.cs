using Application.Common.Interfaces;
using Application.Features.ProductCategories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductCategories;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryAPI _productCategoryAPI;

    public ProductCategoryService(IProductCategoryAPI productCategoryAPI)
    {
        this._productCategoryAPI = productCategoryAPI;
    }

    public async Task<IEnumerable<ProductCategoryDTO>> GetProductCategories()
    {
        return await _productCategoryAPI.GetProductCategories();
    }
}
