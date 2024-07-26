using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBNewsLetterSender
    {
        [Key]   
        public int IdNewsLetterSender { get; set; }
        public int IdEmailNewsletter { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlTitle")]
        [MaxLength(300, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength300")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
        public string Title { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlTitle")]
        public string AdsHtml { get; set; }

        public DateOnly dateSend { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public string DateEntry { get; set; }
        public bool CurrentState { get; set; }
    }
}
