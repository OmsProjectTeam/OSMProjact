using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{

    public partial class OrderDetail
    {
        public int Id { get; set; }

        public int? OrderNo { get; set; }

        public int? ItemCode { get; set; }

        public int? Value { get; set; }

        public int? Qty { get; set; }

        public int? OriginalAmount { get; set; }

        public int? Size { get; set; }

        public int? OnlineOrder { get; set; }

        public int? RestPaid { get; set; }

        public int? ValueCollecedBy { get; set; }

        public int? RestPaidCollectedBy { get; set; }

        public int? ValueCleared { get; set; }

        public int? RestPaidCleared { get; set; }

        public string? Notes { get; set; }

        public int? CollectionFeesIq { get; set; }

        public int? DeliveryFeesIq { get; set; }

        public int? TaskStatusId { get; set; }

        public int? FinanceStatus { get; set; }

        public string? TrackingNo { get; set; }

        public string? OrderId { get; set; }

        public DateTime? InsertDt { get; set; }

        public DateTime? BookingDt { get; set; }

        public int? Missing { get; set; }

        public int? Returned { get; set; }

        public int? Sorted { get; set; }

        public int? Removed { get; set; }

        public int? Whs { get; set; }

        public int? BonusUs { get; set; }

        public int? SourcePrice { get; set; }

        public decimal? WebsitePrice { get; set; }

        public int? Adjusted { get; set; }

        public int? PageReturn { get; set; }

        public int? Preorder { get; set; }

        public int? TempMissing { get; set; }

        public int? WhsBatchId { get; set; }

        public int? Whsid { get; set; }
    }
}
