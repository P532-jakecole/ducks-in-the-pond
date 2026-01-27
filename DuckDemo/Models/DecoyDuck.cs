namespace DuckDemo.Models
{
    // Concrete duck subtype
    public class DecoyDuck : Duck
    {
        public DecoyDuck()
        {
            Name = "Decoy Duck";
            flyBehavior = new FlyNoWings();
            quackBehavior = new MuteQuack();
        }

        public override string Display()
        {
            return "I look like a Rubber Duck.";
        }
    }
}