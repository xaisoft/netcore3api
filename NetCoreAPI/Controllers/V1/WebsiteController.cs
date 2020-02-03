using CaseWebsites.Data;
using Microsoft.AspNetCore.Mvc;

namespace CaseWebsites.Service.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WebsiteController : ControllerBase
    {
    
        private readonly IWebsiteProvider _websiteProvider;

        public WebsiteController(IWebsiteProvider websiteProvider)
        {
            _websiteProvider = websiteProvider;
        }

        [HttpGet("{key}")]
        public IActionResult Get(string key)
        {
            var website = _websiteProvider.GetWebsiteById(key);

            return Ok(website);
        }
    }
}