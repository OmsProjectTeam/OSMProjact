using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBTransaction
    {
        [Key]
        public int IdTransaction { get; set; }
        public int FromCurrencyID { get; set; }
        public int ToCurrencyID { get; set; }
        public decimal Amount { get; set; }
        public decimal ConvertedAmount { get; set; }
        public decimal ExchangeRate { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool CurrentState { get; set; }
    }
}
