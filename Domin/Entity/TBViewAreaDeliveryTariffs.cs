using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewAreaDeliveryTariffs
    {
        public int IdAreaDeliveryTariffs { get; set; }
        public int AreaId { get; set; }
        public string description { get; set; }
        public int IdInformationCompanies { get; set; }
        public string TypesCompanies { get; set; }
        public string CompanyName { get; set; }
        public string NikeNAme { get; set; }
        public int IdCurrenciesExchangeRates { get; set; }
        public string Country { get; set; }
        public string code { get; set; }
        public string TitleShipping { get; set; }
        public decimal CompanyDelivery { get; set; }
        public decimal ClintDelivery { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool CurrentState { get; set; }
    }
}
