using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HtmlAgilityPack.CssSelectors.NetCore;
using System.Diagnostics;
using OpenQA.Selenium.Chrome;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HtmlAgilityController : Controller
    {
        private readonly ExternalDataService _externalDataService;

        public HtmlAgilityController(ExternalDataService externalDataService)
        {
            _externalDataService = externalDataService;
        }

        public IActionResult myLodeHtml()
        {
            return View();
        }

        public async Task<IActionResult> MyUrl(string url)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                var document = web.Load(url);
                var imageNodes = document.DocumentNode.SelectNodes("//div[@class='mediagallery']//img");

                if (imageNodes != null)
                {
                    var imageUrls = imageNodes.Select(node => node.GetAttributeValue("src", "")).ToList();
                    ViewBag.ImageUrls = imageUrls;
                }

                var imageNodes2 = document.DocumentNode.SelectNodes("//div[@class='price-format__large price-format__main-price']");
                if (imageNodes2 != null)
                {
                    // استخدم النص من العقدة بدلاً من العقدة نفسها
                    ViewBag.html = imageNodes2.Select(node => node.InnerText).ToArray();
					// استخدم النص من العقدة بدلاً من العقدة نفسها
				}

			}
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View();
        }






    }
}


