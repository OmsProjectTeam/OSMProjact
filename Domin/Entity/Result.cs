using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class Result
    {
        public int Id { get; set; }

        public int? TestId { get; set; }

        public DateOnly? InsertDate { get; set; }

        public string? Notes { get; set; }

        public int? Serial { get; set; }
    }
}
