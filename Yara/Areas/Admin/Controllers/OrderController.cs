

namespace Yara.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class OrderController : Controller
	{
        MasterDbcontext dbcontext;
		IIOrder iOrder;
		IICustomer iCustomer;
        IIOrderCase iOrderCase;
        IIOrderStatus iOrderStatus;
        IIMerchant iMerchant;
        IIInformationCompanies iInformationCompanies;
        IITaskStatus iTaskStatus;
        public OrderController(MasterDbcontext dbcontext1,IIOrder iOrder1,IICustomer iCustomer1,IIOrderCase iOrderCase1,IIOrderStatus iOrderStatus1,IIMerchant iMerchant1,IIInformationCompanies iInformationCompanies1,IITaskStatus iTaskStatus1)
        {
            dbcontext=dbcontext1;
            iOrder=iOrder1;
            iCustomer=iCustomer1;
            iOrderCase=iOrderCase1;
            iOrderStatus =iOrderStatus1;
            iMerchant =iMerchant1;
            iInformationCompanies =iInformationCompanies1;
            iTaskStatus =iTaskStatus1;
        }
        public IActionResult MyOrder()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewOrder = iOrder.GetAll();
            return View(vmodel);
        }
        public IActionResult AddOrder(int? IdOrder)

        {
            ViewBag.Customer = iCustomer.GetAll();

            ViewBag.OrderCase = iOrderCase.GetAll();
            ViewBag.OrderStatus = iOrderStatus.GetAll();
            ViewBag.Merchant = iMerchant.GetAll();
            ViewBag.InformationCompanies = iInformationCompanies.GetAll();
            ViewBag.TaskStatus = iTaskStatus.GetAll();





            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewOrder = iOrder.GetAll();
            if (IdOrder != null)
            {
                vmodel.Order = iOrder.GetById(Convert.ToInt32(IdOrder));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, Order slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.Id = model.Order.Id;
                slider.OrderDt = model.Order.OrderDt;
                slider.OrderOwner = model.Order.OrderOwner;
                slider.WithDelivery = model.Order.WithDelivery;
                slider.DeliveryCharges = model.Order.DeliveryCharges;
                slider.OrderStatus = model.Order.OrderStatus;
                slider.ReceiptNo = model.Order.ReceiptNo;
                slider.ReceiptDt = model.Order.ReceiptDt;
                slider.UserId = model.Order.UserId;
                slider.BatchId = model.Order.BatchId;
                slider.ServiceCharges = model.Order.ServiceCharges;
                slider.Netrevenue = model.Order.Netrevenue;
                slider.DeliveryCollectedBy = model.Order.DeliveryCollectedBy;
                slider.AssymblyCharges = model.Order.AssymblyCharges;
                slider.AssymblyCollectedBy = model.Order.AssymblyCollectedBy;
                slider.DeliveryCleared = model.Order.DeliveryCleared;
                slider.AssymblyCleared = model.Order.AssymblyCleared;
                slider.DeliveryNotes = model.Order.DeliveryNotes;
                slider.OrderCaseId = model.Order.OrderCaseId;
                slider.Hxcode = model.Order.Hxcode;
                slider.SmsnotificationDt = model.Order.SmsnotificationDt;
                slider.TaskStatusId = model.Order.TaskStatusId;
                slider.FinanceStatus = model.Order.FinanceStatus;
                slider.Closed = model.Order.Closed;
                slider.Totalqty = model.Order.Totalqty;
                slider.NetAmount = model.Order.NetAmount;
                slider.BookingDt = model.Order.BookingDt;
                slider.DeliveryDt = model.Order.DeliveryDt;
                slider.OnlineOrder = model.Order.OnlineOrder;
                slider.FullyPackage = model.Order.FullyPackage;
                slider.MerchantId = model.Order.MerchantId;
                slider.BookingSource = model.Order.BookingSource;
                slider.BonusIq = model.Order.BonusIq;
                slider.LastBeforeStatusId = model.Order.LastBeforeStatusId;
                slider.AdvancePayment = model.Order.AdvancePayment;
                slider.AgentUserId = model.Order.AgentUserId;
                slider.Collected = model.Order.Collected;
                slider.Transferred = model.Order.Transferred;
                slider.Source = model.Order.Source;
                slider.FinancAdj = model.Order.FinancAdj;
                slider.CollectedByOwner = model.Order.CollectedByOwner;
                slider.AdminBonus = model.Order.AdminBonus;
                slider.WithAgent = model.Order.WithAgent;
                slider.AdminAdj = model.Order.AdminAdj;
                slider.SortFeesAdj = model.Order.SortFeesAdj;
                slider.CompSortAdj = model.Order.CompSortAdj;
                slider.LocalDeliveryAdj = model.Order.LocalDeliveryAdj;
                slider.CompDeliveryAdj = model.Order.CompDeliveryAdj;
                slider.ActualDeliveryDt = model.Order.ActualDeliveryDt;
                slider.Aliexbatchid = model.Order.Aliexbatchid;
                slider.Returned = model.Order.Returned;
                slider.WithAgentId = model.Order.WithAgentId;
                slider.PickupDt = model.Order.PickupDt;
                slider.TaskWithAgentId = model.Order.TaskWithAgentId;
                slider.CollectionDt = model.Order.CollectionDt;
                slider.CloseAcknoledgeDt = model.Order.CloseAcknoledgeDt;
                slider.BonusDeduct = model.Order.BonusDeduct;
                slider.DeductProgressed = model.Order.DeductProgressed;
                slider.BranchId = model.Order.BranchId;
                slider.ToWarehouse = model.Order.ToWarehouse;
                slider.CityReceipt = model.Order.CityReceipt;
                slider.PageReturnArrange = model.Order.PageReturnArrange;
                slider.Acknoledged = model.Order.Acknoledged;
                slider.PriceLog = model.Order.PriceLog;
                slider.AdvOrder = model.Order.AdvOrder;
                slider.CollectionAdjustmentDt = model.Order.CollectionAdjustmentDt;
                slider.IsCredit = model.Order.IsCredit;
                slider.ReturnDt = model.Order.ReturnDt;
                slider.PreClose = model.Order.PreClose;
                slider.CenrtralBankPrice = model.Order.CenrtralBankPrice;
                slider.Active = model.Order.Active;           
                slider.DataEntry = model.Order.DataEntry;
                slider.DateTimeEntry = model.Order.DateTimeEntry;
                slider.CurrentState = model.Order.CurrentState;
                slider.IdInformationCompanies = model.Order.IdInformationCompanies;
                if (slider.Id == 0 || slider.Id == null)
                {
                    if (dbcontext.orders.Where(a => a.Hxcode == slider.Hxcode).ToList().Count > 0)
                    {
                        TempData["Hxcode"] = ResourceWeb.VLHxcodedoplceted;
                        return RedirectToAction("AddOrder", model);
                    }
                  
                    var reqwest = iOrder.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyOrder");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iOrder.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyOrder");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                        return Redirect(returnUrl);
                    }
                }
            }
            catch
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                return Redirect(returnUrl);
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdOrder)
        {
            var reqwistDelete = iOrder.deleteData(IdOrder);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyOrder");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyOrder");
            }
        }
    }
}
