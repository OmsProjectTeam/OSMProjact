using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class ResultValue
    {
        public int Id { get; set; }

        public int? TestId { get; set; }

        public int? TestTypeId { get; set; }

        public string? Value1 { get; set; }

        public string? Summary { get; set; }

        public string? Notes { get; set; }

        public int? ResultId { get; set; }

        public int? ResultTypeId { get; set; }
    }
}
