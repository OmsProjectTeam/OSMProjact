using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
	public class TBTypesCompanies
	{
		[Key]
        public int IdTypesCompanies { get; set; }
		[Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlTypesCompanies")]
		[MaxLength(300, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength300")]
		[MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
		public string TypesCompanies { get; set; }
		public string DataEntry { get; set; }
		public DateTime DateTimeEntry { get; set; }
		public bool CurrentState { get; set; }


	}
}
