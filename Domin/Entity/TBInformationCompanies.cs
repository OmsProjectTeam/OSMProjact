using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBInformationCompanies
    {
        [Key]
        public int IdInformationCompanies { get; set; }
        public int IdTypesCompanies { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlCompanyName")]
        [MaxLength(300, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength300")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
        public string CompanyName { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlPhoneCompany")]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength20")]
        [MinLength(5, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength5")]
        public string PhoneCompany { get; set; }
        [MaxLength(20, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength20")]
        [MinLength(5, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength5")]
        public string? PhoneCompanySecand { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlEmailCompany")]
        [MaxLength(300, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength300")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VLTypEmail")]
        public string EmailCompany { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlAddresCompany")]
        [MaxLength(300, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength300")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
        public string AddresCompany { get; set; }
        public string? Photo { get; set; }
        [MaxLength(500, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength500")]
        [MinLength(1, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength1")]
        public string? CompanyURl { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlCompanyDescription")]
        [MaxLength(2000, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength2000")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
        public string CompanyDescription { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool Active { get; set; }
        public bool CurrentState { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlNikeNAme")]
        [MaxLength(300, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength300")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
        public string NikeNAme { get; set; }

    }
}
