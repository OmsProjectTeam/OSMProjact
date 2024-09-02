using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewShippingAddresseClint
    {
        public int IdShippingAddresseClint { get; set; }
        public string IdUser { get; set; }
        public string Name { get; set; }
        public string ImageUser { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int IdCity { get; set; }
        public string CityName { get; set; }
        public int IdArea { get; set; }
        public string AreaName { get; set; }
        public int IdShippingPrices { get; set; }
        public string NikeNAme { get; set; }
        public string Country { get; set; }
        public string code { get; set; }
        public decimal CoPricePerkgUnder10 { get; set; }
        public decimal CoPricePerkgAbove10 { get; set; }
        public decimal ClintPricePerkgUnder10 { get; set; }
        public decimal ClintPricePerkgAbove10 { get; set; }
        public int IdCurrenciesExchangeRates { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public string NearestLandmark { get; set; }
        public decimal ClintPricePerkgUnder { get; set; }
        public decimal ClintPricePerkgAbove { get; set; }
        public int IdTypeSystemDelivery { get; set; }
        public string TypeSystemDelivery { get; set; }
        public int IdCityDeliveryTariffs { get; set; }
        public string TitleShipping { get; set; }
        public string CurrencyNameDelvry { get; set; }
        public string CodeNameDelnry { get; set; }
        public decimal CompanyDelivery { get; set; }
        public decimal ClintDelivery { get; set; }


  
        public decimal DeliveryPriceClint { get; set; }
        public string Description { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool Active { get; set; }
        public bool CurrentState { get; set; }
    }
}
