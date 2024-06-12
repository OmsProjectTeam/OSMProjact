using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class Order
    {
        public int Id { get; set; }

        public DateOnly? OrderDt { get; set; }

        public int? OrderOwner { get; set; }

        public int? WithDelivery { get; set; }

        public int? DeliveryCharges { get; set; }

        public string? Notes { get; set; }

        public int? OrderStatus { get; set; }

        public string? ReceiptNo { get; set; }

        public DateOnly? ReceiptDt { get; set; }

        public int? UserId { get; set; }

        public int? BatchId { get; set; }

        public int? ServiceCharges { get; set; }

        public int? Netrevenue { get; set; }

        public int? DeliveryCollectedBy { get; set; }

        public int? AssymblyCharges { get; set; }

        public int? AssymblyCollectedBy { get; set; }

        public int? DeliveryCleared { get; set; }

        public int? AssymblyCleared { get; set; }

        public string? DeliveryNotes { get; set; }

        public int? OrderCaseId { get; set; }

        public string? Hxcode { get; set; }

        public DateTime? SmsnotificationDt { get; set; }

        public int? TaskStatusId { get; set; }

        public int? FinanceStatus { get; set; }

        public int? Closed { get; set; }

        public int? Totalqty { get; set; }

        public int? NetAmount { get; set; }

        public DateTime? BookingDt { get; set; }

        public DateTime? DeliveryDt { get; set; }

        public int? OnlineOrder { get; set; }

        public int? FullyPackage { get; set; }

        public int? MerchantId { get; set; }

        public decimal? BookingSource { get; set; }

        public int? BonusIq { get; set; }

        public int? LastBeforeStatusId { get; set; }

        public int? AdvancePayment { get; set; }

        public int? AgentUserId { get; set; }

        public int? Collected { get; set; }

        public int? Transferred { get; set; }

        public int? Source { get; set; }

        public int? FinancAdj { get; set; }

        public int? CollectedByOwner { get; set; }

        public int? AdminBonus { get; set; }

        public int? WithAgent { get; set; }

        public int? AdminAdj { get; set; }

        public int? SortFeesAdj { get; set; }

        public int? CompSortAdj { get; set; }

        public int? LocalDeliveryAdj { get; set; }

        public int? CompDeliveryAdj { get; set; }

        public DateTime? ActualDeliveryDt { get; set; }

        public int? Aliexbatchid { get; set; }

        public int? Returned { get; set; }

        public int? WithAgentId { get; set; }

        public DateTime? PickupDt { get; set; }

        public int? TaskWithAgentId { get; set; }

        public DateTime? CollectionDt { get; set; }

        public DateTime? CloseAcknoledgeDt { get; set; }

        public int? LinkedAdvNorderNo { get; set; }

        public int? BonusDeduct { get; set; }

        public int? DeductProgressed { get; set; }

        public int? BranchId { get; set; }

        public int? ToWarehouse { get; set; }

        public int? CityReceipt { get; set; }

        public int? PageReturnArrange { get; set; }

        public int? Acknoledged { get; set; }

        public string? PriceLog { get; set; }

        public int? AdvOrder { get; set; }

        public DateOnly? CollectionAdjustmentDt { get; set; }

        public int? IsCredit { get; set; }

        public DateOnly? ReturnDt { get; set; }

        public int? PreClose { get; set; }

        public int? CenrtralBankPrice { get; set; }
    }
}
