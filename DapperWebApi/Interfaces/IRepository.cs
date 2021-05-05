using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll(string query);
        T GetById(string query, int id);
        T RemoveById(string query, int id);
        dynamic Save(string query, T entity);
        T Update(string query, T entity);
    }
}
