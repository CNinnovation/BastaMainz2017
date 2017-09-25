using System;
using System.Collections.Generic;
using System.Text;

namespace DIWithContainer
{
    public class GreetingService : IGreetingService
    {
        public string Greet(string name) => $"Hello, {name}";
    }
}
