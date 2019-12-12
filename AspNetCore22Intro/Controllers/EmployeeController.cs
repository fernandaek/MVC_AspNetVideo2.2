using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore22Intro.Controllers
{
    [Route("[controller]/[action]")]
    public class EmployeeController : Controller
    {
        //[Route("[action]")]
        public ContentResult Name()
        {
            return Content("Fernanda Ek");
        }

        //[Route("country")]
        public string Country()
        {
            return "Sweden";
        }

        //[Route("")]
        //[Route("[action]")]
        public string Index()
        {
            return "Hello, from Emploee";
        }
    }
}
