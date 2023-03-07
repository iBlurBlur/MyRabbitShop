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
}

