using System;
using System.Runtime.Intrinsics.Arm;

namespace DecoratorRecap
{
    class Program
    {
        static void Main(string[] args)
        {
            var transitOrder = new TransitOrder();
            transitOrder.Price = 500;

            SpescialCustomerOffer spescialCustomerOffer = new SpescialCustomerOffer(transitOrder);
            Console.WriteLine(spescialCustomerOffer.Price);
        }
    }
    public abstract class OrderBase
    {
        public abstract decimal Price { get; set; }
        public abstract string From { get; set; }
    }
    public class NormalOrder : OrderBase
    {
        public override string From { get; set; }
        public override decimal Price { get; set; }
    }
    public class TransitOrder : OrderBase
    {
        public override string From { get; set; }
        public override decimal Price { get; set; }
    }
    public abstract class OrderBaseDecorator : OrderBase
    {
        OrderBase orderBase;
        public OrderBaseDecorator(OrderBase orderBase)
        {
            this.orderBase = orderBase;
        }
    }
    public class SpescialCustomerOffer:OrderBaseDecorator
    {
        OrderBase orderbase;
        public SpescialCustomerOffer(OrderBase orderBase):base(orderBase)
        {
            this.orderbase = orderBase;
        }
        public override string From { get; set ; }
        public override decimal Price { get { return orderbase.Price * 95 / 100; } set { } }
    }
}
