using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBShippingAddresseClint
    {
        [Key]
        public int IdShippingAddresseClint { get; set; }
        public string IdUser { get; set; }
        public int IdCity { get; set; }
        public int IdArea { get; set; }
        public int IdShippingPrices { get; set; }
        public int IdCurrenciesExchangeRates { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlNearestLandmark")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength1000")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
        public string NearestLandmark { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlCoPricePerkgAbove10")]
        public decimal ClintPricePerkgUnder10 { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlClintPricePerkgAbove10")]
        public decimal ClintPricePerkgAbove10 { get; set; }
        public int IdTypeSystemDelivery { get; set; }
        public int IdCityDeliveryTariffs { get; set; }
       
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlClintPricePerkgAbove10")]
        public decimal DeliveryPriceClint { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlDescriptionAll")]
        [MaxLength(2000, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength2000")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
        public string Description { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool Active { get; set; }
        public bool CurrentState { get; set; }



    }
}
