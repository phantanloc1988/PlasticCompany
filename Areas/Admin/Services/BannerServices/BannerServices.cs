using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlasticCompany.Models;

namespace PlasticCompany.Areas.Admin.Services.BannerServices
{
    public class BannerServices: IBanner
    {
        private readonly PlasticCompanyContext _context;
        public BannerServices(PlasticCompanyContext db)
        {
            _context = db;
        }
        //public string CreateBanner()
        //{
        //    Banner newBanner = new Banner()
        //    {
        //        Area
        //    }
        //    return "Ok"
        //}
    }
}
