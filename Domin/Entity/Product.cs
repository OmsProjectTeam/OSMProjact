using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class Product
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public int? CategoryId { get; set; }
    }
}
