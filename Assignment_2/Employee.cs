using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public  class Employee
    {
        public int empNo;
        public string name;
        public string dept;

        public Employee(int empNo, string name, string dept)
        {
            this.empNo = empNo;
            this.name = name;
            this.dept = dept;
        }

        public string GetDetails()
        {
            return $"EmpNo: {empNo}, Name: {name}, Dept: {dept}";
        }
    }
}
