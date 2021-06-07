using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlasticCompany.Areas.Admin.Services.ProductsServices;
using PlasticCompany.Areas.Admin.ViewModels.Products;
using PlasticCompany.Common.MyServices;
using PlasticCompany.Models;

namespace PlasticCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IMyServices _myServcies;
        private readonly IProduct _productServices;


        public ProductsController(IMyServices ms, IProduct p)
        {
            _myServcies = ms;
            _productServices = p;
        }
        public IActionResult Index()
        {
            var productList = _productServices.GetAll();
            return View(productList);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string data)
        {
            if (Request.Form.Count > 0)
            {
                Product productObj = JsonConvert.DeserializeObject<Product>(Request.Form["Product"]);

                var result = await _productServices.CreateProduct(productObj, (List<IFormFile>)Request.Form.Files);
                if (result == "Ok")
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
