using Domin.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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
        public ChangePasswordViewModel SChangePassword { get; set; }
		public IEnumerable<RegisterViewModel> ListRegisterViewModel { get; set; }
		public IEnumerable<TBTypesCompanies> ListTypesCompanies { get; set; }
		public TBTypesCompanies TypesCompanies { get; set; }
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









    }
}
