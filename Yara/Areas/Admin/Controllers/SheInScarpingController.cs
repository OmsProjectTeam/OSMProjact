using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using System;
using System.Linq;
using static System.Net.WebRequestMethods;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SheInScarpingController : Controller
    {
        public IActionResult MySheInScarping()
        {
            return View();
        }
           public IActionResult MySheInScarpingAr()
        {
            return View();
        }







        //[HttpGet]
        //public async Task<IActionResult> FetchImageByModel(string model)
        //{
        //    try
        //    {
        //        using (HttpClient client = new HttpClient())
        //        {
        //            client.Timeout = TimeSpan.FromSeconds(30); // تعيين المهلة إلى 30 ثانية

        //            // تعيين وكيل المستخدم ليبدو كأنه متصفح حقيقي بدون استخدام أي أحرف غير ASCII
        //            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");

        //            var searchUrl = "https://ar.shein.com/pdsearch/" + model;
        //            var response = await client.GetAsync(searchUrl);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                // الحصول على الرابط الجديد بعد إعادة التوجيه
        //                var redirectedUrl = response.RequestMessage.RequestUri.ToString();

        //                // تحميل محتوى الصفحة الجديدة
        //                var pageContents = await response.Content.ReadAsStringAsync();
        //                var document = new HtmlDocument();
        //                document.LoadHtml(pageContents);

        //                // محاولة استخراج الصور من العنصر المطلوب
        //                var imageNodes = document.DocumentNode.SelectNodes("//img[contains(@class, 'crop-image-container__img')]//img");

        //                if (imageNodes != null && imageNodes.Any())
        //                {
        //                    var firstImageUrl = imageNodes
        //                       .Select(node => node.GetAttributeValue("src", ""))
        //                       .FirstOrDefault(src => !string.IsNullOrEmpty(src));

        //                    if (!string.IsNullOrEmpty(firstImageUrl))
        //                    {
        //                        return Json(new { success = true, imageUrl = firstImageUrl, redirectedUrl });
        //                    }
        //                    else
        //                    {
        //                        // إذا لم يتم العثور على أي صورة
        //                        return Json(new { success = false, message = "Image not found in the specified div.", redirectedUrl });
        //                    }
        //                }
        //                else
        //                {
        //                    var imageNodes2 = document.DocumentNode.SelectNodes("//img");
        //                    // إذا لم يتم العثور على أي صورة
        //                    if (imageNodes2 != null && imageNodes2.Any())
        //                    {
        //                        var firstImageUrl = imageNodes2
        //                           .Select(node => node.GetAttributeValue("src", ""))
        //                           .FirstOrDefault(src => !string.IsNullOrEmpty(src));

        //                        if (!string.IsNullOrEmpty(firstImageUrl))
        //                        {
        //                            return Json(new { success = true, imageUrl = firstImageUrl, redirectedUrl });
        //                        }
        //                        else
        //                        {
        //                            // إذا لم يتم العثور على أي صورة
        //                            return Json(new { success = false, message = "Image not found in the specified div.", redirectedUrl });
        //                        }
        //                    }


        //                    return Json(new { success = false, message = "Image not found in the specified div.", redirectedUrl });
        //                }
        //            }
        //            else
        //            {
        //                return Json(new { success = false, message = "Failed to load the page." });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = ex.Message });
        //    }
        //}

        //public void FetchImageByModel(string model)
        //{
        //    // إعداد Selenium مع Chrome
        //    var options = new ChromeOptions();
        //    options.AddArgument("start-maximized");
        //    using (var driver = new ChromeDriver(options))
        //    {
        //        driver.Navigate().GoToUrl("https://ar.shein.com/pdsearch/" + model);

        //        // الانتظار حتى يتم تحميل الصفحة
        //        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        //        wait.Until(driver => driver.FindElement(By.XPath("//img")));

        //        // محاولة العثور على الصورة
        //        var imageElement = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
        //        if (imageElement != null)
        //        {
        //            var imageUrl = imageElement.GetAttribute("src");
        //            Console.WriteLine("Image URL: " + imageUrl);






        //        }
        //        else
        //        {
        //            Console.WriteLine("Image not found.");
        //        }
        //    }
        //}

        //public IActionResult FetchImageByModel(string model)
        //{
        //    // إعداد Selenium مع Chrome
        //    var options = new ChromeOptions();
        //    options.AddArgument("start-maximized");
        //    using (var driver = new ChromeDriver(options))
        //    {
        //        driver.Navigate().GoToUrl("https://ar.shein.com/pdsearch/" + model);

        //        // الانتظار حتى يتم تحميل الصفحة
        //        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        //        wait.Until(driver => driver.FindElement(By.XPath("//img")));

        //        // محاولة العثور على الصورة
        //        var imageElement = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
        //        if (imageElement != null)
        //        {
        //            var imageUrl = imageElement.GetAttribute("src");
        //            // إرسال رابط الصورة إلى العرض
        //            ViewBag.ImageUrl = imageUrl;

        //            return View(imageUrl); // عرض الصفحة
        //        }
        //        else
        //        {
        //            // إذا لم يتم العثور على أي صورة
        //            ViewBag.Message = "Image not found.";
        //            return View();
        //        }
        //    }
        //}
        //[HttpPost]
        //public IActionResult showPhoto(string model)
        //{


        //    var options = new ChromeOptions();
        //    options.AddArgument("start-maximized");

        //    using (var driver = new ChromeDriver(options))
        //    {

        //        driver.Navigate().GoToUrl("https://ar.shein.com/pdsearch/" + model);

        //        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        //        wait.Until(driver => driver.FindElement(By.XPath("//img")));

        //        var imageElement = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
        //        if (imageElement != null)
        //        {
        //            var imageUrl = imageElement.GetAttribute("src");
        //            // إعادة التوجيه إلى showPhoto مع تمرير المعلمات
        //            ViewBag.ImageUrl = imageUrl;
        //            ViewBag.Model = model;
        //            return View();
        //        }
        //        else
        //        {





        //            ViewBag.Message = "Image not found.";
        //            return View();
        //        }
        //    }
        //}


        //[HttpPost]
        //public async Task<IActionResult> ShowPhoto(string model)
        //{
        //    var options = new ChromeOptions();
        //    options.AddArgument("start-maximized");

        //    using (var driver = new ChromeDriver(options))
        //    {
        //        try
        //        {
        //            driver.Navigate().GoToUrl("https://m.shein.com/pdsearch/" + model);

        //            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        //            wait.Until(driver => driver.FindElement(By.XPath("//img")));

        //            var imageElement = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
        //            if (imageElement != null)
        //            {
        //                var imageUrl = imageElement.GetAttribute("src");
        //                ViewBag.ImageUrl = imageUrl;
        //                ViewBag.Model = model;
        //                return View();
        //            }
        //            else
        //            {
        //                var client = new RestClient("https://api.hasdata.com/scrape/web");
        //                var request = new RestRequest();
        //                request.AddHeader("x-api-key", "0fe96c41-bb73-4a00-9752-557723482b23");
        //                request.AddJsonBody(new
        //                {
        //                    url = "https://m.shein.com/pdsearch/" + model,
        //                    proxyType = "datacenter",
        //                    proxyCountry = "US",
        //                    blockResources = true,
        //                    blockAds = true,
        //                    screenshot = true,
        //                    jsRendering = true,
        //                    excludeHtml = false,
        //                    extractEmails = true
        //                });

        //                request.Method = Method.Post; // Set method here

        //                var response = await client.ExecuteAsync(request);

        //                if (response.IsSuccessful)
        //                {
        //                    //WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        //                    //wait1.Until(driver => driver.FindElement(By.XPath("//img")));

        //                    var imageElement1 = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
        //                    if (imageElement1 != null)
        //                    {
        //                        var imageUrl = imageElement.GetAttribute("src");
        //                        ViewBag.ImageUrl = imageUrl;
        //                        ViewBag.Model = model;
        //                        return View();
        //                    }
        //                }
        //                else
        //                {
        //                    ViewBag.Message = "Failed to fetch image.";
        //                }

        //                ViewBag.Message = "Image not found.";
        //                return View();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            ViewBag.Message = "An error occurred: " + ex.Message;
        //            return View();
        //        }
        //    }
        //}



        [HttpPost]
        public async Task<IActionResult> ShowPhoto4(string model)
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            using (var driver = new ChromeDriver(options))
            {
                try
                {
                    // الخطوة الأولى: محاولة العثور على الصورة باستخدام WebDriver
                    driver.Navigate().GoToUrl("https://asia.shein.com/pdsearch/" + model);

                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                    wait.Until(driver => driver.FindElement(By.XPath("//img")));

                    var imageElement = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();

                    if (imageElement != null)
                    {
                        // إذا تم العثور على الصورة باستخدام WebDriver
                        var imageUrl = imageElement.GetAttribute("src");
                        ViewBag.ImageUrl = imageUrl;
                        ViewBag.Model = model;
                        return View();
                    }
                   else {


                        driver.Navigate().GoToUrl("https://app.scrapingbee.com/api/v1?api_key=8NGBBO05BEL1JTZ13GLEP04GEB7R28LTGDZCQQDYV6MK3L5VRXHCKZO0C3ZLQNGYKLWVLIU75X0C4NDW&url=https://jp.shein.com/pdsearch/" + model);

                        WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                        wait2.Until(driver => driver.FindElement(By.XPath("//img")));

                        var imageElement2 = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();

                        if (imageElement2 != null)
                        {
                            // إذا تم العثور على الصورة باستخدام WebDriver
                            var imageUrl2 = imageElement2.GetAttribute("src");
                            ViewBag.ImageUrl = imageUrl2;
                            ViewBag.Model = model;
                            return View();
                        }
                        else
                        {
                            ViewBag.Message = "Image not found.";
                                           return View();
                        }


                    }
                    }
                catch (Exception ex)
                {
                    ViewBag.Message = "An error occurred: " + ex.Message;
                }
            }

            return View();
        }







        [HttpPost]
        public async Task<IActionResult> ShowPhoto1(string model)
        {
            try
            {
                // استخدام ScrapingBee للحصول على الصورة مباشرةً
                var apiKey = "HYMUUZ1BPAJU3PF6EO6BVO0AEZLS603AIYCR57H0NNJIUJA41P9HF9TQJDZPVC0BDPO3NFUWT26SFLG3";
                var url = $"https://app.scrapingbee.com/api/v1?api_key={apiKey}&url=https://m.shein.com/pdsearch/{model}";

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetStringAsync(url);
                    var htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(response);

                    var imageElement = htmlDocument.DocumentNode.SelectSingleNode("//img[contains(@class, 'crop-image-container__img')]");

                    if (imageElement != null)
                    {
                        var imageUrl = imageElement.GetAttributeValue("src", "");
                        ViewBag.ImageUrl = imageUrl;
                        ViewBag.Model = model;
                        return View();
                    }
                    else
                    {
                        ViewBag.Message = "Image not found.";
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "An error occurred: " + ex.Message;
                return View();
            }
        }



        [HttpPost]
        public async Task<IActionResult> ShowPhoto55(string model)
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            using (var driver = new ChromeDriver(options))
            {
                try
                {
                    // الخطوة الأولى: الانتقال إلى الرابط الكامل
                    driver.Navigate().GoToUrl(model);
                    // الانتظار لمدة 5 ثوانٍ للتأكد من تحميل الصفحة
                    await Task.Delay(10000);
                    // انتظار ظهور الصورة
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                    wait.Until(driver => driver.FindElement(By.XPath("//img")));
                    // البحث عن الصورة المطلوبة
                    var imageElement = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
                    if (imageElement != null)
                    {
                        // جلب رابط الصورة
                        var imageUrl = imageElement.GetAttribute("src");
                        ViewBag.ImageUrl = imageUrl;
                        return View();
                    }
                    else
                    {
                        // إذا لم يتم العثور على الصورة في المحاولة الأولى
                        // الذهاب إلى الرابط الثاني لجلب الصورة
                        string newUrl = "https://app.scrapingbee.com/api/v1?api_key=API_KEY&url=" + model;
                        driver.Navigate().GoToUrl(newUrl);
                        // الانتظار لمدة 5 ثوانٍ للتأكد من تحميل الصفحة الجديدة
                        await Task.Delay(5000);
                        WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                        wait2.Until(driver => driver.FindElement(By.XPath("//img")));
                        var imageElement2 = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
                        if (imageElement2 != null)
                        {
                            // جلب رابط الصورة الجديدة
                            var imageUrl2 = imageElement2.GetAttribute("src");
                            ViewBag.ImageUrl = imageUrl2;
                            return View();
                        }
                        else
                        {
                            ViewBag.Message = "Image not found.";
                            return View();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "An error occurred: " + ex.Message;
                }
            }

            return View();
        }

		[HttpPost]
		public async Task<IActionResult> ShowPhoto(string model)
		{
			var options = new ChromeOptions();
			options.AddArgument("start-maximized");

			using (var driver = new ChromeDriver(options))
			{
				try
				{
					// الخطوة الأولى: الانتقال إلى الرابط الكامل
					driver.Navigate().GoToUrl(model);
					// الانتظار لمدة 5 ثوانٍ للتأكد من تحميل الصفحة
					await Task.Delay(10000);
					// انتظار ظهور الصورة
					WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
					wait.Until(driver => driver.FindElement(By.XPath("//img")));

					// البحث عن الصورة المطلوبة
					var imageElement = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
					if (imageElement != null)
					{
						// جلب رابط الصورة
						var imageUrl = imageElement.GetAttribute("src");
						ViewBag.ImageUrl = imageUrl;

						// البحث عن عنصر SKU
						var skuElement = driver.FindElements(By.XPath("//div[contains(@class, 'product-intro__head-sku')]//span[contains(@class, 'product-intro__head-sku-text')]")).FirstOrDefault();
						if (skuElement != null)
						{
							// جلب نص SKU
							var sku = skuElement.Text.Replace("SKU: ", "");
							ViewBag.SKU = sku;
						}
						else
						{
							ViewBag.SKU = "SKU not found.";
						}

						return View();
					}
					else
					{
						// إذا لم يتم العثور على الصورة في المحاولة الأولى
						// الذهاب إلى الرابط الثاني لجلب الصورة
						string newUrl = "https://app.scrapingbee.com/api/v1?api_key=API_KEY&url=" + model;
						driver.Navigate().GoToUrl(newUrl);
						// الانتظار لمدة 5 ثوانٍ للتأكد من تحميل الصفحة الجديدة
						await Task.Delay(5000);
						WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
						wait2.Until(driver => driver.FindElement(By.XPath("//img")));
						var imageElement2 = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
						if (imageElement2 != null)
						{
							// جلب رابط الصورة الجديدة
							var imageUrl2 = imageElement2.GetAttribute("src");
							ViewBag.ImageUrl = imageUrl2;

							// البحث عن عنصر SKU
							var skuElement2 = driver.FindElements(By.XPath("//div[contains(@class, 'product-intro__head-sku')]//span[contains(@class, 'product-intro__head-sku-text')]")).FirstOrDefault();
							if (skuElement2 != null)
							{
								var sku2 = skuElement2.Text.Replace("SKU: ", "");
								ViewBag.SKU = sku2;
							}
							else
							{
								ViewBag.SKU = "SKU not found.";
							}

							return View();
						}
						else
						{
							ViewBag.Message = "Image not found.";
							return View();
						}
					}
				}
				catch (Exception ex)
				{
					ViewBag.Message = "An error occurred: " + ex.Message;
				}
			}

			return View();
		}












		//      [HttpPost]
		//public async Task<IActionResult> ShowPhotoAr(string model)
		//{
		//	var options = new ChromeOptions();
		//	options.AddArgument("start-maximized");

		//	using (var driver = new ChromeDriver(options))
		//	{
		//		try
		//		{
		//			driver.Navigate().GoToUrl("https://m.shein.com/pdsearch/" + model);

		//			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
		//			wait.Until(driver => driver.FindElement(By.XPath("//img")));

		//			var imageElement = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
		//			if (imageElement != null)
		//			{
		//				var imageUrl = imageElement.GetAttribute("src");
		//				ViewBag.ImageUrl = imageUrl;
		//				ViewBag.Model = model;
		//				return View();
		//			}
		//			else
		//			{
		//				var client = new RestClient("https://api.hasdata.com/scrape/web");
		//				var request = new RestRequest();
		//				request.AddHeader("x-api-key", "0fe96c41-bb73-4a00-9752-557723482b23");
		//				request.AddJsonBody(new
		//				{
		//					url = "https://m.shein.com/pdsearch/" + model,
		//					proxyType = "datacenter",
		//					proxyCountry = "US",
		//					blockResources = true,
		//					blockAds = true,
		//					screenshot = true,
		//					jsRendering = true,
		//					excludeHtml = false,
		//					extractEmails = true
		//				});

		//				request.Method = Method.Post; // Set method here

		//				var response = await client.ExecuteAsync(request);

		//				if (response.IsSuccessful)
		//				{
		//					//WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
		//					//wait1.Until(driver => driver.FindElement(By.XPath("//img")));

		//					var imageElement1 = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
		//					if (imageElement1 != null)
		//					{
		//						var imageUrl = imageElement.GetAttribute("src");
		//						ViewBag.ImageUrl = imageUrl;
		//						ViewBag.Model = model;
		//						return View();
		//					}
		//				}
		//				else
		//				{
		//					ViewBag.Message = "Failed to fetch image.";
		//				}

		//				ViewBag.Message = "Image not found.";
		//				return View();
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			ViewBag.Message = "An error occurred: " + ex.Message;
		//			return View();
		//		}
		//	}
		//}
		//public IActionResult FetchImageByModel(string model)
		//      {
		//          var options = new ChromeOptions();
		//          options.AddArgument("start-maximized");

		//          using (var driver = new ChromeDriver(options))
		//          {
		//              driver.Navigate().GoToUrl("https://ar.shein.com/pdsearch/" + model);

		//              WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
		//              wait.Until(driver => driver.FindElement(By.XPath("//img")));

		//              var imageElement = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
		//              if (imageElement != null)
		//              {
		//                  var imageUrl = imageElement.GetAttribute("src");
		//                  // إعادة التوجيه إلى showPhoto مع تمرير المعلمات
		//                  return RedirectToAction("showPhoto", new { imageUrl = imageUrl, model = model });
		//              }
		//              else
		//              {
		//                  ViewBag.Message = "Image not found.";
		//                  return View();
		//              }
		//          }
		//      }
















		[HttpPost]
        public async Task<IActionResult> ShowPhoto2(string model)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30); // تعيين المهلة إلى 30 ثانية

                    // تعيين وكيل المستخدم ليبدو كأنه متصفح حقيقي بدون استخدام أي أحرف غير ASCII
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");

                    var searchUrl = model;
                    var response = await client.GetAsync(searchUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // الحصول على الرابط الجديد بعد إعادة التوجيه
                        var redirectedUrl = response.RequestMessage.RequestUri.ToString();

                        // تحميل محتوى الصفحة الجديدة
                        var pageContents = await response.Content.ReadAsStringAsync();
                        var document = new HtmlDocument();
                        document.LoadHtml(pageContents);

                        // محاولة استخراج الصور من العنصر المطلوب
                        var imageNodes = document.DocumentNode.SelectNodes("//img[contains(@class, 'crop-image-container__img')]");

                        if (imageNodes != null && imageNodes.Any())
                        {
                            var firstImageUrl = imageNodes
                               .Select(node => node.GetAttributeValue("src", ""))
                               .FirstOrDefault(src => !string.IsNullOrEmpty(src));

                            if (!string.IsNullOrEmpty(firstImageUrl))
                            {
                                return Json(new { success = true, imageUrl = firstImageUrl, redirectedUrl });
                            }
                            else
                            {
                                // إذا لم يتم العثور على أي صورة
                                return Json(new { success = false, message = "Image not found in the specified div.", redirectedUrl });
                            }
                        }
                        else
                        {
                            var imageNodes2 = document.DocumentNode.SelectNodes("//img");
                            // إذا لم يتم العثور على أي صورة
                            if (imageNodes2 != null && imageNodes2.Any())
                            {
                                var firstImageUrl = imageNodes2
                                   .Select(node => node.GetAttributeValue("src", ""))
                                   .FirstOrDefault(src => !string.IsNullOrEmpty(src));

                                if (!string.IsNullOrEmpty(firstImageUrl))
                                {
                                    return Json(new { success = true, imageUrl = firstImageUrl, redirectedUrl });
                                }
                                else
                                {
                                    // إذا لم يتم العثور على أي صورة
                                    return Json(new { success = false, message = "Image not found in the specified div.", redirectedUrl });
                                }
                            }


                            return Json(new { success = false, message = "Image not found in the specified div.", redirectedUrl });
                        }
                    }
                    else
                    {
                        return Json(new { success = false, message = "Failed to load the page." });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }




    }
}
