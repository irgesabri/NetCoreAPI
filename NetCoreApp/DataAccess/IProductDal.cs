using NetCoreApp.Entities;
using NetCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApp.DataAccess
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductModel> GetProductWithDetails();
    }
}
