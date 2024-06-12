using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class Preorder
    {
        public int Id { get; set; }

        public int? CustId { get; set; }

        public int? Totalamount { get; set; }

        public int? OrderDate { get; set; }

        public int? InsertDate { get; set; }

        public int? Qty { get; set; }

        public int? Status { get; set; }
    }
}
