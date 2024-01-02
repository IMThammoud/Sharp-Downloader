using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;
using System.Resources;

namespace WebApplication3.Controllers;

[ApiController]
[Route("[controller]")]
public class VideosController : ControllerBase
{
    private byte[] videoBytes;

    
    // Post: Pass the url to this endpoint and do stuff with it
    [HttpPost]
    public IResult Post([FromForm(Name = "url")]String url)
    {
        DownloadService myService = new DownloadService();
        myService.safeUrlParam(url);
        myService.runDownloader();
        
            HttpContext.Response.Headers.Add("Content-Type","application/octet-stream");
            //System.IO.File.WriteAllBytes("/yt-dlp",videoData);
            Stream filestream = System.IO.File.OpenRead("downloaded-video");
            IResult myresult = Results.File(filestream, "application/octet-stream", "downloaded-video.mp4", null, null , true );
            return myresult;
            
    }
}