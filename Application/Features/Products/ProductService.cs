using Application.Commom.Interfaces;
using Application.Common.Interfaces;
using Application.Features.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products;

public class ProductService : IProductService
{
    private readonly IProductAPI _productAPI;

    public ProductService(IProductAPI productAPI)
    {
        this._productAPI = productAPI;
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
       return await _productAPI.GetProducts();
    }
}
