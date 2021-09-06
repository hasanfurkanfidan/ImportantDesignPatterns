using System;
using System.Collections.Generic;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            manager.Name = "Hasan Furkan Fidan";
            manager.Salary = 7000;
            Employee employee = new Employee();
            employee.Name = "Ali Tarla";
            employee.Salary = 3000;

            manager.SubOrdinates.Add(employee);

            var visitor = new PayRise();
            manager.Accept(visitor);
        }
    }
    class OrganizationalStructure
    {
        public EmployeeBase Employee;
        public OrganizationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }
        public void Accept(VisitorBase visitorBase)
        {
            Employee.Accept(visitorBase);
        }
    }
    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitorBase);
        public string Name { get; set; }
        public decimal Salary { get; set; }

    }
    class Manager : EmployeeBase
    {
        public Manager()
        {
            SubOrdinates = new List<EmployeeBase>();
        }
       public List<EmployeeBase> SubOrdinates { get; set; }
        public override void Accept(VisitorBase visitorBase)
        {
            visitorBase.Visit(this);
            foreach (var employee in SubOrdinates)
            {
                employee.Accept(visitorBase);
            }
        }
    }
    class Employee : EmployeeBase
    {
        public override void Accept(VisitorBase visitorBase)
        {
            visitorBase.Visit(this);
        }
    }
    abstract class VisitorBase
    {
        public abstract void Visit(Manager manager);
        public abstract void Visit(Employee employee);


    }
    class PayrollVisitor : VisitorBase
    {
       

        public override void Visit(Manager manager)
        {
            Console.WriteLine($"{manager.Name} adlı yöneticiye {manager.Salary} ödeme yapıldı");
        }

        public override void Visit(Employee employee)
        {
            Console.WriteLine($"{employee.Name} adlı çalışana {employee.Salary} ödeme yapıldı");
        }
    }
    class PayRise : VisitorBase
    {
        public override void Visit(Manager manager)
        {
            Console.WriteLine($"{manager.Name} adlı yöneticiye {(double) manager.Salary*0.2} zam yapıldı");
        }

        public override void Visit(Employee employee)
        {
            Console.WriteLine($"{employee.Name} adlı yöneticiye {(double)employee.Salary*0.1} zam yapıldı");
        }
    }
}
