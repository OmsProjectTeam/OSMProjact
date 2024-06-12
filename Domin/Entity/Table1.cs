using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class Table1
    {
        public int Id { get; set; }

        public int? BusinessId { get; set; }

        public int? ActivityId { get; set; }
    }
}
