using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBPaings
    {
        [Key]
        public string IdPaings { get; set; }
        public string IdCustomer { get; set; }
        public int IdOrderNew { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlResivedMony")]
        public decimal ResivedMony { get; set; }
        public string ReceiptImg { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlReceiptNo")]
        public string ReceiptNo { get; set; }

        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool CurrentState { get; set; }
    }
}
