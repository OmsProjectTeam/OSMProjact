using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class Business
    {
        public int Id { get; set; }

        public string? BusinessName { get; set; }

        public string? BusinessPhone { get; set; }

        public string? Address { get; set; }

        public string? Address2 { get; set; }

        public string? City { get; set; }

        public int? StateCode { get; set; }

        public int? Zip { get; set; }

        public int? ActivityId { get; set; }

        public int? CustId { get; set; }
    }
}
