using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBAreaDeliveryTariffs
    {
        [Key]
        public int IdAreaDeliveryTariffs { get; set; }
        public int AreaId { get; set; }
        public int IdInformationCompanies { get; set; }
        public int IdCurrenciesExchangeRates { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlTitleShipping")]
        [MaxLength(300, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength300")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
        public string TitleShipping { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlCompanyDelivery")]
        public decimal CompanyDelivery { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlClintDelivery")]
        public decimal ClintDelivery { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool CurrentState { get; set; }
    }
}
