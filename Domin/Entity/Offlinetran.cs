using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class Offlinetran
    {
        public int Id { get; set; }

        public DateOnly? TransferDate { get; set; }

        public string? SqlQry { get; set; }

        public DateOnly? TranDate { get; set; }
    }
}
