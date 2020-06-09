using Core101.Model.Entity;
using Core101.Reporitory.Interface;
using Core101.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core101.Service.Implement
{
    public class ProductService : IProductService
    {
        IProductRepository _product;
        public ProductService(IProductRepository product)
        {
            _product = product;
        }
        public IEnumerable<Product> GetAllData()
        {
            var alldata = _product.GetMany(x => x.Price != null);
            return alldata;
        }
    }
}
