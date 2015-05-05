namespace Koi.Tests.Mocks
{
    using System;

    public interface IEmailService
    {
        void Email();
    }

    public class EmailService : IEmailService
    {
        public void Email()
        {
            Console.WriteLine("Emailed.");
        }
    }

    public class BetterEmailService : IEmailService
    {
        public void Email()
        {
            Console.WriteLine("Emailed. Better.");
        }
    }
}
