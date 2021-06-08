using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace PlasticCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController : Controller
    {

        public BannerController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create()
        //{
        //    if (Request.Form.Files.Count > 0)
        //    {
        //        var result = await _productServices.CreateProduct(product, (List<IFormFile>)files);

        //        if (result == "Ok")
        //        {
        //            return Json(new { status = result, url = Url.Action("Index", "Products") });
        //        }
        //    }
        //    return View();
        //}
    }
}
