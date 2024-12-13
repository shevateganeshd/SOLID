//SOLID
//2. O Open for Extension but Close for Modification
namespace OpenForExtensionClosedForModificationConsApp
{
    /*// Bad example: Modifying the class for every new type of employee
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
    }*/

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
}