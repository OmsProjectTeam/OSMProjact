using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class UsCustomer
    {
        public int Id { get; set; }

        public string? CustName { get; set; }

        public string? CustPhone { get; set; }

        public string? CustPwd { get; set; }

        public int? CustStateId { get; set; }

        public int? CustCityId { get; set; }
    }
}
