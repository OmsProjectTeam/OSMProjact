using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class City
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public int? IsNorth { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }

        public bool CurrentState { get; set; }
    }
}
