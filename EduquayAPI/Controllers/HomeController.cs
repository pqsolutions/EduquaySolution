using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduquayAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET api/Home/Index
        [HttpGet]

        public ActionResult<string> Index()
        {
            return "Home index";
        }

        // GET api/Home/Name
        [HttpGet]
        [Route("Name")]
        public ActionResult<string> GetName()
        {
            return "Name of the site";
        }
    }
}