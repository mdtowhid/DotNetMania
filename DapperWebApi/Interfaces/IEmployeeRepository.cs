using Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        bool Add(Employee employee);
        bool DeleteById(int id);
        Employee Put(Employee employee);
    }
}
