namespace DuckDemo.Models
{
    // Concrete duck subtype
    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            Name = "Mallard Duck";
            flyBehavior = new FlyWithWings();
            quackBehavior = new Quack();
        }

        public override string Display()
        {
            return "I look like a Mallard Duck.";
        }
    }
}
