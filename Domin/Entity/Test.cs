using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class Test
    {
        public int Id { get; set; }

        public int? PId { get; set; }

        public DateTime? TestDate { get; set; }

        public int? Urgent { get; set; }

        public int? Totalcoast { get; set; }

        public int? Status { get; set; }

        public int? InsertedBy { get; set; }

        public int? Serial { get; set; }

        public int? LabId { get; set; }

        public int? DoctorId { get; set; }
    }
}
