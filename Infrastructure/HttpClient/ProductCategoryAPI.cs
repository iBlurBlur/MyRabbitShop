using Application.Common.Interfaces;
using Application.Features.ProductCategories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.HttpClient;

public class ProductCategoryAPI : IProductCategoryAPI
{
    private readonly IProductCategoryAPIClient _productCategoryAPIClient;

    public ProductCategoryAPI(IProductCategoryAPIClient productCategoryAPIClient)
    {
        this._productCategoryAPIClient = productCategoryAPIClient;
    }

    public async Task<IEnumerable<ProductCategoryDTO>> GetProductCategories()
    {
        return await _productCategoryAPIClient.GetProductCategories();
    }
}
