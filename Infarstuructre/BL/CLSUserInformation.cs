using Domin.Entity;
using Infarstuructre.Data;
using Infarstuructre.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstuructre.BL
{
	public interface IIUserInformation
	{
		List<VwUser> GetAll();
		ApplicationUser GetById(string? Id);
		List<ApplicationUser> GetAllByName(string name);
		List<VwUser> GetAllbyId(string userId);


	}
	public class CLSUserInformation: IIUserInformation
	{
		UserManager<ApplicationUser> _userManager;
		MasterDbcontext dbcontext;

		public CLSUserInformation(UserManager<ApplicationUser> userManager,MasterDbcontext dbcontext1)
        {
			_userManager=userManager;

		}
		public List<VwUser> GetAll()

		{
			//Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList(),
			List<VwUser> MySlider = dbcontext.VwUsers.OrderBy(x => x.Role).ToList(); //_userManager.Users.OrderBy(x=>x.Name).ToList()
			//List<VwUser> MySlider = dbcontext.VwUsers.OrderByDescending(n => n.Id).Where(a => a.ActiveUser == true).ToList();
			return MySlider;
		}


		public List<VwUser> GetAllbyId(string userId)

		{
			//Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList(),
			List<VwUser> MySlider = dbcontext.VwUsers.Where(x => x.Id== userId).ToList(); //_userManager.Users.OrderBy(x=>x.Name).ToList()
																					 //List<VwUser> MySlider = dbcontext.VwUsers.OrderByDescending(n => n.Id).Where(a => a.ActiveUser == true).ToList();
			return MySlider;
		}


		public List<ApplicationUser> GetAllByName(string name)

		{
			//Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList(),
			List<ApplicationUser> MySlider = _userManager.Users.Where(x => x.Email == name).ToList(); //_userManager.Users.OrderBy(x=>x.Name).ToList()
																							 //List<VwUser> MySlider = dbcontext.VwUsers.OrderByDescending(n => n.Id).Where(a => a.ActiveUser == true).ToList();
			return MySlider;
		}

		public ApplicationUser GetById(string? Id)
        {
			ApplicationUser sslid = _userManager.Users.FirstOrDefault(a => a.Id == Id);
            return sslid;
        }

	
	}
}
