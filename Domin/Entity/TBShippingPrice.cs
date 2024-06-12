using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBShippingPrice
    {
        [Key]
        public int IdShipping { get; set; }
        public int IdTypeSystem { get; set; }
        public int IdInformationCompanies { get; set; }
        public int IdCurrenciesExchangeRates { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlTitleShipping")]
        [MaxLength(300, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength300")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
        public string TitleShipping { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlCoPricePerkgUnder10")]
        public decimal CoPricePerkgUnder10 { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlCoPricePerkgAbove10")]
        public decimal CoPricePerkgAbove10 { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlCoPricePerkgAbove10")]
        public decimal ClintPricePerkgUnder10 { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlClintPricePerkgAbove10")]
        public decimal ClintPricePerkgAbove10 { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool Active { get; set; }
        public bool CurrentState { get; set; }
    }
}
