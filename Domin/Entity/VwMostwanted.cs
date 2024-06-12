using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class VwMostwanted
    {
        public decimal? SitePrice { get; set; }

        public string? ImgUrl { get; set; }

        public int Id { get; set; }

        public string? PCode { get; set; }

        public int? Totalorders { get; set; }
    }
}
