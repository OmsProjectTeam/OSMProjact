using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class StoreSize
    {
        public int Id { get; set; }

        public int? ItemCode { get; set; }

        public int? SizeId { get; set; }
    }
}
