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
        public async Task<IActionResult> ShowPhoto(string model)
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            using (var driver = new ChromeDriver(options))
            {
                try
                {
                    // الخطوة الأولى: محاولة العثور على الصورة باستخدام WebDriver
                    driver.Navigate().GoToUrl("https://m.shein.com/pdsearch/" + model);

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

                        driver.Navigate().GoToUrl("https://app.scrapingbee.com/api/v1?api_key=HYMUUZ1BPAJU3PF6EO6BVO0AEZLS603AIYCR57H0NNJIUJA41P9HF9TQJDZPVC0BDPO3NFUWT26SFLG3&url=https://jp.shein.com/pdsearch/" + model);

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


        //[HttpPost]
        //public async Task<IActionResult> ShowPhoto(string model)
        //{
        //    try
        //    {
        //        // الخطوة الأولى: استخدام Scraping API للحصول على الصورة
        //        var client = new RestClient("https://api.hasdata.com/scrape/web");
        //        var request = new RestRequest();
        //        request.AddHeader("x-api-key", "0fe96c41-bb73-4a00-9752-557723482b23");
        //        request.AddJsonBody(new
        //        {
        //            url = "https://m.shein.com/pdsearch/" + model,
        //            proxyType = "datacenter",
        //            proxyCountry = "US",
        //            blockResources = true,
        //            blockAds = true,
        //            screenshot = true,
        //            jsRendering = true,
        //            excludeHtml = false,
        //            extractEmails = true
        //        });

        //        request.Method = Method.Post;

        //        var response = await client.ExecuteAsync(request);

        //        if (response.IsSuccessful)
        //        {
        //            // تحليل الاستجابة من API
        //            dynamic data = JsonConvert.DeserializeObject(response.Content);

        //            if (data != null && data.screenshot != null)
        //            {
        //                // إذا تم العثور على الصورة من الـ API
        //                string imageUrl = data.screenshot;
        //                ViewBag.ImageUrl = imageUrl;
        //                ViewBag.Model = model;
        //                return View();
        //            }
        //            else
        //            {
        //                ViewBag.Message = "Image not found in the API response.";
        //                System.Diagnostics.Debug.WriteLine("API Response did not contain 'screenshot'.");
        //            }
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Failed to fetch image from the API. Status code: " + response.StatusCode;
        //            System.Diagnostics.Debug.WriteLine("API Response: " + response.Content);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Message = "An error occurred while fetching image from the API: " + ex.Message;
        //        System.Diagnostics.Debug.WriteLine("API Error: " + ex.Message);
        //    }

        //    // الخطوة الثانية: محاولة العثور على الصورة باستخدام WebDriver
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
        //                // إذا تم العثور على الصورة باستخدام WebDriver
        //                var imageUrl = imageElement.GetAttribute("src");
        //                ViewBag.ImageUrl = imageUrl;
        //                ViewBag.Model = model;
        //                return View();
        //            }
        //            else
        //            {
        //                ViewBag.Message = "Image not found in the webpage.";
        //                System.Diagnostics.Debug.WriteLine("WebDriver did not find any image.");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            ViewBag.Message = "An error occurred while fetching image using WebDriver: " + ex.Message;
        //            System.Diagnostics.Debug.WriteLine("WebDriver Error: " + ex.Message);
        //        }
        //    }

        //    return View();
        //}











        [HttpPost]
		public async Task<IActionResult> ShowPhotoAr(string model)
		{
			var options = new ChromeOptions();
			options.AddArgument("start-maximized");

			using (var driver = new ChromeDriver(options))
			{
				try
				{
					driver.Navigate().GoToUrl("https://m.shein.com/pdsearch/" + model);

					WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
					wait.Until(driver => driver.FindElement(By.XPath("//img")));

					var imageElement = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
					if (imageElement != null)
					{
						var imageUrl = imageElement.GetAttribute("src");
						ViewBag.ImageUrl = imageUrl;
						ViewBag.Model = model;
						return View();
					}
					else
					{
						var client = new RestClient("https://api.hasdata.com/scrape/web");
						var request = new RestRequest();
						request.AddHeader("x-api-key", "0fe96c41-bb73-4a00-9752-557723482b23");
						request.AddJsonBody(new
						{
							url = "https://m.shein.com/pdsearch/" + model,
							proxyType = "datacenter",
							proxyCountry = "US",
							blockResources = true,
							blockAds = true,
							screenshot = true,
							jsRendering = true,
							excludeHtml = false,
							extractEmails = true
						});

						request.Method = Method.Post; // Set method here

						var response = await client.ExecuteAsync(request);

						if (response.IsSuccessful)
						{
							//WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
							//wait1.Until(driver => driver.FindElement(By.XPath("//img")));

							var imageElement1 = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
							if (imageElement1 != null)
							{
								var imageUrl = imageElement.GetAttribute("src");
								ViewBag.ImageUrl = imageUrl;
								ViewBag.Model = model;
								return View();
							}
						}
						else
						{
							ViewBag.Message = "Failed to fetch image.";
						}

						ViewBag.Message = "Image not found.";
						return View();
					}
				}
				catch (Exception ex)
				{
					ViewBag.Message = "An error occurred: " + ex.Message;
					return View();
				}
			}
		}
		public IActionResult FetchImageByModel(string model)
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            using (var driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl("https://ar.shein.com/pdsearch/" + model);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(driver => driver.FindElement(By.XPath("//img")));

                var imageElement = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
                if (imageElement != null)
                {
                    var imageUrl = imageElement.GetAttribute("src");
                    // إعادة التوجيه إلى showPhoto مع تمرير المعلمات
                    return RedirectToAction("showPhoto", new { imageUrl = imageUrl, model = model });
                }
                else
                {
                    ViewBag.Message = "Image not found.";
                    return View();
                }
            }
        }






    }
}
