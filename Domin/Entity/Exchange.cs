using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class Exchange
    {
        public int Id { get; set; }

        public string? ExchangeRate { get; set; }

        public string? OldRate { get; set; }

        public string? Managerno { get; set; }

        public string? BankRate { get; set; }
    }
}
