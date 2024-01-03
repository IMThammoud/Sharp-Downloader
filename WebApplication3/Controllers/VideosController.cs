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

    
    // Post: Pass the url to this endpoint, store it and use it to download a
    // video with runDownloader()
    [HttpPost]
    public IResult Post([FromForm(Name = "url")]String url)
    {
        DownloadService myService = new DownloadService();
        myService.safeUrlParam(url);
        myService.runDownloader();
            
            // might not be needed but still there just in case of the error "media type unsupported"
            HttpContext.Response.Headers.Add("Content-Type","application/octet-stream");
            
            // returns a Stream of the read file
            Stream filestream = System.IO.File.OpenRead("downloaded-video");
            // this writes the Stream to myresult and we return it at the end of the codeblock
            // to the user (Client gets download in browser)
            IResult myresult = Results.File(filestream, "application/octet-stream", "downloaded-video.mp4", null, null , true );
            return myresult;
            
    }
}