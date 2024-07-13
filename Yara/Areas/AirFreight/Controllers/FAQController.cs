using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.AirFreight.Controllers
{
	[Area("AirFreight")]
	[Authorize(Roles = "Admin,AirFreight")]
	public class FAQController : Controller
	{

		IIFAQ iFAQ;
		IIFAQDescreption iFAQDescreption;
		IIFAQList iFAQList;

        public FAQController(IIFAQ iFAQ1, IIFAQDescreption iFAQDescreption1, IIFAQList iFAQList1)
        {
            iFAQ = iFAQ1;
            iFAQDescreption = iFAQDescreption1;
            iFAQList = iFAQList1;
        }
        public IActionResult MyFAQ()
		{
			string listFaq = string.Empty;
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
                vmodel.ListFAQ = iFAQ.GetAll();
                vmodel.ListFAQDescription = iFAQDescreption.GetAll();
                vmodel.ListFAQList = iFAQList.GetAll();





                return View(vmodel);
		}


		public IActionResult MyFAQAr()
		{
			string listFaq = string.Empty;

			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListFAQ = iFAQ.GetAll();

			foreach (var quastion in vmodel.ListFAQ)
			{
				var desc = iFAQDescreption.GetAllv(quastion.IdFAQ);
				var list = iFAQList.GetAllv(quastion.IdFAQ);

				foreach (var item in list)
				{
					listFaq = item.ListFAQ;
					vmodel.stringFAQList.Add(listFaq);
				}



				vmodel.listFAQModel.Add(new FAQModel
				{
					Quastion = quastion.FAQ,
					Description = desc.Any() ? desc.FirstOrDefault()?.Descreption : null,
					List = vmodel.stringFAQList
				});

			}
			return View(vmodel);
		}
	}
}
