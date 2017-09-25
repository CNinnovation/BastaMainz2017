using System;
using System.Collections.Generic;
using System.Text;

namespace NoDI
{
    public class HomeController
    {
        public string Hello(string name)
        {
            var service = new GreetingService();
            return service.Greet(name);
        }
    }
}
