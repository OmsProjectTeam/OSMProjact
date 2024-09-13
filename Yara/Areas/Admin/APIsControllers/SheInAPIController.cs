using Infarstuructre.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Net;
using Yara.Areas.Admin.Controllers;

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
    public IActionResult GetPhoto([FromBody] SheIn newModel)
    {
        try
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            using (var driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl("https://ar.shein.com/pdsearch/" + newModel.pdsearch);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(driver => driver.FindElement(By.XPath("//img")));

                var imageElement = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
                if (imageElement != null)
                {
                    var imageUrl = imageElement.GetAttribute("src");

                    _response.Result = imageUrl;
                    _response.StatusCode = HttpStatusCode.Created;

                    return Ok(_response);
                }
                else
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return Ok(_response);
                }
            }

        }catch(Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessage = new List<string> { ex.Message };
        }
        return Ok(_response);
    }

}
