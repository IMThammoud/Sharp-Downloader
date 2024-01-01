using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

[ApiController]
[Route("[controller]")]
public class VideosController : ControllerBase
{
    // Post: Pass the url to this endpoint and do stuff with it
    [HttpPost]
    public string Post([FromForm(Name = "url")]String url)
    {
        DownloadService myService = new DownloadService();
        myService.safeUrlParam(url);
        myService.runDownloader();
        return url+"  <-- Downloaded this video!!!!";
    }
}