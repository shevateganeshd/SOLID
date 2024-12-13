//SOLID
//1. S Single Responsibility
/*namespace SOLIDConsoleApp
{
    *//*
    // Bad example: One class doing multiple responsibilities
    public class Employee
    {
        public void AddEmployee()
        {
            // Code to add employee
        }
        public void GenerateReport()
        {
            // Code to generate employee report
        }
    }
    *//*

    // Good example: Each class has a single responsibility
    public class Employee
    {
        public void AddEmployee()
        {
            // Code to add employee
            Console.WriteLine("Employee Added");
        }
    }

    public class EmployeeReport
    {
        public void GenerateReport()
        {
            // Code to generate employee report
            Console.WriteLine("Employee Report Generated");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.AddEmployee();

            EmployeeReport employeeReport = new EmployeeReport();
            employeeReport.GenerateReport();

            Console.ReadKey();
        }
    }
}
*/

/*//2. O Open for Extension but Close for Modification
namespace SOLIDConsoleApp
{
    *//*// Bad example: Modifying the class for every new type of employee
    public class Employee
    {
        public double CalculateBonus(string employeeType, double salary)
        {
            if (employeeType == "Permanent")
            {
                return salary * 0.1;
            }
            else if (employeeType == "Contract")
            {
                return salary * 0.05;
            }
            return 0;
        }
    }*//*

    // Good example: Extending behavior using inheritance
    public abstract class Employee
    {
        public abstract double CalculateBonus(double salary);
    }

    public class PermanentEmployee : Employee
    {
        public override double CalculateBonus(double salary)
        {
            return salary * 0.1;
        }
    }

    public class ContractEmployee : Employee
    {
        public override double CalculateBonus(double salary)
        {
            return salary * 0.05;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            PermanentEmployee permanentEmployee = new PermanentEmployee();
            Console.WriteLine("Parmanent Employee Bonus : "+permanentEmployee.CalculateBonus(10000));

            ContractEmployee contractualEmployee = new ContractEmployee();
            Console.WriteLine("Contractual Employee Bonus : " + contractualEmployee.CalculateBonus(10000));

            Console.ReadKey();
        }
    }
}*/

//3. L Liskov Substitution Principle
/*namespace SOLIDConsoleApp
{
    *//*// Bad example: Derived class changes behavior of the base class
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
    }*//*

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
}*/

/*//4.I Interface Segregation Principle
namespace SOLIDConsoleApp
{
    *//*// Bad example: Forcing unrelated methods in a single interface
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
    }*//*

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
}*/

//5.D Dependency Inversion
/*namespace SOLIDConsoleApp
{
    *//*// Bad example: High-level module depends on low-level module
    public class EmailService
    {
        public void SendEmail(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    public class Notification
    {
        private EmailService _emailService = new EmailService();

        public void Notify(string message)
        {
            _emailService.SendEmail(message);
        }
    }*//*

    // Good example: High-level module depends on abstraction
    public interface IMessageService
    {
        void SendMessage(string message);
    }

    public class EmailService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    public class SmsService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }

    public class Notification
    {
        private readonly IMessageService _messageService;

        public Notification(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void Notify(string message)
        {
            _messageService.SendMessage(message);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // Usage
            var notification = new Notification(new EmailService());
            notification.Notify("Hello, Ganesh!");
            Console.ReadKey();
        }
    }
}*/

namespace SOLIDConsoleApp
{ 
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
        }
    }
}
