using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class TblSize
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public int? GroupIndex { get; set; }

        public int? OrderIndex { get; set; }
    }
}
