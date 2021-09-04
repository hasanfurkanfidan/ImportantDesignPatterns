using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar
            {
                Brand = "BMW",
                HirePrice = 1000,
                Model = "3"
            };
            var specialOffer = new SpecialOffer(personalCar);
            Console.WriteLine(specialOffer.HirePrice);
        }
        public abstract class CarBase
        {
            public abstract string Brand { get; set; }
            public abstract string Model { get; set; }
            public abstract decimal HirePrice { get; set; }
        }
        public class CommercialCar : CarBase
        {
            public override string Brand { get; set; }
            public override string Model { get; set; }
            public override decimal HirePrice { get; set; }
        }
        public class PersonalCar : CarBase
        {
            public override string Brand { get; set; }
            public override decimal HirePrice { get; set; }
            public override string Model { get; set; }

        }
        public abstract class CarDecoratorBase : CarBase
        {
            CarBase _carBase;
            public CarDecoratorBase(CarBase carBase)
            {
                _carBase = carBase;
            }
        }
        public class SpecialOffer : CarDecoratorBase
        {
            private readonly CarBase carBase;
            public SpecialOffer(CarBase carBase) : base(carBase)
            {
                this.carBase = carBase;
            }
            public override string Brand { get; set; }
            public override decimal HirePrice { get { return carBase.HirePrice * 90 / 100; } set { } }
            public override string Model { get; set; }
        }
    }
}
