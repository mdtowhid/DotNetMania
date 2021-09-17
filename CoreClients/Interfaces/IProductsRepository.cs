using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GeAll(string query);
        Product GetById(string query, int id);
    }
}
