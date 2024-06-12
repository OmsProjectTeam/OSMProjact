using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class User
    {
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? Userpwd { get; set; }

        public int? IsActive { get; set; }

        public int? Role { get; set; }

        public int? LabId { get; set; }

        public int? Userid { get; set; }

        public string? Loginid { get; set; }

        public DateOnly? LastLogin { get; set; }

        public int? CityId { get; set; }

        public int? AreaId { get; set; }

        public string? Phone { get; set; }

        public int? CustomerId { get; set; }

        public int? GenderId { get; set; }

        public DateOnly? EmploymentDate { get; set; }

        public int? BasicSalary { get; set; }

        public int? Transportation { get; set; }

        public DateOnly? BirthDate { get; set; }

        public int? FullPackage { get; set; }

        public int? MerchantId { get; set; }
    }
}
