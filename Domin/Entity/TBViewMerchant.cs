using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewMerchant
    {

        public int id { get; set; }
        public string? Merchant_name { get; set; }
        public string? merchant_mob { get; set; }
        public int? sms_alert { get; set; }
        public int? US_delivery { get; set; }
        public int? isPublic { get; set; }
		public int? bgw { get; set; }
		public int? cities { get; set; }

		public string? CityName { get; set; }
		public int? city_id { get; set; }

		public string? description { get; set; }     
        public int? hidden { get; set; }
        public int? customer_id { get; set; }

        public string? cust_name { get; set; }
        public string? cust_mob { get; set; }
        public string? cust_mob2 { get; set; }
        public string? TypesCompanies { get; set; }
        public string? CompanyName { get; set; }
        public string? NikeNAme { get; set; } 
        public decimal? outskirts { get; set; }
        public int? branch { get; set; }
        public int? sorting { get; set; }
        public int? credit { get; set; }
        public int? bypass { get; set; }
		public int? user_id { get; set; }
		public string? username { get; set; }
        public string? userpwd { get; set; }
        public int? is_active { get; set; }
        public bool Active { get; set; }
        public bool CurrentState { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public int? IdInformationCompanies { get; set; }  
        public string? TypesCompaniesM { get; set; }
        public string? CompanyNameM { get; set; }
        public string? NikeNAmeM { get; set; }


        





    }
}
