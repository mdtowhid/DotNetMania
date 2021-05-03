using Dapper;
using DBConnection;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private string connectionString = @"data source=desktop-8kas1u3;initial catalog=DotNetMania;persist security info=True;Integrated Security=true;";

        public bool Add(Employee employee)
        {
            int effected = 0;
            using (IDbConnection dbConnection = DBConnectionBuilder.GetConnection(connectionString)) 
            {
                string query = @"INSERT INTO 
                                 EmployeeInfo(EmpName, Designation, Department) 
                                 VALUES(@EmpName, @Designation, @Department)";
                dbConnection.Open();
                effected = dbConnection.Execute(query, employee);
                dbConnection.Close();
            }
            return effected > 0 ? true : false;

        }

        public bool DeleteById(int id)
        {
            Employee employee = null;
            using (IDbConnection dbConnection = DBConnectionBuilder.GetConnection(connectionString))
            {
                string query = @"DELETE FROM EmployeeInfo 
                                 WHERE EmpId=@id";
                dbConnection.Open();
                employee = dbConnection.Query<Employee>(query, new { Id=id}).FirstOrDefault();
                dbConnection.Close();
            }

            return employee != null ? true : false;
        }

        public IEnumerable<Employee> GetAll()
        {
            List<Employee> employees = null;
            using(IDbConnection dbConnection = DBConnectionBuilder.GetConnection(connectionString))
            {
                string query = "SELECT * FROM EmployeeInfo";
                dbConnection.Open();
                employees = dbConnection.Query<Employee>(query).AsList();
                dbConnection.Close();
            }

            return employees;
        }

        public Employee GetById(int id)
        {
            Employee employee = null;
            using (IDbConnection dbConnection = DBConnectionBuilder.GetConnection(connectionString))
            {
                string query = "SELECT * FROM EmployeeInfo WHERE EmpId=@id";
                dbConnection.Open();
                employee = dbConnection.Query<Employee>(query, new { Id = id }).FirstOrDefault();
                dbConnection.Close();
            }

            return employee;
        }

        public Employee Put(Employee employee)
        {
            Employee emp = null;
            using (IDbConnection dbConnection = DBConnectionBuilder.GetConnection(connectionString))
            {
                string query = @"UPDATE EmployeeInfo 
                                 SET EmpName=@EmpName, Designation=@Designation,Department=@Department
                                 WHERE EmpId=@EmpId";

                dbConnection.Open();
                emp = GetById(employee.EmpId);
                dbConnection.Query(query, employee);
                dbConnection.Close();
            }
            return emp;
        }
    }
}
