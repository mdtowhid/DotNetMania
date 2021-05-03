using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public void Post([FromForm]Employee employee)
        {
            _employeeRepository.Add(employee);
        }

        [HttpGet]
        public List<Employee> GetAll()
        {
            return _employeeRepository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        [HttpPut]
        public Employee PutEmployee([FromBody]Employee employee)
        {
            employee.EmpId = employee.EmpId;
            return _employeeRepository.Put(employee);
        }

        [HttpDelete]
        public bool DeleteEmployee(int id)
        {
            return _employeeRepository.DeleteById(id);
        }
    }
}
