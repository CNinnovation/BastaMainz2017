using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IGreetingService _greetingService;
        public ValuesController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        [HttpGet]
        public string Get(string name) =>
            _greetingService.Greet(name);
    }
}
