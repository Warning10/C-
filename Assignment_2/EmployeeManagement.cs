using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    internal class EmployeeManagement
    {
        public void AcceptAndDisplayDetails()
        {
            ArrayList employees = new ArrayList();

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter Employee Number: ");
                int empNo = int.Parse(Console.ReadLine());

                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Employee Department: ");
                string dept = Console.ReadLine();

                Employee employee = new Employee(empNo, name, dept);
                employees.Add(employee);
            }

            Console.WriteLine("\nEmployee Details:");
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee.GetDetails());
            }
        }
    }
}
