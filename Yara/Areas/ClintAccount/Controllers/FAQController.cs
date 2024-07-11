using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.ClintAccount.Controllers
{
    [Area("ClintAccount")]
    [Authorize(Roles = "Admin,Customer")]
    public class FAQController : Controller
    {

        IIFAQ iFAQ;
        IIFAQDescreption iFAQDescreption;
        IIFAQList iFAQList; 
        MasterDbcontext dbcontext;
        public FAQController(IIFAQ iFAQ1, MasterDbcontext dbcontext1, IIFAQDescreption iFAQDescreption1, IIFAQList iFAQList1)
        {
            iFAQ = iFAQ1;
            dbcontext = dbcontext1;
            iFAQDescreption = iFAQDescreption1;
            iFAQList = iFAQList1;
        }
        public IActionResult MyFAQ()
        {
            ViewBag.Description = iFAQDescreption.GetAll();
            ViewBag.List = iFAQList.GetAll();

            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListFAQ = iFAQ.GetAll();
            return View(vmodel);
        }

        public IActionResult MyFAQAr()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListFAQ = iFAQ.GetAll();
            return View(vmodel);
        }
    }
}
