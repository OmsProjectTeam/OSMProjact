using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class TestDetail
    {
        public int Id { get; set; }

        public int? TestId { get; set; }

        public int? TestTypeId { get; set; }
    }
}
