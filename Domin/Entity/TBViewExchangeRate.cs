using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewExchangeRate
    {
        public int IdExchangeRate { get; set; }
        public int IdCurrenciesExchangeRates { get; set; }
        public int ToIdCurrenciesExchangeRates { get; set; }
        public string Country { get; set; }
        public string code { get; set; }
        public string Countryto { get; set; }
        public string codeto { get; set; }
        public decimal Rate { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool CurrentState { get; set; }
    }
}
