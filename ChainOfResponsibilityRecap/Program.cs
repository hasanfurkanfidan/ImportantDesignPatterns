using System;

namespace ChainOfResponsibilityRecap
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee();
            employee.Status = "Mid";

            MidEngineer midEngineer = new MidEngineer();
            SeniorEngineer seniorEngineer = new SeniorEngineer();

            midEngineer.SetSuccessor(seniorEngineer);

            midEngineer.Handle(employee);
        }
        public class Employee
        {
            public string Status { get; set; }
        }
        public abstract class EmployeeInterviewHandler
        {
            protected EmployeeInterviewHandler Successor;
            public abstract void Handle(Employee employee);

            public void SetSuccessor(EmployeeInterviewHandler employeeInterviewHandler)
            {
                Successor = employeeInterviewHandler;
            }
        }
        public class MidEngineer : EmployeeInterviewHandler
        {
            public override void Handle(Employee employee)
            {
                if (employee.Status=="Juniour")
                {
                    Console.WriteLine("Employee handled");
                }
                if (Successor!=null)
                {
                    Successor.Handle(employee);
                }
            }
        }
        public class SeniorEngineer:EmployeeInterviewHandler
        {
            public override void Handle(Employee employee)
            {
                if (employee.Status == "Mid")
                {
                    Console.WriteLine("Employee handled");
                }
               
            }
        }
    }
}
