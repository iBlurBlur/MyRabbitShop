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

    public async Task AddProduct(CreateProductDTO createProductDTO)
    {
        await _productAPI.AddProduct(createProductDTO);
    }

    public async Task AddProduct(string productNumber, string name, string color, decimal price, string size, decimal? weight, string thumbnailPhotoFileName, Stream uploadFile, int productCategoryId)
    {
        await _productAPI.AddProduct(productNumber,
            name,
            color,
            price,
            size,
            weight,
            thumbnailPhotoFileName,
            uploadFile,
            productCategoryId);
    }

    public async Task DeleteProduct(int id)
    {
        await _productAPI.DeleteProduct(id);
    }

    public async Task EditProduct(int id, EditProductDTO editProductDTO)
    {
        await _productAPI.EditProduct(id, editProductDTO);
    }

    public async Task EditProduct(int id, int productId, string productNumber, string name, string color, decimal price, string size, decimal? weight, string thumbnailPhotoFileName, Stream uploadFile, int productCategoryId)
    {
        await _productAPI.EditProduct(
            id,
            productId,
            productNumber,
            name,
            color,
            price,
            size,
            weight,
            thumbnailPhotoFileName,
            uploadFile,
            productCategoryId);
    }

    public async Task<ProductResponseDTO?> GetProductByID(int id)
    {
        return await _productAPI.GetProductByID(id);
    }

    public async Task<IEnumerable<ProductResponseDTO>> GetProducts()
    {
        return await _productAPI.GetProducts();
    }
}
