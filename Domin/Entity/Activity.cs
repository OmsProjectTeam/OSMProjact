using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class Activity
    {
        public int ActivityId { get; set; }

        public string? ActivityName { get; set; }

        public int? CategoryId { get; set; }
    }
}
