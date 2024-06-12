using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class ListPrice
    {
        public int Id { get; set; }

        public int? SampleId { get; set; }

        public int? LabId { get; set; }

        public int? Pricing { get; set; }
    }
}
