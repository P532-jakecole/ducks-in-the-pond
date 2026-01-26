namespace DuckDemo.Models
{
    // Concrete duck subtype
    public class RedheadDuck : Duck
    {
        public RedheadDuck()
        {
            Name = "Redhead Duck";
        }

        public override string Display()
        {
            return "I look like a Redhead Duck.";
        }
    }
}
