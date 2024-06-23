using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewOrderNew
    {
        public int? IdOrderNew { get; set; }
        public int? IdClintWitheDeliveryTariffs { get; set; }
        public string? NikeNAme { get; set; }
        public string? code { get; set; }
        public decimal? ClintDelivery { get; set; }
        public string? cust_name { get; set; }
        public string? cust_mob { get; set; }
        public string? CityCustemor { get; set; }
        public string? AreaCustemor { get; set; }
        public string? Merchant_name { get; set; }
        public string? merchant_mob { get; set; }
        public string? CityName { get; set; }
        public string? AreaMersh { get; set; }
        public string? DescriptionClint { get; set; }
        public int? IdorderStatus { get; set; }
        public string? description { get; set; }
        public string? role { get; set; }
        public int? IdorderCases { get; set; }
        public string? orderCases { get; set; }
        public DateOnly? OrderDate { get; set; }
        public string? DescriptionOrder { get; set; }
        public decimal? Weight { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? Price { get; set; }
        public string? Addres { get; set; }
        public string? Nouts { get; set; }
        public string? DataEntry { get; set; }
        public DateTime? DateTimeEntry { get; set; }
        public bool? CurrentState { get; set; }


    }
}
