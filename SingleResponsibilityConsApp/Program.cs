//SOLID
//1. S Single Responsibility
namespace SingleResponsibilityConsApp
{
    /*
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
    */

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
