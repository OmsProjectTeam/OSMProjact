using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class Lab
    {
        public int Id { get; set; }

        public string? Labname { get; set; }

        public DateOnly? RegistrationDate { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public int? CityId { get; set; }

        public int? DistrictId { get; set; }

        public int? RepresentitiveId { get; set; }

        public int? RegistrationType { get; set; }

        public int? CurrentStatus { get; set; }

        public int? StandardId { get; set; }

        public int? ActivationCode { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }
    }
}
