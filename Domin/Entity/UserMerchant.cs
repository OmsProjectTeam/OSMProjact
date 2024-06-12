using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class UserMerchant
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? MerchantId { get; set; }
    }
}
