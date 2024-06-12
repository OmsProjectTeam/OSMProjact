using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewInformationCompanies
    {
        public int IdInformationCompanies { get; set; }
        public int IdTypesCompanies { get; set; }
        public string TypesCompanies { get; set; }
        public string CompanyName { get; set; }
        public string PhoneCompany { get; set; }
        public string? PhoneCompanySecand { get; set; }
        public string EmailCompany { get; set; }
        public string AddresCompany { get; set; }
        public string? Photo { get; set; }
        public string? CompanyURl { get; set; }
        public string CompanyDescription { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool Active { get; set; }
        public bool CurrentState { get; set; }
        public string NikeNAme { get; set; }
    }
}
