using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewShippingAddress
    {
        public int IdShippingAddress { get; set; }
        public int IdInformationCompany { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string ShippingAddress { get; set; }
        public string Floor { get; set; }
        public string Building { get; set; }
        public string Street { get; set; }
        public string Office { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Moblie { get; set; }
        public bool Active { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public string DateEntry { get; set; }
        public bool CurrentState { get; set; }
    }
}
