using Domin.Entity;
using Domin.Entity.SignalR;
using Infarstuructre.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace Infarstuructre.Data
{
	public class MasterDbcontext : IdentityDbContext<ApplicationUser>
	{
		public MasterDbcontext(DbContextOptions<MasterDbcontext> options) : base(options)
		{

		}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //***********************************************************


            builder.Entity<VwUser>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("VwUsers");
            });
            builder.Entity<VwMostwanted>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("vw_mostwanted");
            });

            //************************************************************
            builder.Entity<TBViewExchangeRate>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViewExchangeRate");
            });

            //************************************************************

            builder.Entity<TBViewInformationCompanies>(entity =>
        {
            entity.HasNoKey();
            entity.ToView("ViewInformationCompanies");
        });

            //************************************************************
            //************************************************************

            builder.Entity<TBViewTransaction>(entity =>
        {
            entity.HasNoKey();
            entity.ToView("ViewTransaction");
        });

            //************************************************************
            //************************************************************

            builder.Entity<TBViewShippingPrices>(entity =>
        {
            entity.HasNoKey();
            entity.ToView("ViewShippingPrices");
        });

            //************************************************************   
            //************************************************************

            builder.Entity<TBViewAreas>(entity =>
        {
            entity.HasNoKey();
            entity.ToView("ViewAreas");
        });

            //************************************************************   
            //************************************************************

            builder.Entity<TBViewCityDeliveryTariffs>(entity =>
        {
            entity.HasNoKey();
            entity.ToView("ViewCityDeliveryTariffs");
        });

            //************************************************************


            builder.Entity<TBViewCustomers>(entity =>
        {
            entity.HasNoKey();
            entity.ToView("ViewCustomers");
        });

            //************************************************************


            builder.Entity<TBViewMerchant>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViewMerchant");
            });

            //************************************************************
            //************************************************************


            builder.Entity<TBViewOrder>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViewOrder");
            });

            //************************************************************
            //************************************************************


            builder.Entity<TBViewOrderStatus>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViewOrderStatus");
            });

            //************************************************************
            //************************************************************


            builder.Entity<TBViewClintWitheDeliveryTariffs>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViewClintWitheDeliveryTariffs");
            });

            //************************************************************    
            //************************************************************


            builder.Entity<TBViewOrderNew>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViewOrderNew");
            });

            //************************************************************


            builder.Entity<TBViewUsers>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViewUsers");
            });

            //************************************************************
            builder.Entity<TBViewPaings>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViewPaings");
            });
            //************************************************************

            //************************************************************
            builder.Entity<TBViewTransfer>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViewTransfer");
            });
            //************************************************************
            //************************************************************
            builder.Entity<TBViewShippingAddress>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViewShippingAddress");
            });
            //************************************************************
            //************************************************************
            builder.Entity<TBViewFAQDescription>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViewFAQDescription");
            });
            //************************************************************
            //************************************************************
            builder.Entity<TBViewCustomerMessages>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViewCustomerMessages");
            });
            //************************************************************

            //************************************************************
            builder.Entity<TBViewFAQList>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViewFAQList");
            });
            //************************************************************
            //************************************************************
            builder.Entity<TBViewChatMessage>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViewChat");
            });
            //************************************************************

            builder.UseCollation("Arabic_CI_AS");

            builder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.AccountName)
                    .HasMaxLength(50)
                    .HasColumnName("accountName");
                entity.Property(e => e.IsActive).HasColumnName("isActive");
            });

            builder.Entity<AccountBox>(entity =>
            {
                entity.ToTable("AccountBox");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.BatchId).HasColumnName("batchID");
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
                entity.Property(e => e.NotCollected).HasColumnName("not_collected");
                entity.Property(e => e.Notes)
                    .HasMaxLength(500)
                    .HasColumnName("notes");
                entity.Property(e => e.OrderNo).HasColumnName("order_no");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.SpentCategory).HasColumnName("spent_category");
                entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");
                entity.Property(e => e.TransactionType).HasColumnName("transaction_type");
            });

            builder.Entity<Activity>(entity =>
            {
                entity.HasKey(e => e.ActivityId).HasName("PK_test_activities");

                entity.Property(e => e.ActivityId).HasColumnName("activityID");
                entity.Property(e => e.ActivityName)
                    .HasMaxLength(50)
                    .HasColumnName("activityName");
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            });

            builder.Entity<Aliexbatch>(entity =>
            {
                entity.ToTable("aliexbatch");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.BatchStatus).HasColumnName("batch_status");
                entity.Property(e => e.InsertDt)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("insert_dt");
                entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
            });

            builder.Entity<Area>(entity =>
            {
                entity.ToTable("areas");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CityId).HasColumnName("city_id");
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");
                entity.Property(e => e.Sector).HasColumnName("sector");
                entity.Property(e => e.Spec).HasColumnName("spec");
                entity.Property(e => e.Zone).HasColumnName("zone");
            });

            builder.Entity<Batch>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Adjusted).HasColumnName("adjusted");
                entity.Property(e => e.BatchName).HasMaxLength(50);
                entity.Property(e => e.BatchStatus).HasColumnName("batch_status");
                entity.Property(e => e.BatchUsvalue).HasColumnName("batchUSValue");
                entity.Property(e => e.Cbm).HasColumnName("CBM");
                entity.Property(e => e.CityId)
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasColumnName("city_id");
                entity.Property(e => e.FinanceDt).HasColumnName("finance_dt");
                entity.Property(e => e.Financed).HasColumnName("financed");
                entity.Property(e => e.InsertDt).HasColumnName("insert_dt");
                entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
                entity.Property(e => e.ShippingCompanyId).HasColumnName("ShippingCompanyID");
            });

            builder.Entity<BatchStatus>(entity =>
            {
                entity.ToTable("batch_status");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .HasColumnName("description");
            });

            builder.Entity<Business>(entity =>
            {
                entity.ToTable("business");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ActivityId).HasColumnName("activity_id");
                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");
                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .HasColumnName("address2");
                entity.Property(e => e.BusinessName)
                    .HasMaxLength(50)
                    .HasColumnName("Business_name");
                entity.Property(e => e.BusinessPhone)
                    .HasMaxLength(50)
                    .HasColumnName("business_phone");
                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");
                entity.Property(e => e.CustId).HasColumnName("cust_id");
                entity.Property(e => e.StateCode).HasColumnName("state_code");
                entity.Property(e => e.Zip).HasColumnName("zip");
            });

            builder.Entity<BusinessArea>(entity =>
            {
                entity.ToTable("business_areas");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.BusinessId).HasColumnName("business_id");
                entity.Property(e => e.CityId).HasColumnName("city_id");
            });

            builder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId).HasName("PK_test_categories");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            builder.Entity<City>(entity =>
            {
                entity.ToTable("cities");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");
                entity.Property(e => e.IsNorth).HasColumnName("isNorth");
            });

            builder.Entity<Clinic>(entity =>
            {
                entity.ToTable("clinics");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            builder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CustArea).HasColumnName("cust_area");
                entity.Property(e => e.CustCity).HasColumnName("cust_city");
                entity.Property(e => e.CustLandmark)
                    .HasMaxLength(150)
                    .HasColumnName("cust_landmark");
                entity.Property(e => e.CustMob)
                    .HasMaxLength(15)
                    .HasColumnName("cust_mob");
                entity.Property(e => e.CustMob2)
                    .HasMaxLength(15)
                    .HasColumnName("cust_mob2");
                entity.Property(e => e.CustName)
                    .HasMaxLength(150)
                    .HasColumnName("cust_name");
                entity.Property(e => e.CustProfile)
                    .HasMaxLength(300)
                    .HasColumnName("cust_profile");
                entity.Property(e => e.CustStatus).HasColumnName("cust_status");
                entity.Property(e => e.Fbid)
                    .HasMaxLength(50)
                    .HasColumnName("fbid");
                entity.Property(e => e.FullPackage).HasColumnName("full_package");
                entity.Property(e => e.Gisurl)
                    .HasMaxLength(50)
                    .HasColumnName("gisurl");
                entity.Property(e => e.Hexcode)
                    .HasMaxLength(50)
                    .HasColumnName("hexcode");
                entity.Property(e => e.InsertDt).HasColumnName("insert_dt");
                entity.Property(e => e.Lat)
                    .HasMaxLength(150)
                    .HasColumnName("lat");
                entity.Property(e => e.Lon).HasColumnName("lon");
            });

            builder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            builder.Entity<ErrorLog>(entity =>
            {
                entity.ToTable("error_log");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Descripton).HasColumnName("descripton");
                entity.Property(e => e.InsertDate).HasColumnName("insert_date");
                entity.Property(e => e.Sqlqry).HasColumnName("sqlqry");
            });

            builder.Entity<Exchange>(entity =>
            {
                entity.ToTable("exchange");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.BankRate)
                    .HasMaxLength(50)
                    .HasColumnName("bank_rate");
                entity.Property(e => e.ExchangeRate)
                    .HasMaxLength(50)
                    .HasColumnName("exchange_rate");
                entity.Property(e => e.Managerno)
                    .HasMaxLength(50)
                    .HasColumnName("managerno");
                entity.Property(e => e.OldRate)
                    .HasMaxLength(50)
                    .HasColumnName("old_rate");
            });

            builder.Entity<IncomeBox>(entity =>
            {
                entity.ToTable("income_box");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.Cleared).HasColumnName("cleared");
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");
                entity.Property(e => e.InsertDt).HasColumnName("insert_dt");
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
                entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
                entity.Property(e => e.OrderNo).HasColumnName("order_no");
                entity.Property(e => e.TransactionType).HasColumnName("transaction_type");
            });

            builder.Entity<Item>(entity =>
            {
                entity.ToTable("items");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ArDesc)
                    .HasMaxLength(150)
                    .HasColumnName("AR_DESC");
                entity.Property(e => e.Assymbly).HasColumnName("assymbly");
                entity.Property(e => e.Comb).HasColumnName("comb");
                entity.Property(e => e.Cost).HasColumnName("cost");
                entity.Property(e => e.EngName)
                    .HasMaxLength(50)
                    .HasColumnName("eng_name");
                entity.Property(e => e.Fr)
                    .HasMaxLength(50)
                    .HasColumnName("FR");
                entity.Property(e => e.H).HasColumnName("h");
                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(250)
                    .HasColumnName("img_url");
                entity.Property(e => e.L).HasColumnName("l");
                entity.Property(e => e.PCode)
                    .HasMaxLength(50)
                    .HasColumnName("p_code");
                entity.Property(e => e.SitePrice)
                    .HasColumnType("money")
                    .HasColumnName("site_price");
                entity.Property(e => e.SubId).HasColumnName("sub_id");
                entity.Property(e => e.W).HasColumnName("w");
                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            builder.Entity<ItemStatus>(entity =>
            {
                entity.ToTable("item_status");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");
            });

            builder.Entity<Jobtask>(entity =>
            {
                entity.ToTable("jobtask");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.BatchId).HasColumnName("BatchID");
                entity.Property(e => e.Cleared).HasColumnName("cleared");
                entity.Property(e => e.Description)
                    .HasMaxLength(450)
                    .HasColumnName("description");
                entity.Property(e => e.EndDt).HasColumnName("end_dt");
                entity.Property(e => e.IqCharges).HasColumnName("iqCharges");
                entity.Property(e => e.OrderNo).HasColumnName("order_no");
                entity.Property(e => e.ServiceId).HasColumnName("service_id");
                entity.Property(e => e.StartDt).HasColumnName("start_dt");
                entity.Property(e => e.TaskOwnerId).HasColumnName("task_owner_id");
                entity.Property(e => e.TaskStatus).HasColumnName("task_status");
            });

            builder.Entity<Lab>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ActivationCode).HasColumnName("activation_code");
                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");
                entity.Property(e => e.CityId).HasColumnName("city_id");
                entity.Property(e => e.CurrentStatus).HasColumnName("current_status");
                entity.Property(e => e.DistrictId).HasColumnName("district_id");
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");
                entity.Property(e => e.Labname)
                    .HasMaxLength(50)
                    .HasColumnName("labname");
                entity.Property(e => e.Latitude).HasColumnType("numeric(18, 6)");
                entity.Property(e => e.Longitude).HasColumnType("numeric(18, 6)");
                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");
                entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");
                entity.Property(e => e.RegistrationType).HasColumnName("registration_type");
                entity.Property(e => e.RepresentitiveId).HasColumnName("representitive_id");
                entity.Property(e => e.StandardId).HasColumnName("standard_id");
            });

            builder.Entity<ListPrice>(entity =>
            {
                entity.ToTable("list_price");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.LabId).HasColumnName("lab_id");
                entity.Property(e => e.Pricing).HasColumnName("pricing");
                entity.Property(e => e.SampleId).HasColumnName("sample_id");
            });

            builder.Entity<Merchant>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_patient");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Bgw).HasColumnName("bgw");
                entity.Property(e => e.Branch).HasColumnName("branch");
                entity.Property(e => e.Bypass).HasColumnName("bypass");
                entity.Property(e => e.Cities).HasColumnName("cities");
                entity.Property(e => e.CityId).HasColumnName("city_id");
                entity.Property(e => e.Credit).HasColumnName("credit");
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.Property(e => e.Hidden).HasColumnName("hidden");
                entity.Property(e => e.IsPublic).HasColumnName("isPublic");
                entity.Property(e => e.MerchantMob)
                    .HasMaxLength(50)
                    .HasColumnName("merchant_mob");
                entity.Property(e => e.MerchantName)
                    .HasMaxLength(50)
                    .HasColumnName("Merchant_name");
                entity.Property(e => e.Outskirts)
                    .HasColumnType("money")
                    .HasColumnName("outskirts");
                entity.Property(e => e.SmsAlert).HasColumnName("sms_alert");
                entity.Property(e => e.Sorting).HasColumnName("sorting");
                entity.Property(e => e.UsDelivery).HasColumnName("US_delivery");
                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            builder.Entity<NeighberLab>(entity =>
            {
                entity.ToTable("neighberLabs");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.LabId).HasColumnName("labID");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            builder.Entity<Offlinetran>(entity =>
            {
                entity.ToTable("offlinetrans");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.SqlQry)
                    .HasMaxLength(900)
                    .HasColumnName("sql_qry");
                entity.Property(e => e.TranDate).HasColumnName("tran_date");
                entity.Property(e => e.TransferDate).HasColumnName("transfer_date");
            });

            builder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Acknoledged).HasColumnName("acknoledged");
                entity.Property(e => e.ActualDeliveryDt)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("actual_delivery_dt");
                entity.Property(e => e.AdminAdj).HasColumnName("admin_adj");
                entity.Property(e => e.AdminBonus).HasColumnName("admin_bonus");
                entity.Property(e => e.AdvOrder).HasColumnName("adv_order");
                entity.Property(e => e.AdvancePayment).HasColumnName("advance_payment");
                entity.Property(e => e.AgentUserId).HasColumnName("agent_user_id");
                entity.Property(e => e.Aliexbatchid).HasColumnName("aliexbatchid");
                entity.Property(e => e.AssymblyCharges).HasColumnName("assymbly_charges");
                entity.Property(e => e.AssymblyCleared).HasColumnName("assymblyCleared");
                entity.Property(e => e.AssymblyCollectedBy).HasColumnName("assymbly_collected_by");
                entity.Property(e => e.BatchId).HasColumnName("BatchID");
                entity.Property(e => e.BonusDeduct).HasColumnName("bonus_deduct");
                entity.Property(e => e.BonusIq).HasColumnName("bonusIQ");
                entity.Property(e => e.BookingDt)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("booking_dt");
                entity.Property(e => e.BookingSource)
                    .HasColumnType("money")
                    .HasColumnName("booking_source");
                entity.Property(e => e.BranchId).HasColumnName("branch_id");
                entity.Property(e => e.CenrtralBankPrice).HasColumnName("cenrtral_bank_price");
                entity.Property(e => e.CityReceipt).HasColumnName("city_receipt");
                entity.Property(e => e.CloseAcknoledgeDt)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("close_acknoledge_dt");
                entity.Property(e => e.Closed).HasColumnName("closed");
                entity.Property(e => e.Collected).HasColumnName("collected");
                entity.Property(e => e.CollectedByOwner).HasColumnName("collected_by_owner");
                entity.Property(e => e.CollectionAdjustmentDt).HasColumnName("collection_adjustment_dt");
                entity.Property(e => e.CollectionDt)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("collection_dt");
                entity.Property(e => e.CompDeliveryAdj).HasColumnName("comp_delivery_adj");
                entity.Property(e => e.CompSortAdj).HasColumnName("comp_sort_adj");
                entity.Property(e => e.DeductProgressed).HasColumnName("deduct_progressed");
                entity.Property(e => e.DeliveryCharges).HasColumnName("delivery_charges");
                entity.Property(e => e.DeliveryCleared).HasColumnName("deliveryCleared");
                entity.Property(e => e.DeliveryCollectedBy).HasColumnName("deliveryCollectedBy");
                entity.Property(e => e.DeliveryDt)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("delivery_dt");
                entity.Property(e => e.DeliveryNotes)
                    .HasMaxLength(250)
                    .HasColumnName("delivery_notes");
                entity.Property(e => e.FinancAdj).HasColumnName("financ_adj");
                entity.Property(e => e.FinanceStatus).HasColumnName("finance_status");
                entity.Property(e => e.FullyPackage).HasColumnName("fully_package");
                entity.Property(e => e.Hxcode)
                    .HasMaxLength(50)
                    .HasColumnName("hxcode");
                entity.Property(e => e.IsCredit).HasColumnName("is_credit");
                entity.Property(e => e.LastBeforeStatusId).HasColumnName("last_before_status_id");
                entity.Property(e => e.LinkedAdvNorderNo).HasColumnName("linked_adv_norder_no");
                entity.Property(e => e.LocalDeliveryAdj).HasColumnName("local_delivery_adj");
                entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
                entity.Property(e => e.Netrevenue).HasColumnName("netrevenue");
                entity.Property(e => e.Notes)
                    .HasMaxLength(650)
                    .HasColumnName("notes");
                entity.Property(e => e.OnlineOrder).HasColumnName("online_order");
                entity.Property(e => e.OrderCaseId).HasColumnName("order_case_id");
                entity.Property(e => e.OrderDt).HasColumnName("order_dt");
                entity.Property(e => e.OrderOwner).HasColumnName("order_owner");
                entity.Property(e => e.OrderStatus).HasColumnName("order_status");
                entity.Property(e => e.PageReturnArrange).HasColumnName("page_return_arrange");
                entity.Property(e => e.PickupDt)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("pickup_dt");
                entity.Property(e => e.PreClose).HasColumnName("pre_close");
                entity.Property(e => e.PriceLog)
                    .HasMaxLength(300)
                    .HasColumnName("price_log");
                entity.Property(e => e.ReceiptDt).HasColumnName("receipt_dt");
                entity.Property(e => e.ReceiptNo)
                    .HasMaxLength(50)
                    .HasColumnName("receipt_no");
                entity.Property(e => e.ReturnDt).HasColumnName("return_dt");
                entity.Property(e => e.Returned).HasColumnName("returned");
                entity.Property(e => e.ServiceCharges).HasColumnName("service_charges");
                entity.Property(e => e.SmsnotificationDt)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("smsnotification_dt");
                entity.Property(e => e.SortFeesAdj).HasColumnName("sort_fees_adj");
                entity.Property(e => e.Source).HasColumnName("source");
                entity.Property(e => e.TaskStatusId).HasColumnName("task_status_id");
                entity.Property(e => e.TaskWithAgentId).HasColumnName("task_with_agent_id");
                entity.Property(e => e.ToWarehouse).HasColumnName("to_warehouse");
                entity.Property(e => e.Totalqty).HasColumnName("totalqty");
                entity.Property(e => e.Transferred).HasColumnName("transferred");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.WithAgent).HasColumnName("with_agent");
                entity.Property(e => e.WithAgentId).HasColumnName("with_agent_id");
                entity.Property(e => e.WithDelivery).HasColumnName("with_delivery");
            });

            builder.Entity<OrderCase>(entity =>
            {
                entity.ToTable("order_cases");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .HasColumnName("description");
            });

            builder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("order_details");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Adjusted).HasColumnName("adjusted");
                entity.Property(e => e.BonusUs).HasColumnName("bonusUS");
                entity.Property(e => e.BookingDt)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("booking_dt");
                entity.Property(e => e.CollectionFeesIq).HasColumnName("collection_feesIQ");
                entity.Property(e => e.DeliveryFeesIq).HasColumnName("Delivery_feesIQ");
                entity.Property(e => e.FinanceStatus).HasColumnName("finance_status");
                entity.Property(e => e.InsertDt)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("insert_dt");
                entity.Property(e => e.ItemCode).HasColumnName("item_code");
                entity.Property(e => e.Missing).HasColumnName("missing");
                entity.Property(e => e.Notes)
                    .HasMaxLength(50)
                    .HasColumnName("notes");
                entity.Property(e => e.OnlineOrder).HasColumnName("online_order");
                entity.Property(e => e.OrderId)
                    .HasMaxLength(50)
                    .HasColumnName("OrderID");
                entity.Property(e => e.OrderNo).HasColumnName("order_no");
                entity.Property(e => e.OriginalAmount).HasColumnName("original_amount");
                entity.Property(e => e.PageReturn).HasColumnName("page_return");
                entity.Property(e => e.Preorder).HasColumnName("preorder");
                entity.Property(e => e.Qty).HasColumnName("qty");
                entity.Property(e => e.Removed).HasColumnName("removed");
                entity.Property(e => e.Returned).HasColumnName("returned");
                entity.Property(e => e.Size).HasColumnName("size");
                entity.Property(e => e.Sorted).HasColumnName("sorted");
                entity.Property(e => e.SourcePrice).HasColumnName("source_price");
                entity.Property(e => e.TaskStatusId).HasColumnName("task_status_id");
                entity.Property(e => e.TempMissing).HasColumnName("temp_missing");
                entity.Property(e => e.TrackingNo)
                    .HasMaxLength(50)
                    .HasColumnName("tracking_no");
                entity.Property(e => e.Value).HasColumnName("value");
                entity.Property(e => e.ValueCleared).HasColumnName("valueCleared");
                entity.Property(e => e.ValueCollecedBy).HasColumnName("valueCollecedBy");
                entity.Property(e => e.WebsitePrice)
                    .HasColumnType("money")
                    .HasColumnName("website_price");
                entity.Property(e => e.Whs).HasColumnName("whs");
                entity.Property(e => e.WhsBatchId).HasColumnName("whs_batch_id");
                entity.Property(e => e.Whsid).HasColumnName("whsid");
            });

            builder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("order_status");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .HasColumnName("description");
                entity.Property(e => e.Role).HasColumnName("role");
            });

            builder.Entity<PracePercentage>(entity =>
            {
                entity.ToTable("prace_percentage");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ClinicId).HasColumnName("clinic_id");
                entity.Property(e => e.Percentage).HasColumnName("percentage");
                entity.Property(e => e.SampleId).HasColumnName("sample_id");
            });

            builder.Entity<Preorder>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("preorders");

                entity.Property(e => e.CustId).HasColumnName("cust_id");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.InsertDate).HasColumnName("insert_date");
                entity.Property(e => e.OrderDate).HasColumnName("order_date");
                entity.Property(e => e.Qty).HasColumnName("qty");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.Totalamount).HasColumnName("totalamount");
            });

            builder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
                entity.Property(e => e.ProductName).HasMaxLength(150);
            });

            builder.Entity<RegistrationLog>(entity =>
            {
                entity.ToTable("registration_log");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.InsertDate).HasColumnName("insert_date");
                entity.Property(e => e.LabId).HasColumnName("lab_id");
                entity.Property(e => e.RegistrationType).HasColumnName("registration_type");
                entity.Property(e => e.RepresentitiveId).HasColumnName("representitive_id");
            });

            builder.Entity<RegistrationType>(entity =>
            {
                entity.ToTable("registration_types");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");
            });

            builder.Entity<Result>(entity =>
            {
                entity.ToTable("results");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.InsertDate).HasColumnName("insert_date");
                entity.Property(e => e.Notes).HasColumnName("notes");
                entity.Property(e => e.Serial).HasColumnName("serial");
                entity.Property(e => e.TestId).HasColumnName("test_id");
            });

            builder.Entity<ResultValue>(entity =>
            {
                entity.ToTable("result_values");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Notes)
                    .HasMaxLength(500)
                    .HasColumnName("notes");
                entity.Property(e => e.ResultId).HasColumnName("result_id");
                entity.Property(e => e.ResultTypeId).HasColumnName("result_type_id");
                entity.Property(e => e.Summary).HasColumnName("summary");
                entity.Property(e => e.TestId).HasColumnName("test_id");
                entity.Property(e => e.TestTypeId).HasColumnName("test_type_id");
                entity.Property(e => e.Value1)
                    .HasMaxLength(50)
                    .HasColumnName("value_1");
            });

            builder.Entity<RolesName>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasColumnName("roleName");
            });

            builder.Entity<Sample>(entity =>
            {
                entity.ToTable("samples");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.SampleName)
                    .HasMaxLength(50)
                    .HasColumnName("sampleName");
            });

            builder.Entity<SampleCategoriesResult>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Parentid).HasColumnName("parentid");
                entity.Property(e => e.ReferenceRange)
                    .HasMaxLength(50)
                    .HasColumnName("reference_range");
                entity.Property(e => e.ResultType).HasColumnName("result_type");
                entity.Property(e => e.SampleCategoryId).HasColumnName("sample_category_id");
                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");
                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .HasColumnName("unit");
            });

            builder.Entity<SampleCategory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Parentid).HasColumnName("parentid");
                entity.Property(e => e.ReferenceRange)
                    .HasMaxLength(50)
                    .HasColumnName("reference_range");
                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");
                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .HasColumnName("unit");
            });

            builder.Entity<SampleDetail>(entity =>
            {
                entity.ToTable("sampleDetails");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");
                entity.Property(e => e.Reference)
                    .HasMaxLength(50)
                    .HasColumnName("reference");
                entity.Property(e => e.SampleId).HasColumnName("sample_id");
                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .HasColumnName("unit");
            });

            builder.Entity<SamplePrice>(entity =>
            {
                entity.ToTable("sample_price");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.LabId).HasColumnName("lab_id");
                entity.Property(e => e.PriceList).HasColumnName("price_list");
                entity.Property(e => e.SampleId).HasColumnName("sample_id");
            });

            builder.Entity<SampleStatus>(entity =>
            {
                entity.ToTable("sample_status");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");
            });

            builder.Entity<SerialNumber>(entity =>
            {
                entity.HasKey(e => e.Sno).HasName("PK__SerialNu__CA1EE04C72F5487E");

                entity.ToTable("SerialNumber");

                entity.Property(e => e.Sno)
                    .ValueGeneratedNever()
                    .HasColumnName("SNo");
            });

            builder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .HasColumnName("description");
            });

            builder.Entity<ShippingCompany>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description).HasMaxLength(50);
            });

            builder.Entity<Source>(entity =>
            {
                entity.ToTable("sources");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");
            });

            builder.Entity<Specialty>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            builder.Entity<SpendingList>(entity =>
            {
                entity.ToTable("spending_list");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");
                entity.Property(e => e.IsActive).HasColumnName("isActive");
            });

            builder.Entity<State>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Staetag)
                    .HasMaxLength(50)
                    .HasColumnName("staetag");
            });

            builder.Entity<StoreSize>(entity =>
            {
                entity.ToTable("store_size");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ItemCode).HasColumnName("item_code");
                entity.Property(e => e.SizeId).HasColumnName("size_id");
            });

            builder.Entity<Table1>(entity =>
            {
                entity.ToTable("Table_1");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ActivityId).HasColumnName("activity_id");
                entity.Property(e => e.BusinessId).HasColumnName("business_id");
            });

            builder.Entity<TaskStatus>(entity =>
            {
                entity.ToTable("task_status");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");
            });

            builder.Entity<TblConfig>(entity =>
            {
                entity.ToTable("tbl_config");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.MissingFav).HasColumnName("missing_fav");
            });

            builder.Entity<TblLog>(entity =>
            {
                entity.ToTable("tbl_log");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Pvalue).HasColumnName("pvalue");
            });

            builder.Entity<TblSize>(entity =>
            {
                entity.ToTable("tbl_size");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");
                entity.Property(e => e.GroupIndex).HasColumnName("group_index");
                entity.Property(e => e.OrderIndex).HasColumnName("order_index");
            });

            builder.Entity<Tbllat>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("tbllat");

                entity.Property(e => e.Str)
                    .HasMaxLength(50)
                    .HasColumnName("str");
            });

            builder.Entity<Tblsku>(entity =>
            {
                entity.ToTable("tblsku");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Skuurl).HasColumnName("skuurl");
            });

            builder.Entity<Test>(entity =>
            {
                entity.ToTable("tests");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
                entity.Property(e => e.InsertedBy).HasColumnName("inserted_by");
                entity.Property(e => e.LabId).HasColumnName("lab_id");
                entity.Property(e => e.PId).HasColumnName("p_id");
                entity.Property(e => e.Serial).HasColumnName("serial");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.TestDate)
                    .HasColumnType("datetime")
                    .HasColumnName("test_date");
                entity.Property(e => e.Totalcoast).HasColumnName("totalcoast");
                entity.Property(e => e.Urgent).HasColumnName("urgent");
            });

            builder.Entity<TestDetail>(entity =>
            {
                entity.ToTable("test_details");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.TestId).HasColumnName("test_id");
                entity.Property(e => e.TestTypeId).HasColumnName("test_type_id");
            });

            builder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("transaction_types");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");
            });

            builder.Entity<UsCustomer>(entity =>
            {
                entity.ToTable("usCustomer");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.CustCityId).HasColumnName("cust_city_id");
                entity.Property(e => e.CustName)
                    .HasMaxLength(50)
                    .HasColumnName("cust_name");
                entity.Property(e => e.CustPhone)
                    .HasMaxLength(50)
                    .HasColumnName("cust_phone");
                entity.Property(e => e.CustPwd)
                    .HasMaxLength(50)
                    .HasColumnName("cust_pwd");
                entity.Property(e => e.CustStateId).HasColumnName("cust_state_id");
            });

            builder.Entity<UsCustomerReview>(entity =>
            {
                entity.ToTable("usCustomer_review");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.BusinessId).HasColumnName("business_id");
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.Property(e => e.ReviewScore).HasColumnName("review_score");
            });

            builder.Entity<Uscity>(entity =>
            {
                entity.ToTable("UScities");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");
                entity.Property(e => e.StateId).HasColumnName("StateID");
            });

            builder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.AreaId).HasColumnName("area_id");
                entity.Property(e => e.BasicSalary).HasColumnName("basic_salary");
                entity.Property(e => e.BirthDate).HasColumnName("birth_date");
                entity.Property(e => e.CityId).HasColumnName("city_id");
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.Property(e => e.EmploymentDate).HasColumnName("employment_date");
                entity.Property(e => e.FullPackage).HasColumnName("full_package");
                entity.Property(e => e.GenderId).HasColumnName("gender_id");
                entity.Property(e => e.IsActive).HasColumnName("is_active");
                entity.Property(e => e.LabId).HasColumnName("lab_id");
                entity.Property(e => e.LastLogin).HasColumnName("last_login");
                entity.Property(e => e.Loginid)
                    .HasMaxLength(50)
                    .HasColumnName("loginid");
                entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");
                entity.Property(e => e.Role).HasColumnName("role");
                entity.Property(e => e.Transportation).HasColumnName("transportation");
                entity.Property(e => e.Userid).HasColumnName("userid");
                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
                entity.Property(e => e.Userpwd)
                    .HasMaxLength(50)
                    .HasColumnName("userpwd");
            });

            builder.Entity<UserMerchant>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tracking");

                entity.ToTable("user_merchant");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.MerchantId).HasColumnName("merchant_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            builder.Entity<VwMostwanted>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vw_mostwanted");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(250)
                    .HasColumnName("img_url");
                entity.Property(e => e.PCode)
                    .HasMaxLength(50)
                    .HasColumnName("p_code");
                entity.Property(e => e.SitePrice)
                    .HasColumnType("money")
                    .HasColumnName("site_price");
                entity.Property(e => e.Totalorders).HasColumnName("totalorders");
            });

            builder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("warehouse");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.BatchId).HasColumnName("BatchID");
                entity.Property(e => e.DeliveryDt).HasColumnName("delivery_dt");
                entity.Property(e => e.InsertDt).HasColumnName("insert_dt");
                entity.Property(e => e.ItemCode).HasColumnName("item_code");
                entity.Property(e => e.ItemStatus).HasColumnName("item_status");
                entity.Property(e => e.Notes)
                    .HasMaxLength(150)
                    .HasColumnName("notes");
                entity.Property(e => e.OrderNo).HasColumnName("order_no");
            });








            //----------------------------------

            builder.Entity<TBTypesCompanies>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBTypesCompanies>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------	

            //----------------------------------

            builder.Entity<TBInformationCompanies>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBInformationCompanies>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            builder.Entity<TBInformationCompanies>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");
            //---------------------------------	



            builder.Entity<TBAccountBox>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBAccountBox>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------	
            builder.Entity<TBTypeSystem>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBTypeSystem>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            builder.Entity<TBTypeSystem>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");
            //---------------------------------	
            builder.Entity<TBCurrenciesExchangeRates>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBCurrenciesExchangeRates>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            builder.Entity<TBCurrenciesExchangeRates>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");
            //---------------------------------	



            builder.Entity<TBExchangeRate>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBExchangeRate>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------	
            //---------------------------------	



            builder.Entity<TBTransaction>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBTransaction>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------	

            //---------------------------------	
            builder.Entity<TBShippingPrice>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBShippingPrice>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            builder.Entity<TBShippingPrice>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");
            //---------------------------------	

            builder.Entity<Area>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<Area>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------	
            builder.Entity<City>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<City>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------	 
            //---------------------------------	
            builder.Entity<TBCityDeliveryTariffs>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBCityDeliveryTariffs>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------	    //---------------------------------	




            //---------------------------------	
            builder.Entity<Customer>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<Customer>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            builder.Entity<Customer>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");
            //---------------------------------	
            //---------------------------------	
            builder.Entity<Merchant>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<Merchant>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            builder.Entity<Merchant>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");
            //---------------------------------	

            //---------------------------------	
            builder.Entity<Order>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<Order>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            builder.Entity<Order>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");
            //---------------------------------	
            //---------------------------------	
            builder.Entity<OrderCase>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<OrderCase>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");

            //---------------------------------	

            builder.Entity<OrderStatus>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<OrderStatus>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");

            //---------------------------------	
            //---------------------------------	

            builder.Entity<RolesName>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<RolesName>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");

            //---------------------------------	
            //---------------------------------	

            builder.Entity<TaskStatus>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TaskStatus>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");

            //---------------------------------	
            builder.Entity<TBTypeSystemDelivery>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBTypeSystemDelivery>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");

            //---------------------------------	
            //---------------------------------	
            builder.Entity<TBClintWitheDeliveryTariffs>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBClintWitheDeliveryTariffs>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");

            //---------------------------------	
            //---------------------------------	
            builder.Entity<TBOrderNew>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBOrderNew>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");

            builder.Entity<TBOrderNew>()
           .Property(b => b.IsPaid)
           .HasDefaultValueSql("((0))");
            //---------------------------------	 
            //---------------------------------	
            builder.Entity<TBPaing>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBPaing>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");

            //---------------------------------	
            //---------------------------------	
            builder.Entity<TBTransfer>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBTransfer>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");

            //--------------------------------- 
            //---------------------------------	
            builder.Entity<TBEmailAlartSetting>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBEmailAlartSetting>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            builder.Entity<TBEmailAlartSetting>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");

            //---------------------------------
            //---------------------------------	
            builder.Entity<TBShippingAddress>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBShippingAddress>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            builder.Entity<TBShippingAddress>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");

            //---------------------------------
            builder.Entity<TBTypesOfRequest>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBTypesOfRequest>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            builder.Entity<TBTypesOfRequest>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");

            //---------------------------------
            builder.Entity<TBTypesOfMessage>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBTypesOfMessage>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            builder.Entity<TBTypesOfMessage>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");

            //---------------------------------

            //---------------------------------
            builder.Entity<TBFAQ>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBFAQ>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            builder.Entity<TBFAQ>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");

            //---------------------------------

            //---------------------------------
            builder.Entity<TBFAQDescreption>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBFAQDescreption>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");

            //---------------------------------

            //---------------------------------
            builder.Entity<TBFAQList>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBFAQList>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");

            //---------------------------------
            //---------------------------------
            builder.Entity<TBCustomerMessages>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBCustomerMessages>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");

            //--------------------------------- 
            //---------------------------------
            builder.Entity<TBConnectAndDisConnect>()
            .HasNoKey();
            //---------------------------------
            builder.Entity<TBSupportTicketType>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBSupportTicketType>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");

            //--------------------------------- 

            builder.Entity<TBMessageChat>()
           .Property(m => m.MessageeTime)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBMessageChat>()
           .Property(m => m.CurrentState)
           .HasDefaultValueSql("((1))");
            builder.Entity<TBMessageChat>()
           .Property(m => m.IsRead)
           .HasDefaultValueSql("((0))");

            //--------------------------------- 
        }

        public DbSet<TBAccountBox> TBAccountBoxs { get; set; }

        public virtual DbSet<Account> accounts { get; set; }

        public virtual DbSet<AccountBox> AccountBox { get; set; }

        public virtual DbSet<Activity> Activities { get; set; }

        public virtual DbSet<Aliexbatch> aliexbatch { get; set; }

        public virtual DbSet<Area> areas { get; set; }

        public virtual DbSet<Batch> Batches { get; set; }

        public virtual DbSet<BatchStatus> batch_status { get; set; }

        public virtual DbSet<Business> business { get; set; }

        public virtual DbSet<BusinessArea> business_areas { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<City> cities { get; set; }

        public virtual DbSet<Clinic> clinics { get; set; }

        public virtual DbSet<Customer> customers { get; set; }

        public virtual DbSet<Doctor> Doctor { get; set; }

        public virtual DbSet<ErrorLog> error_log { get; set; }

        public virtual DbSet<Exchange> exchange { get; set; }

        public virtual DbSet<IncomeBox> income_box { get; set; }

        public virtual DbSet<Item> items { get; set; }

        public virtual DbSet<ItemStatus> item_status { get; set; }

        public virtual DbSet<Jobtask> jobtask { get; set; }

        public virtual DbSet<Lab> Labs { get; set; }

        public virtual DbSet<ListPrice> list_price { get; set; }

        public virtual DbSet<Merchant> Merchants { get; set; }

        public virtual DbSet<NeighberLab> neighberLabs { get; set; }

        public virtual DbSet<Offlinetran> offlinetrans { get; set; }

        public virtual DbSet<Order> orders { get; set; }

        public virtual DbSet<OrderCase> order_cases { get; set; }

        public virtual DbSet<OrderDetail> order_details { get; set; }

        public virtual DbSet<OrderStatus> order_status { get; set; }

        public virtual DbSet<PracePercentage> prace_percentage { get; set; }

        public virtual DbSet<Preorder> preorders { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<RegistrationLog> registration_log { get; set; }

        public virtual DbSet<RegistrationType> registration_types { get; set; }

        public virtual DbSet<Result> results { get; set; }

        public virtual DbSet<ResultValue> result_values { get; set; }

        public virtual DbSet<RolesName> RolesNames { get; set; }

        public virtual DbSet<Sample> samples { get; set; }

        public virtual DbSet<SampleCategoriesResult> SampleCategoriesResults { get; set; }

        public virtual DbSet<SampleCategory> SampleCategories { get; set; }

        public virtual DbSet<SampleDetail> sampleDetails { get; set; }

        public virtual DbSet<SamplePrice> sample_price { get; set; }

        public virtual DbSet<SampleStatus> sample_status { get; set; }

        public virtual DbSet<SerialNumber> SerialNumber { get; set; }

        public virtual DbSet<Service> services { get; set; }

        public virtual DbSet<ShippingCompany> ShippingCompanies { get; set; }

        public virtual DbSet<Source> sources { get; set; }

        public virtual DbSet<Specialty> Specialties { get; set; }

        public virtual DbSet<SpendingList> spending_list { get; set; }

        public virtual DbSet<State> States { get; set; }

        public virtual DbSet<StoreSize> store_size { get; set; }

        public virtual DbSet<Table1> Table_1 { get; set; }

        public virtual DbSet<TaskStatus> task_status { get; set; }

        public virtual DbSet<TblConfig> tbl_config { get; set; }

        public virtual DbSet<TblLog> tbl_log { get; set; }

        public virtual DbSet<TblSize> tbl_size { get; set; }

        public virtual DbSet<Tbllat> tbllat { get; set; }

        public virtual DbSet<Tblsku> tblsku { get; set; }

        public virtual DbSet<Test> tests { get; set; }

        public virtual DbSet<TestDetail> test_details { get; set; }

        public virtual DbSet<TransactionType> transaction_types { get; set; }

        public virtual DbSet<UsCustomer> usCustomer { get; set; }

        public virtual DbSet<UsCustomerReview> usCustomer_review { get; set; }

        public virtual DbSet<Uscity> UScities { get; set; }

        public virtual DbSet<User> users { get; set; }

        public virtual DbSet<UserMerchant> user_merchant { get; set; }

        public virtual DbSet<VwMostwanted> vw_mostwanted { get; set; }

        public virtual DbSet<Warehouse> warehouse { get; set; }
        public virtual DbSet<TBTransfer> TBTransfers { get; set; }
        public virtual DbSet<TBMessageChat> TBMessageChats { get; set; }
        public virtual DbSet<TBViewChatMessage> ViewChatMessage { get; set; }

      


        //***********************************
        public DbSet<VwUser> VwUsers { get; set; }
        public DbSet<TBTypesCompanies> TBTypesCompaniess { get; set; }
        public DbSet<TBInformationCompanies> TBInformationCompaniess { get; set; }
        public DbSet<TBViewInformationCompanies> ViewInformationCompanies { get; set; }
        public DbSet<TBTypeSystem> TBTypeSystems { get; set; }
        public DbSet<TBCurrenciesExchangeRates> TBCurrenciesExchangeRatess { get; set; }
        public DbSet<TBExchangeRate> TBExchangeRates { get; set; }
        public DbSet<TBViewExchangeRate> ViewExchangeRate { get; set; }
        public DbSet<TBTransaction> TBTransactions { get; set; }
        public DbSet<TBViewTransaction> ViewTransaction { get; set; }
        public DbSet<TBShippingPrice> TBShippingPrices { get; set; }
        public DbSet<TBViewShippingPrices> ViewShippingPrices { get; set; }
        public DbSet<TBViewAreas> ViewAreas { get; set; }
        public DbSet<TBCityDeliveryTariffs> TBCityDeliveryTariffss { get; set; }
        public DbSet<TBViewCityDeliveryTariffs> ViewCityDeliveryTariffs { get; set; }
      
        public DbSet<TBViewCustomers> ViewCustomers { get; set; }
        public DbSet<TBViewMerchant> ViewMerchant { get; set; }
        public DbSet<TBViewOrder> ViewOrder { get; set; }
        public DbSet<TBViewOrderStatus> ViewOrderStatus { get; set; }
        public DbSet<TBTypeSystemDelivery> TBTypeSystemDeliverys { get; set; }
        public DbSet<TBClintWitheDeliveryTariffs> TBClintWitheDeliveryTariffss { get; set; }
        public DbSet<TBViewClintWitheDeliveryTariffs> ViewClintWitheDeliveryTariffs { get; set; }
        public DbSet<TBOrderNew> TBOrderNews { get; set; }
        public DbSet<TBViewOrderNew> ViewOrderNew { get; set; }
        public DbSet<TBViewUsers> ViewUsers { get; set; }
        public DbSet<TBPaing> TBPaings { get; set; }
        public DbSet<TBViewPaings> ViewPaings { get; set; }
        public DbSet<TBViewTransfer> ViewTransfer { get; set; }
        public DbSet<TBViewTransfer> ViewProfits { get; set; }
        public DbSet<TBEmailAlartSetting> TBEmailAlartSettings { get; set; }
        public DbSet<TBShippingAddress> TBShippingAddresses { get; set; }
        public DbSet<TBViewShippingAddress> ViewShippingAddress { get; set; }
        public DbSet<TBTypesOfRequest> TBTypesOfRequests { get; set; }
        public DbSet<TBTypesOfMessage> TBTypesOfMessages { get; set; }
        public DbSet<TBFAQ> TBFAQs { get; set; }
        public DbSet<TBFAQDescreption> TBFAQDescreptions { get; set; }
        public DbSet<TBFAQList> TBFAQLists { get; set; }
        public DbSet<TBViewFAQDescription> ViewFAQDescription { get; set; }
        public DbSet<TBViewFAQList> ViewFAQList { get; set; }
        public DbSet<TBCustomerMessages> TBCustomerMessagess { get; set; }
        public DbSet<TBViewCustomerMessages> ViewCustomerMessages { get; set; }
        public DbSet<TBConnectAndDisConnect> TBConnectAndDisConnects { get; set; }
        public DbSet<TBSupportTicketType> TBSupportTicketTypes { get; set; }
        //test



    }
}
