using Domin.Entity;
using Domin.Resource;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstuructre.ViewModel
{
	public class ViewmMODeElMASTER
	{
		public returnUrl returnUrl { get; set; }
        public IEnumerable<IdentityRole> ListIdentityRole { get; set; }
        public IdentityRole? sIdentityRole { get; set; } 
        public IEnumerable<VwUser> ListVwUser { get; set; }
        public IEnumerable<ApplicationUser> ListlicationUser { get; set; }
        public VwUser sVwUser { get; set; }
        public ApplicationUser sUser { get; set; }
        public RegisterViewModel ruser { get; set; }
        public NewRegister SNewRegister { get; set; }
		public IEnumerable<RegisterViewModel> ListRegisterViewModel { get; set; }
		public IEnumerable<NewRegister> ListNewRegister { get; set; }
		public ChangePasswordViewModel SChangePassword { get; set; }
        public IEnumerable<TBViewInformationCompanies> ListViewInformationCompanies { get; set; }
		public TBInformationCompanies InformationCompanies { get; set; } 
        public IEnumerable<City> ListCity { get; set; }
		public City City { get; set; }
        public IEnumerable<TBTypeSystem> ListTypeSystem { get; set; }
		public TBTypeSystem TypeSystem { get; set; }     
        public IEnumerable<TBCurrenciesExchangeRates> ListCurrenciesExchangeRates { get; set; }
		public TBCurrenciesExchangeRates CurrenciesExchangeRates { get; set; } 
       public IEnumerable<TBViewExchangeRate> ListViewExchangeRate { get; set; }
		public TBExchangeRate ExchangeRate { get; set; }
        public IEnumerable<TBViewTransaction> ListViewTransaction { get; set; }
        public TBTransaction Transaction { get; set; }   
        public IEnumerable<TBViewShippingPrices> ListViewShippingPrices { get; set; }
        public TBShippingPrice ShippingPrice { get; set; }
        public IEnumerable<TBViewAreas> ListViewAreas { get; set; }
        public Area Area { get; set; }
        public IEnumerable<TBViewCityDeliveryTariffs> ListViewCityDeliveryTariffs { get; set; }
        public TBCityDeliveryTariffs CityDeliveryTariffs { get; set; }  
        public IEnumerable<TBViewCustomers> ListViewCustomers { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<TBViewMerchant> ListViewMerchant { get; set; }
        public Merchant Merchant { get; set; }  
        public IEnumerable<OrderCase> ListOrderCase { get; set; }
        public OrderCase OrderCase { get; set; } 
       public IEnumerable<RolesName> ListRolesName { get; set; }
        public RolesName RolesName { get; set; }   
        public IEnumerable<TBViewOrderStatus> ListViewOrderStatus { get; set; }
        public OrderStatus OrderStatus { get; set; }  
        public IEnumerable<TaskStatus> ListTaskStatus { get; set; }
        public TaskStatus TaskStatus { get; set; } 
        public IEnumerable<TBViewOrder> ListViewOrder { get; set; }
        public Order Order { get; set; }
        public IEnumerable<TBTypeSystemDelivery> ListTypeSystemDelivery { get; set; }
        public TBTypeSystemDelivery TypeSystemDelivery { get; set; } 
        public IEnumerable<TBViewClintWitheDeliveryTariffs> ListViewClintWitheDeliveryTariffs { get; set; }
        public TBClintWitheDeliveryTariffs ClintWitheDeliveryTariffs { get; set; }  
        public IEnumerable<TBViewOrderNew> ListViewOrderNew { get; set; }
        public TBOrderNew OrderNew { get; set; }
        public IEnumerable<TBViewUsers> ListViewUsers { get; set; }
		public string UserName { get; set; }
		public string UserId { get; set; }
		public string UserImage { get; set; }
		public string Name { get; set; }
		public string UserRole { get; set; }
		public NewRegister NewRegister { get; set; }
		public string Id { get; set; }
		public string RoleName { get; set; }
		public string Email { get; set; }
		public string? ImageUser { get; set; }
		public bool ActiveUser { get; set; }
		public string Password { get; set; }
		public string ComparePassword { get; set; }
		public string userName { get; set; }
		public string PhoneNumber { get; set; }	
		public bool Rememberme { get; set; }
		public List<IdentityRole> Roles { get; set; }
		public List<VwUser> Users { get; set; }

        public IEnumerable<TBTypesCompanies> ListTypesCompanies { get; set; }
        public TBTypesCompanies TypesCompanies { get; set; }
        public IEnumerable<TBViewPaings> ListViewPaings { get; set; }
        public TBPaing Paing { get; set; }
    }
}
