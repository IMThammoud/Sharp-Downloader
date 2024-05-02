using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

[ApiController]
[Route("[controller]")]
public class AudioController : ControllerBase
{
    [HttpPost]
    public IResult AudioDownload([FromForm(Name = "audio_url")]String url)
    {
        DownloadService myService = new DownloadService();
        myService.safeUrlParam(url);
        myService.DownloadAudio();
            
        // might not be needed but still there just in case of the error "media type unsupported"
        HttpContext.Response.Headers.Add("Content-Type","application/octet-stream");
            
        // returns a Stream of the read file
        Stream filestream = System.IO.File.OpenRead(myService.myDownloadObject.getUniqueAudioName + ".mp3");
        // this writes the Stream to myresult and we return it at the end of the codeblock
        // to the user (Client gets download in browser)
        IResult myresult = Results.File(filestream, "application/octet-stream", myService.myDownloadObject.getUniqueAudioName+".mp3", null, null , true );
        return myresult;
            
    }
}