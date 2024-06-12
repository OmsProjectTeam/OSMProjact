using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewTransaction
    {
        public int IdTransaction { get; set; }
        public int FromCurrencyID { get; set; }
        public string Country { get; set; }
        public string code { get; set; }
        public int ToCurrencyID { get; set; }
        public string Countryto { get; set; }
        public string codeto { get; set; }
        public decimal Amount { get; set; }
        public decimal ConvertedAmount { get; set; }
        public decimal ExchangeRate { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool CurrentState { get; set; }
    }
}
