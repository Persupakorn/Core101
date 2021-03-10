using Core101.Model.DataContaxt;
using Core101.Reporitory.Implement;
using Core101.Repository.Implement;
using Core101.Service.Implement;
using Core101.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core101.Service
{
    public class Core101ServiceFactory : IDisposable
    {
        private readonly Core101DataContext _core101DataContext = new Core101DataContext();
        public Core101ServiceFactory(Core101DataContext core101DataContext)
        {
            _core101DataContext = core101DataContext;
        }

        public IProductService Product()
        {
            return new ProductService();
        }
        public ITaskService Task()
        {
            return new TaskService(new TaskRepository(_core101DataContext));
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
