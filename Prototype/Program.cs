using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer
            {
                Firstname = "Hasan Furkan",
                Lastname = "Fidan",
                City = "İstanbul"
            };
            Customer custoemer2 =(Customer) customer1.Clone();
            custoemer2.Firstname = "Ayşe";
            Console.WriteLine(customer1.Firstname);
            Console.WriteLine(custoemer2.Firstname);

        }
    }
    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
    public class Customer:Person
    {
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
        public string City { get; set; }
    }
}
