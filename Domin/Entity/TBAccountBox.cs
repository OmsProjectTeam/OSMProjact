using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBAccountBox
    {
        public int id { get; set; }
        public int? amount { get; set; }
        public int? transaction_type { get; set; }
        public DateOnly? transaction_date { get; set; }
        public string? notes { get; set; }
        public int? spent_category { get; set; }
        public int? product_id { get; set; }
        public int? order_no { get; set; }
        public int? customer_id { get; set; }
        public int? not_collected { get; set; }
        public int? batchID { get; set; }
        public int? isDeleted { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
     
        public bool CurrentState { get; set; }

    }
}
