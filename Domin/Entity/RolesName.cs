﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class RolesName
    {
        public int Id { get; set; }

        public string? RoleName { get; set; }
    }
}
