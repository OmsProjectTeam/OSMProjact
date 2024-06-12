using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class Jobtask
    {
        public int Id { get; set; }

        public int? ServiceId { get; set; }

        public int? OrderNo { get; set; }

        public DateOnly? StartDt { get; set; }

        public DateOnly? EndDt { get; set; }

        public string? Description { get; set; }

        public int? TaskStatus { get; set; }

        public int? IqCharges { get; set; }

        public int? TaskOwnerId { get; set; }

        public int? BatchId { get; set; }

        public int? Cleared { get; set; }
    }
}
