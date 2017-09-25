using System;
using System.Collections.Generic;
using System.Text;

namespace UsingDI
{
    public class GreetingService : IGreetingService
    {
        public string Greet(string name) => $"Hello, {name}";
    }
}
