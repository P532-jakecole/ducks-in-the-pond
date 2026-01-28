using System.Text;
using System;

namespace DuckDemo.Models
{
    public interface FlyBehavior
    {
        
        string fly();

    }

    public class FlyWithWings : FlyBehavior
    {

        public FlyWithWings(){}

        public string fly()
        {
            return "WOW I am flying!";
        }   
    }

    public class FlyNoWings : FlyBehavior
    {

        public FlyNoWings(){}

        public string fly()
        {
            return "Hnng... Hnng... Nope not happening.";
        }   
    }

    public interface QuackBehavior
    {
        
        string quack();

    }

    public class Quack : QuackBehavior
    {

        public Quack(){}

        public string quack()
        {
            return "QUACK!";
        }   
    }

    public class Squeak : QuackBehavior
    {

        public Squeak(){}

        public string quack()
        {
            return "SQUEAK!";
        }   
    }

    public class MuteQuack : QuackBehavior
    {

        public MuteQuack(){}

        public string quack()
        {
            return " ... ";
        }   
    }

    // Base class providing shared behavior for all ducks
    public abstract class Duck
    {
        public string Name { get; protected set; } = "Duck";
        public FlyBehavior flyBehavior;

        public QuackBehavior quackBehavior;

        public virtual string performQuack()
        {
            return quackBehavior.quack();
        }

        public virtual string performFly(){
            return flyBehavior.fly();
        }

        public virtual string Swim()
        {
            return "I am swimming.";
        }

        public virtual void setFlyBehavior(FlyBehavior flyBehav)
        {
            flyBehavior = flyBehav;
        }

        public virtual void setQuackBehavior(QuackBehavior quackBehav)
        {
            quackBehavior = quackBehav;   
        }

        // Polymorphic method overridden by subclasses
        public abstract string Display();

        public string Describe()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Display());
            sb.AppendLine(Swim());
            sb.AppendLine(performQuack());
            sb.AppendLine(performFly());
            return sb.ToString();
        }

    }
}
