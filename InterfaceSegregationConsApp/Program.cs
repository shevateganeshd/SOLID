//SOLID
//4.I Interface Segregation Principle
namespace InterfaceSegregationConsApp
{
    /*// Bad example: Forcing unrelated methods in a single interface
    public interface IWorker
    {
        void Work();
        void Eat();
    }

    public class Robot : IWorker
    {
        public void Work()
        {
            // Robots work
        }
        public void Eat()
        {
            throw new NotImplementedException(); // Robots don't eat
        }
    }*/

    // Good example: Split the interface
    public interface IWorkable
    {
        void Work();
    }

    public interface IEatable
    {
        void Eat();
    }

    public class HumanWorker : IWorkable, IEatable
    {
        public void Work()
        {
            // Human works
            Console.WriteLine("Human is working.");
        }
        public void Eat()
        {
            // Human eats
            Console.WriteLine("Human is eating.");
        }
    }

    public class Robot : IWorkable
    {
        public void Work()
        {
            // Robot works
            Console.WriteLine("Robot is working.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create instances
            IWorkable humanWorker = new HumanWorker();
            IEatable humanEater = new HumanWorker();
            IWorkable robotWorker = new Robot();

            // Call methods
            Console.WriteLine("Human:");
            humanWorker.Work();
            humanEater.Eat();

            Console.WriteLine("\nRobot:");
            robotWorker.Work();

            Console.ReadKey();
        }
    }
}