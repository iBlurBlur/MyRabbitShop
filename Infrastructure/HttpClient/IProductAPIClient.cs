using Application.Features.Products.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.HttpClient;

public interface IProductAPIClient
{
    [Get("/product")]
    Task<IEnumerable<ProductResponseDTO>> GetProducts();

    [Get("/product/{id}")]
    Task<ProductResponseDTO?> GetProductByID(int id);

    [Delete("/product/{id}")]
    Task DeleteProduct(int id);

    [Post("/product")]
    Task AddProduct([Body(BodySerializationMethod.UrlEncoded)] CreateProductDTO createProductDTO);

    [Multipart]
    [Post("/product")]
    Task AddProduct(
        string productNumber,
        string name,
        string color,
        decimal price,
        string size,
        decimal? weight,
        string thumbnailPhotoFileName,
        StreamPart uploadFile,
        int productCategoryId
    );

    [Put("/product/{id}")]
    Task EditProduct(int id,[Body(BodySerializationMethod.UrlEncoded)] EditProductDTO editProductDTO);

    [Multipart]
    [Put("/product/{id}")]
    Task EditProduct(
        int id,
        int productId,
        string productNumber,
        string name,
        string color,
        decimal price,
        string size,
        decimal? weight,
        string thumbnailPhotoFileName,
        StreamPart uploadFile,
        int productCategoryId
    );
}

