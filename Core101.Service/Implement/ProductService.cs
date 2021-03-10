using Core101.Model.DataContaxt;
using Core101.Model.Entity;
using Core101.Reporitory.Implement;
using Core101.Reporitory.Interface;
using Core101.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Core101.Service.Implement
{
    public class ProductService : IProductService
    {
        IProductRepository _product;
        private readonly Core101DataContext _core101DataContext = new Core101DataContext();
        //public ProductService(IProductRepository product)
        //{
        //    _product = product;
        //}
        public ProductService()
        {
            _product = new ProductRepository(_core101DataContext);
        }

        public IEnumerable<Product> GetAllData()
        {
           //var alldata = _product.GetMany(x => x.Price != null);
            //return alldata;
            var uri = new Uri("http://10.4.100.171:8047/MFEC_DEV_PF/WS/MFEC%20Public%20Company%20Limited/Page/Export_Dimension_Brand_for_SQ");
            var credentialsCache = new CredentialCache { { uri, "NTLM", CredentialCache.DefaultNetworkCredentials } };
            var handler = new HttpClientHandler { Credentials = credentialsCache };
            var httpClient = new HttpClient(handler) { BaseAddress = uri };
            httpClient.DefaultRequestHeaders.ConnectionClose = false;
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ServicePointManager.FindServicePoint(uri).ConnectionLeaseTimeout = 120 * 1000;  // Close connection after two minutes

            //return httpClient;

            return null;


        }
    }
}
