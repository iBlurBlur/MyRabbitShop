using Application.Commom.Interfaces;
using Application.Features.Products.Models;
using Infrastructure.HttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.HttpClient;

public class ProductAPI : IProductAPI
{
    private readonly IProductAPIClient _productAPIClient;

    public ProductAPI(IProductAPIClient productAPIClient)
    {
        this._productAPIClient = productAPIClient;
    }

    public Task AddProduct(CreateProductDTO createProductDTO)
    {
        throw new NotImplementedException();
    }

    public Task AddProduct(string productNumber, string name, string color, decimal price, string size, decimal? weight, string thumbnailPhotoFileName, Stream uploadFile, int productCategoryId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }

    public Task EditProduct(int id, EditProductDTO editProductDTO)
    {
        throw new NotImplementedException();
    }

    public Task EditProduct(int id, int productId, string productNumber, string name, string color, decimal price, string size, decimal? weight, string thumbnailPhotoFileName, Stream uploadFile, int productCategoryId)
    {
        throw new NotImplementedException();
    }

    public Task<ProductResponseDTO?> GetProductByID(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ProductResponseDTO>> GetProducts()
    {
        return await _productAPIClient.GetProducts();
    }
}
