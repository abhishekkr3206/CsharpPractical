using System;

namespace EmployeePayrollSystem
{
    // Interface
    interface IPayroll
    {
        void CalculateSalary();
    }

    // Base Class
    class Employee
    {
        public int Id;
        public string Name;
        public string Department;
        public string Designation;

        public Employee(int id, string name, string department, string designation)
        {
            Id = id;
            Name = name;
            Department = department;
            Designation = designation;
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Employee ID   : " + Id);
            Console.WriteLine("Name          : " + Name);
            Console.WriteLine("Department    : " + Department);
            Console.WriteLine("Designation   : " + Designation);
        }
    }

    // Derived Class
    class FullTimeEmployee : Employee, IPayroll
    {
        public double BasicSalary;
        public double Bonus;

        public FullTimeEmployee(int id, string name, string department,
            string designation, double salary, double bonus)
            : base(id, name, department, designation)
        {
            BasicSalary = salary;
            Bonus = bonus;
        }

        public void CalculateSalary()
        {
            double TotalSalary = BasicSalary + Bonus;

            Console.WriteLine("Basic Salary  : ₹" + BasicSalary);
            Console.WriteLine("Bonus         : ₹" + Bonus);
            Console.WriteLine("Total Salary  : ₹" + TotalSalary);
            Console.WriteLine("-----------------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IPayroll[] employees =
            {
                new FullTimeEmployee(101, "Rahul Sharma", "IT", "Software Developer", 40000, 5000),
                new FullTimeEmployee(102, "Priya Patel", "HR", "HR Executive", 35000, 3000),
                new FullTimeEmployee(103, "Amit Verma", "Finance", "Accountant", 38000, 4000)
            };

            foreach (IPayroll payroll in employees)
            {
                FullTimeEmployee emp = (FullTimeEmployee)payroll;

                Console.WriteLine("===== Employee Details =====");
                emp.DisplayDetails();
                payroll.CalculateSalary();
            }

            Console.WriteLine("Payroll Process Completed.");
        }
    }
}