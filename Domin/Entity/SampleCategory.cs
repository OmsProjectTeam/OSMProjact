using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class SampleCategory
    {
        public int Id { get; set; }

        public int? Parentid { get; set; }

        public string? Title { get; set; }

        public string? Unit { get; set; }

        public string? ReferenceRange { get; set; }
    }
}
