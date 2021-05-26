using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraping.Scraper;

namespace WebScraping.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperController : ControllerBase
    {
        [HttpGet]
        [Route("ScrapeLakewoodScoop")]
        public List<Post> ScrapeLakewoodScoop()
        {
            return ScrapeWeb.ScrapeLakewoodScoop();
        }
    }
}
