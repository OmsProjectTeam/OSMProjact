using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class Merchant
    {
        public int Id { get; set; }

        public string? MerchantName { get; set; }

        public string? MerchantMob { get; set; }

        public int? SmsAlert { get; set; }

        public int? UsDelivery { get; set; }

        public int? IsPublic { get; set; }

        public int? CityId { get; set; }

        public int? Bgw { get; set; }

        public int? Cities { get; set; }

        public int? Hidden { get; set; }

        public int? CustomerId { get; set; }

        public decimal? Outskirts { get; set; }

        public int? Branch { get; set; }

        public int? Sorting { get; set; }

        public int? Credit { get; set; }

        public int? Bypass { get; set; }

        public int? UserId { get; set; }

        public int IdInformationCompanies { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool Active { get; set; }
        public bool CurrentState { get; set; }


    }
}
