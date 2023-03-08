using Application.Features.ProductCategories.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.HttpClient;

public interface IProductCategoryAPIClient
{
    [Get("/category")]
    Task<IEnumerable<ProductCategoryDTO>> GetProductCategories();
}
