using Core101.Model.Entity;
using Core101.Reporitory.Base;
using Core101.Reporitory.Interface;
using Microsoft.EntityFrameworkCore;

namespace Core101.Reporitory.Implement
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context) { }
    }
}
