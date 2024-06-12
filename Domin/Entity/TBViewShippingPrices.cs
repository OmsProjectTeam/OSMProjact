using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewShippingPrices
    {
        public int IdShipping { get; set; }
        public int IdTypeSystem { get; set; }
        public string TypeSystem { get; set; }
        public int IdInformationCompanies { get; set; }
        public string CompanyName { get; set; }
        public string NikeNAme { get; set; }
        public int IdCurrenciesExchangeRates { get; set; }
        public string Country { get; set; }
        public string code { get; set; }
        public string TitleShipping { get; set; }
        public decimal CoPricePerkgUnder10 { get; set; }
        public decimal CoPricePerkgAbove10 { get; set; }
        public decimal ClintPricePerkgUnder10 { get; set; }
        public decimal ClintPricePerkgAbove10 { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool Active { get; set; }
        public bool CurrentState { get; set; }
    }
}
