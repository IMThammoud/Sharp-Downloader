using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;
using System.Resources;

namespace WebApplication3.Controllers;

[ApiController]
[Route("[controller]")]
public class VideosController : ControllerBase
{


    // Post: Pass the url to this endpoint, store it and use it to download a
    // video with runDownloader()
    [HttpPost]
    public IResult VideoDownload([FromForm(Name = "url")] String url)
    {
        DownloadService myService = new DownloadService();
        myService.safeUrlParam(url);
        myService.DownloadVideo();

        // might not be needed but still there just in case of the error "media type unsupported"
        HttpContext.Response.Headers.Add("Content-Type", "application/octet-stream");

        // returns a Stream of the read file
        Stream filestream = System.IO.File.OpenRead(myService.myDownloadObject.uniqueVideoName + ".mp4");
        // this writes the Stream to myresult and we return it at the end of the codeblock
        // to the user (Client gets download in browser)
        IResult myresult = Results.File(filestream, "application/octet-stream",
            myService.myDownloadObject.uniqueVideoName + ".mp4", null, null, true);
        return myresult;

    }
}