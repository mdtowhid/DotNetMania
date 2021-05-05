using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ProductsService : IProductsRepository
    {
        private readonly IRepository<Product> _product;
        public ProductsService(IRepository<Product> product)
        {
            _product = product;
        }

        public IEnumerable<Product> GeAll(string query)
        {
            return _product.GetAll(query);
        }

        public Product GetById(string query, int id)
        {
            return _product.GetById(query, id);
        }
    }
}
