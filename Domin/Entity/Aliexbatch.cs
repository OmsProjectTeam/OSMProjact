using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class Aliexbatch
    {
        public int Id { get; set; }

        public DateTime? InsertDt { get; set; }

        public int? MerchantId { get; set; }

        public int? BatchStatus { get; set; }
    }
}
