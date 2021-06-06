using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PlasticCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }
    }
}
