using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PlasticCompany.Models
{
    public partial class Image
    {
        public int ImageId { get; set; }
        public string Type { get; set; }
        public string Area { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public int? Index { get; set; }
    }
}
