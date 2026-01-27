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
        public FlyBehavior flyBehavior { get; set; }= new FlyWithWings();

        public QuackBehavior quackBehavior { get; set; } = new Quack();

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

        public virtual void setFlyBehavior(String flyBehav)
        {
            if (flyBehav.Equals("Wings"))
            {
                flyBehavior = new FlyWithWings();
            }
            else
            {
                flyBehavior = new FlyNoWings();
            }
        }

        public virtual void setQuackBehavior(String quackBehav)
        {
            if (quackBehav.Equals("Quack"))
            {
                quackBehavior = new Quack();
            }
            else if (quackBehav.Equals("Squeak"))
            {
                quackBehavior = new Squeak();
            }
            else
            {
                quackBehavior = new MuteQuack();
            }
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
