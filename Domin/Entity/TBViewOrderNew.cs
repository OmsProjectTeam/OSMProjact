using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewOrderNew
    {
        public int IdOrderNew { get; set; }
        public int IdClintWitheDeliveryTariffs { get; set; }
        public int IdCityDeliveryTariffs { get; set; }
        public string description { get; set; }
        public string AreaName { get; set; }
        public string NikeNAme { get; set; }
        public decimal ClintDelivery { get; set; }
        public string code { get; set; }
        public string TitleShipping { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DescriptionClint { get; set; }
        public string Nouts { get; set; }
        public string TypesCompanies { get; set; }
        public int IdorderStatus { get; set; }
        public string dorderStatus { get; set; }
        public int IdorderCases { get; set; }
        public string dorderCases { get; set; }
        public DateOnly OrderDate { get; set; }
        public string DescriptionOrder { get; set; }
        public decimal Weight { get; set; }
        public decimal CostPrice { get; set; }
        public decimal Price { get; set; }
        public string Addres { get; set; }
        public string NoutsOrder { get; set; }
        public string? DataEntry { get; set; }
        public DateTime? DateTimeEntry { get; set; }
        public bool? CurrentState { get; set; }
        public string? ImageUser { get; set; }
        public string? IdInformationCompanies { get; set; }
        public string? NikeNAmeShipping { get; set; }



    }
}
