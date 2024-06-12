using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class ErrorLog
    {
        public int Id { get; set; }

        public string? Descripton { get; set; }

        public DateOnly? InsertDate { get; set; }

        public string? Sqlqry { get; set; }
    }
}
