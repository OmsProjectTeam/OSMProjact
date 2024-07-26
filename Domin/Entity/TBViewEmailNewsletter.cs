using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewEmailNewsletter
    {
        public int IdEmailNewsletter { get; set; }
        public string IdUser { get; set; }
        public string Name { get; set; }
        public string ImageUser { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly SubscriptionDate { get; set; }
        public bool IsSubscribed { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public string DateEntry { get; set; }
        public bool CurrentState { get; set; }
    }
}
