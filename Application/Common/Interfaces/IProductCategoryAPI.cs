﻿using Application.Features.ProductCategories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces;

public interface IProductCategoryAPI
{
    Task<IEnumerable<ProductCategoryDTO>> GetProductCategories();
}