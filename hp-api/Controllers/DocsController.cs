using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace hp_api.Controllers
{
    [ApiController]
    [Route("")]
    public class DocsController: ControllerBase
    {
        [HttpGet]
        public ContentResult Test()
        {
            var path = @"./static/html/home.html";
            var html = System.IO.File.ReadAllText(path);
            return Content(html, "text/html", Encoding.UTF8);
        }
    }
}
