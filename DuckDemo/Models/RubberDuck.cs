namespace DuckDemo.Models
{
    // Concrete duck subtype
    public class RubberDuck : Duck
    {
        public RubberDuck()
        {
            Name = "Rubber Duck";
            flyBehavior = new FlyNoWings();
            quackBehavior = new Squeak();
        }

        public override string Display()
        {
            return "I look like a Rubber Duck.";
        }
    }
}