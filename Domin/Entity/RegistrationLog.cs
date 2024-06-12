using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class RegistrationLog
    {
        public int Id { get; set; }

        public int? LabId { get; set; }

        public int? RepresentitiveId { get; set; }

        public DateOnly? InsertDate { get; set; }

        public int? RegistrationType { get; set; }

        public int? Amount { get; set; }
    }
}
