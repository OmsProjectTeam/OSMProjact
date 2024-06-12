using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBViewAreas
    {
        public int id { get; set; }
        public int? city_id { get; set; }
        public string? City { get; set; }
        public string? Description { get; set; }
        public int? Sector { get; set; }

        public int? Zone { get; set; }

        public int? Spec { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }

        public bool CurrentState { get; set; }
    }
}
