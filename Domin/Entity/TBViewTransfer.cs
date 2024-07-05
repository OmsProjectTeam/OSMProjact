using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewTransfer
    {
        public int IdTransfer { get; set; }
        public int IdOrderNew { get; set; }
        public decimal TransferAmount { get; set; }
        public int IdCurrency { get; set; }
        public decimal ExchangeAmount { get; set; }
        public string ReceiptNo { get; set; }
        public string DescriptionOrder { get; set; }
        public string Code { get; set; }
        public string ReceiptStatment { get; set; }
        public DateOnly ReceiptDate { get; set; }
        public string Photo { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool CurrentState { get; set; }
    }
}
