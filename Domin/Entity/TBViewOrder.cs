using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
	public class TBViewOrder
	{
        public int id { get; set; }
        public DateOnly? order_dt { get; set; }
        public int? order_owner { get; set; }
        public string? cust_name { get; set; }
        public string? cust_mob { get; set; }
        public string? cust_mob2 { get; set; }
        public string? description { get; set; }
        public string? AreaName { get; set; }
        public string? cust_landmark { get; set; }
        public int? with_delivery { get; set; }

        public int? delivery_charges { get; set; }
        public string? notes { get; set; }
        public int? order_status { get; set; }
        public string? OrderStatus { get; set; }
        public int? role { get; set; }
      public string? receipt_no { get; set; }
        public DateOnly? receipt_dt { get; set; }
        public int? user_id { get; set; }
        public int? BatchID { get; set; }
        public int? service_charges { get; set; }
        public int? netrevenue { get; set; }
        public int? deliveryCollectedBy { get; set; }
        public int? assymbly_charges { get; set; }
        public int? assymbly_collected_by { get; set; }
        public int? deliveryCleared { get; set; }
        public int? assymblyCleared { get; set; }
        public string? delivery_notes { get; set; }
        public int? order_case_id { get; set; }
        public string? OrderCase { get; set; }
        public string? hxcode { get; set; }
        public DateTime? smsnotification_dt { get; set; }
        public int? task_status_id { get; set; }
        public string? TaskStatus { get; set; }
        public int? finance_status { get; set; }
        public int? closed { get; set; }
        public int? totalqty { get; set; }
        public int? NetAmount { get; set; }
        public DateTime? booking_dt { get; set; }
        public DateTime? delivery_dt { get; set; }
        public int? online_order { get; set; }
        public int? fully_package { get; set; }
        public int? merchant_id { get; set; }
        public string? Merchant_name { get; set; }
        public string? merchant_mob { get; set; }
        public decimal? booking_source { get; set; }
        public int? bonusIQ { get; set; }
        public int? last_before_status_id { get; set; }
        public int? advance_payment { get; set; }
        public int? agent_user_id { get; set; }
        public int? collected { get; set; }
        public int? transferred { get; set; }
        public int? source { get; set; }
        public int? financ_adj { get; set; }
        public int? collected_by_owner { get; set; }
        public int? admin_bonus { get; set; }
        public int? with_agent { get; set; }
        public int? admin_adj { get; set; }
        public int? sort_fees_adj { get; set; }
        public int? comp_sort_adj { get; set; }
        public int? local_delivery_adj { get; set; }
        public int? comp_delivery_adj { get; set; }
        public DateTime? actual_delivery_dt { get; set; }
        public int? aliexbatchid { get; set; }
        public int? returned { get; set; }
        public int? with_agent_id { get; set; }
        public DateTime? pickup_dt { get; set; }
        public int? task_with_agent_id { get; set; }
        public DateTime? collection_dt { get; set; }
        public DateTime? close_acknoledge_dt { get; set; }
        public int? linked_adv_norder_no { get; set; }
        public int? bonus_deduct { get; set; }
        public int? deduct_progressed { get; set; }
        public int? branch_id { get; set; }
        public int? to_warehouse { get; set; }
        public int? city_receipt { get; set; }
        public int? page_return_arrange { get; set; }
        public int? acknoledged { get; set; }
        public string? price_log { get; set; }
        public int? adv_order { get; set; }
        public DateOnly? collection_adjustment_dt { get; set; }
        public int? is_credit { get; set; }
        public DateOnly? return_dt { get; set; }
        public int? pre_close { get; set; }
        public int? cenrtral_bank_price { get; set; }
        public bool? Active { get; set; }
		public bool? CurrentState { get; set; }
		public string? DataEntry { get; set; }
		public DateTime? DateTimeEntry { get; set; }
		public int? IdInformationCompanies { get; set; }
		public string? NikeNAme { get; set; }
	}
}
