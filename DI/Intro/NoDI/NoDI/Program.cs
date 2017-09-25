using System;

namespace NoDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new HomeController();
            string message = controller.Hello("Stephanie");
            Console.WriteLine(message);
        }
    }
}
