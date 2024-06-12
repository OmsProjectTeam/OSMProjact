using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class Warehouse
    {
        public int Id { get; set; }

        public DateOnly? InsertDt { get; set; }

        public int? ItemStatus { get; set; }

        public int? OrderNo { get; set; }

        public int? ItemCode { get; set; }

        public int? DeliveryDt { get; set; }

        public string? Notes { get; set; }

        public int? BatchId { get; set; }
    }
}
