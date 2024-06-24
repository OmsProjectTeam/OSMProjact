using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewUsers
    {
        public int id { get; set; }
        public string username { get; set; }
        public string userpwd { get; set; }
        public int customer_id { get; set; }
        public string cust_name { get; set; }
        public string cust_mob { get; set; }
        public string EmailUser { get; set; }
        public string PhotoUser { get; set; }
    }
}
