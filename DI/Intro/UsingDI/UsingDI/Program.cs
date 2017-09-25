using System;

namespace UsingDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new HomeController(new GreetingService());
            string message = controller.Hello("Matthias");
            Console.WriteLine(message);
        }
    }
}
