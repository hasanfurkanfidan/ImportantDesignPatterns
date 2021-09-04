using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            Expense expense = new Expense();
            expense.Detail = "Detay";
            expense.Amount = 1500;

            manager.HandleExpense(expense);
        }
    }
    public class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }
    public abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase _successor;
        public abstract void HandleExpense(Expense expense);
        public void SetSuccessor(ExpenseHandlerBase successor)
        {
            _successor = successor;
        }
    }
    public class Manager : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount <= 100)
            {
                Console.WriteLine("Manager handled the expence");
            }
            else if (_successor != null)
            {
                _successor.HandleExpense(expense);
            }
        }
    }
    public class VicePresident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount <= 1000)
            {
                Console.WriteLine("Vice President handled the expence");
            }
            else if (_successor != null)
            {
                _successor.HandleExpense(expense);
            }
        }
    }
    public class President : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine("President handled the expence");
            }
            else if (_successor != null)
            {
                _successor.HandleExpense(expense);
            }
        }
    }
}
