using Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IEmployeeRepository
    {

        //IEnumerable<Employee> GetAll();
        //Employee GetById(int id);
        //bool Add(Employee employee);
        //bool DeleteById(int id);
        //Employee Put(Employee employee);

        IEnumerable<Employee> GetAll(string query);
        Employee GetById(string query, int id);
        Employee RemoveById(string query, int id);
        dynamic Save(string query, Employee entity);
        Employee Update(string query, Employee entity);
    }
}
