using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminUnitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DirectoryLib()
        {
            return View();
        }
    }
}