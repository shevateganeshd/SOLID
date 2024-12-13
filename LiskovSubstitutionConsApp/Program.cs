//SOLID
//3. L Liskov Substitution Principle
namespace LiskovSubstitutionConsApp
{
    /*// Bad example: Derived class changes behavior of the base class
    public class Bird
    {
        public virtual void Fly()
        {
            Console.WriteLine("Flying");
        }
    }

    public class Ostrich : Bird
    {
        public override void Fly()
        {
            throw new NotImplementedException("Ostriches can't fly");
        }
    }*/

    // Good example: Use a better hierarchy
    public abstract class Bird { }

    public class FlyingBird : Bird
    {
        public void Fly()
        {
            Console.WriteLine("Flying");
        }
    }

    public class NonFlyingBird : Bird
    {
        // No Fly method
        public void Display()
        {
            Console.WriteLine("I cannot fly.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //FlyingBird flyingBird = new FlyingBird();
            //flyingBird.Fly();
            //NonFlyingBird nonFlyingBird = new NonFlyingBird();
            //NonFlyingBird nonFlyingBird1 = flyingBird;

            List<Bird> birds = new List<Bird> {
                new FlyingBird(),
                new NonFlyingBird()
            };

            // Loop through each bird and call the appropriate behavior
            foreach (var bird in birds)
            {
                if (bird is FlyingBird flyingBird)
                {
                    flyingBird.Fly();
                }
                else if (bird is NonFlyingBird nonFlyingBird)
                {
                    nonFlyingBird.Display();
                }
            }

            Console.ReadKey();
        }
    }
}