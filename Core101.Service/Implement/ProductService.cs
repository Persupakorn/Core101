using Core101.Model.Entity;
using Core101.Reporitory.Interface;
using Core101.Service.Interface;
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
        public Product GetAllData()
        {
            var alldata = _product.Get(x => x.Price != null);
            return alldata;
        }
    }
}
