//SOLID
//5.D Dependency Inversion Principle
namespace DependencyInversionConsApp
{
    /*// Bad example: High-level module depends on low-level module
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
    }*/

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
}