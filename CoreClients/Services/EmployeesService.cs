using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class EmployeesService : IEmployeeRepository
    {
        private readonly IRepository<Employee> _repo;

        public EmployeesService(IRepository<Employee> repo)
        {
            _repo = repo;
        }
        public IEnumerable<Employee> GetAll(string query)
        {
            return _repo.GetAll(query);
        }

        public Employee GetById(string query, int id)
        {
            return _repo.GetById(query, id);
        }

        public Employee RemoveById(string query, int id)
        {
            return _repo.RemoveById(query, id);
        }

        public dynamic Save(string query, Employee entity)
        {
            return _repo.Save(query, entity);
        }

        public Employee Update(string query, Employee entity)
        {
            return _repo.Update(query, entity);
        }
    }
}
