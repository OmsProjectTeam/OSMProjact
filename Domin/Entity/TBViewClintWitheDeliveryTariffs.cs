using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewClintWitheDeliveryTariffs
    {
        public int IdClintWitheDeliveryTariffs { get; set; }
        public int IdCityDeliveryTariffs { get; set; }
        public string DescriptionClint { get; set; }

        public string description { get; set; }
        public string AreaName { get; set; }
        public string NikeNAme { get; set; }
        public string code { get; set; }
        public decimal ClintDelivery { get; set; }
        public int IdCustomer { get; set; }
        public string cust_name { get; set; }
        public string cust_mob { get; set; }
        public string CityCustemor { get; set; }
        public string AreaCustemor { get; set; }
        public int IdMerchant { get; set; }
        public string Merchant_name { get; set; }
        public string merchant_mob { get; set; }
        public string CityName { get; set; }
        public string AreaMersh { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool CurrentState { get; set; }
    }
}
