using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBCurrenciesExchangeRates
    {
        [Key]
        public int IdCurrenciesExchangeRates { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlCountry")]
        [MaxLength(300, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength300")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
        public string Country { get; set; }     
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "Vlcode")]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength20")]
        [MinLength(1, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength1")]
        public string code { get; set; }

        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool Active { get; set; }
        public bool CurrentState { get; set; }
    }
}
