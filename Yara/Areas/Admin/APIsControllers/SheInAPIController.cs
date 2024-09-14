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
        var options = new ChromeOptions();
        options.AddArgument("start-maximized");

        using (var driver = new ChromeDriver(options))
        {
            try
            {
                driver.Navigate().GoToUrl("https://m.shein.com/pdsearch/" + newModel.pdsearch);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(driver => driver.FindElement(By.XPath("//img")));

                var imageElement = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
                if (imageElement != null)
                {
                    var imageUrl = imageElement.GetAttribute("src");
                    return Ok(imageUrl);
                }
                else
                {
                    var client = new RestClient("https://api.hasdata.com/scrape/web");
                    var request = new RestRequest();
                    request.AddHeader("x-api-key", "0fe96c41-bb73-4a00-9752-557723482b23");
                    request.AddJsonBody(new
                    {
                        url = "https://m.shein.com/pdsearch/" + newModel.pdsearch,
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
                            return Ok(imageUrl);
                        }
                    }
                    else
                    {
                        return Content("Failed to fetch image.");
                    }
                    return NotFound("Image not found.");
                }
            }
            catch (Exception ex)
            {
                return Content("An error occurred: " + ex.Message);
            }
        }

    }
}
