using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewPaings
    {
        public int IdPaings { get; set; }
        public int IdOrderNew { get; set; }
        public string DescriptionOrder { get; set; }
        public DateOnly OrderDate { get; set; }
        public decimal ClintDelivery { get; set; }
        public string TitleShipping { get; set; }
        public string code { get; set; }
        public decimal Price { get; set; }
        public decimal NoutsOrder { get; set; }
        public decimal CatchReceiptNo { get; set; }
        public bool IsPaid { get; set; }
        public decimal ResivedMony { get; set; }
        public string Photo { get; set; }
        public string ReceiptNo { get; set; } 
        public string ReceiptStatment { get; set; }
        public DateOnly ReceiptDate { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool CurrentState { get; set; }
    }
}
