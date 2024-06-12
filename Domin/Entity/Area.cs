using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class Area
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public int? CityId { get; set; }

        public int? Sector { get; set; }

        public int? Zone { get; set; }

        public int? Spec { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }

        public bool CurrentState { get; set; }
    }
}
