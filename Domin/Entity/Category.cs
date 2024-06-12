using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class Category
    {
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
    }
}
