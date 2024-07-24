﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
	public class TBTypesOfRequest
	{
		[Key]	
        public int IdTypesOfRequest { get; set; }
		[Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlTypesOfRequest")]
		[MaxLength(300, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength300")]
		[MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
		public string TypesOfRequest { get; set; }
		public string DataEntry { get; set; }
		public DateTime DateTimeEntry { get; set; }
		public bool CurrentState { get; set; }
		public bool Active { get; set; }

	}
}
