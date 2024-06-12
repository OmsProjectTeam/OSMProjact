using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class OrderStatus
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public int? Role { get; set; }
    }
}
