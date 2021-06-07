using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlasticCompany.Common.MyServices
{
    public interface IMyServices
    {
        public void SaveFile(string folderPath, IFormFile File, string nameFile);
    }
}
