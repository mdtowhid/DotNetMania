using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
    }
}
