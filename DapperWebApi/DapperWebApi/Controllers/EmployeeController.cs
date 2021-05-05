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
        private static IEmployeeRepository _repo;
        private string query="";

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _repo = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            query = "SELECT * FROM EmployeeInfo";
            return Ok(_repo.GetAll(query).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            query = "SELECT * FROM EmployeeInfo WHERE EmpId=@id";
            return Ok(_repo.GetById(query, id));
        }
        [HttpPost]
        public IActionResult Post([FromForm]Employee employee)
        {
            query = @"INSERT INTO 
                                 EmployeeInfo(EmpName, Designation, Department) 
                                 VALUES(@EmpName, @Designation, @Department);
                                 SELECT CAST(SCOPE_IDENTITY() as int)";
            dynamic id = _repo.Save(query, employee);
            query = "SELECT * FROM EmployeeInfo WHERE EmpId=@id";
            Employee emp = _repo.GetById(query, id);
            return Ok(emp);
        }

        [HttpPut]
        public IActionResult PutEmployee([FromBody]Employee employee)
        {
            query = @"UPDATE EmployeeInfo 
                                 SET EmpName=@EmpName, Designation=@Designation,Department=@Department
                                 WHERE EmpId=@EmpId";
            var result = _repo.Update(query, employee);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            query = @"DELETE FROM EmployeeInfo 
                                 WHERE EmpId=@id";
            return Ok(_repo.RemoveById(query, id));
        }
    }
}
