
using Infarstuructre.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Net;
using Yara.Areas.Admin.Controllers;
using RestSharp;

namespace Yara.Areas.Admin.APIsControllers;

[Route("api/[controller]")]
[ApiController]
public class SheInAPIController : ControllerBase
{
    SheInScarpingController SheInScarping;
    private ApiResponse _response;
    public SheInAPIController(SheInScarpingController SheInScarping1)
    {
        SheInScarping = SheInScarping1;
        _response = new ApiResponse();
    }

    [HttpPost]
    public async Task<IActionResult> GetPhoto([FromBody] SheIn newModel)
    {
        //var options = new ChromeOptions();
        //options.AddArgument("start-maximized");

        //using (var driver = new ChromeDriver(options))
        //{
        //    try
        //    {
        //        driver.Navigate().GoToUrl("https://m.shein.com/pdsearch/" + newModel.name);

        //        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        //        wait.Until(driver => driver.FindElement(By.XPath("//img")));

        //        var imageElement = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
        //        if (imageElement != null)
        //        {
        //            var imageUrl = imageElement.GetAttribute("src");

        //            _response.StatusCode = HttpStatusCode.OK;
        //            _response.Result = imageUrl;
        //            return Ok(_response);
        //        }
        //        else
        //        {
        //            var client = new RestClient("https://api.hasdata.com/scrape/web");
        //            var request = new RestRequest();
        //            request.AddHeader("x-api-key", "0fe96c41-bb73-4a00-9752-557723482b23");
        //            request.AddJsonBody(new
        //            {
        //                url = "https://m.shein.com/pdsearch/" + newModel.name,
        //                proxyType = "datacenter",
        //                proxyCountry = "US",
        //                blockResources = true,
        //                blockAds = true,
        //                screenshot = true,
        //                jsRendering = true,
        //                excludeHtml = false,
        //                extractEmails = true
        //            });

        //            request.Method = Method.Post; // Set method here

        //            var response = await client.ExecuteAsync(request);

        //            if (response.IsSuccessful)
        //            {
        //                //WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        //                //wait1.Until(driver => driver.FindElement(By.XPath("//img")));


        //                var imageElement1 = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
        //                if (imageElement1 != null)
        //                {
        //                    var imageUrl = imageElement.GetAttribute("src");
        //                    _response.Result = imageUrl;
        //                    _response.StatusCode = HttpStatusCode.OK;
        //                    return Ok(_response);
        //                }
        //            }
        //            else
        //            {
        //                _response.StatusCode = HttpStatusCode.BadRequest;
        //                _response.Result = "Failed to fetch image.";
        //                return Ok(_response);
        //            }

        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            _response.Result = "Image not found.";
        //            return Ok(_response);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.ErrorMessage = new List<string> { ex.Message };
        //    }
        //    return Ok(_response);
        //}

        var options = new ChromeOptions();
        options.AddArgument("start-maximized");

        using (var driver = new ChromeDriver(options))
        {
            try
            {
                driver.Navigate().GoToUrl(newModel.name);
                await Task.Delay(10000);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(driver => driver.FindElement(By.XPath("//img")));
                var imageElement = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
                if (imageElement != null)
                {
                    var imageUrl = imageElement.GetAttribute("src");

                    var skuElement = driver.FindElements(By.XPath("//div[contains(@class, 'product-intro__head-sku')]//span[contains(@class, 'product-intro__head-sku-text')]")).FirstOrDefault();
                    if (skuElement != null)
                    {
                        var sku = skuElement.Text.Replace("SKU: ", "");
                        _response.Result = new { ImageURL = imageUrl, Title = sku };
                        _response.StatusCode = HttpStatusCode.OK;
                        return Ok(_response);

                    }
                    else
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.Result = "Image not found.";
                        return Ok(_response);
                    }


                }
                else
                {
                    string newUrl = "https://app.scrapingbee.com/api/v1?api_key=API_KEY&url=" + newModel;
                    driver.Navigate().GoToUrl(newUrl);
                    await Task.Delay(5000);
                    WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                    wait2.Until(driver => driver.FindElement(By.XPath("//img")));
                    var imageElement2 = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
                    if (imageElement2 != null)
                    {
                        var imageUrl2 = imageElement2.GetAttribute("src");
                        var skuElement2 = driver.FindElements(By.XPath("//div[contains(@class, 'product-intro__head-sku')]//span[contains(@class, 'product-intro__head-sku-text')]")).FirstOrDefault();
                        if (skuElement2 != null)
                        {
                            var sku2 = skuElement2.Text.Replace("SKU: ", "");
                            _response.Result = new { ImageURL = imageUrl2, Title = sku2 };
                            _response.StatusCode = HttpStatusCode.OK;
                            return Ok(_response);
                        }
                        else
                        {
                            _response.StatusCode = HttpStatusCode.BadRequest;
                            _response.Result = "Image or name not found.";
                            return Ok(_response);
                        }

                    }
                    else
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.Result = "Errore during Scrape Url.";
                        return Ok(_response);
                    }
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }
            return Ok(_response);
        }



    }






}
