using System;
using System.Collections.Generic;
using System.Text;

namespace UsingDI
{
    public class HomeController
    {
        private readonly IGreetingService _greetingService;
        public HomeController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }
        public string Hello(string name) => _greetingService.Greet(name);

    }
}
