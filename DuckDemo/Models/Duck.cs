using System.Text;

namespace DuckDemo.Models
{
    // Base class providing shared behavior for all ducks
    public abstract class Duck
    {
        public string Name { get; protected set; } = "Duck";

        public virtual string Quack()
        {
            return "Quack!";
        }

        public virtual string Swim()
        {
            return "I am swimming.";
        }

        // Polymorphic method overridden by subclasses
        public abstract string Display();

        public string Describe()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Display());
            sb.AppendLine(Quack());
            sb.AppendLine(Swim());
            return sb.ToString();
        }
    }
}
