using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewCustomers
    {
        public int id { get; set; }
        public string? cust_name { get; set; }
        public string? cust_mob { get; set; }
        public string? cust_mob2 { get; set; }
        public int? cust_city { get; set; }
        public string? description { get; set; }
        public int? cust_area { get; set; }
        public string? AreaName { get; set; }
        public string? cust_landmark { get; set; }
        public DateOnly? insert_dt { get; set; }
        public int? cust_status { get; set; }
        public string? gisurl { get; set; }
        public string? hexcode { get; set; }
        public string? lat { get; set; }
        public float? lon { get; set; }
        public string? fbid { get; set; }
        public int? full_package { get; set; }
        public string? cust_profile { get; set; }
        public bool Active { get; set; }
        public bool CurrentState { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public int IdInformationCompanies { get; set; }
        public string? TypesCompanies { get; set; }
        public string? CompanyName { get; set; }
        public string? NikeNAme { get; set; }



     
    }
}
