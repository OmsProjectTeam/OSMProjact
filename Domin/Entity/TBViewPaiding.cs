using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewPaiding
    {
        public int IdPaings { get; set; }
        public string CustomerName { get; set; }
        public int IdOrderNew { get; set; }
        public decimal ResivedMony { get; set; }
        public string ReceiptImg { get; set; }
        public string ReceiptNo { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool CurrentState { get; set; }
    }
}
