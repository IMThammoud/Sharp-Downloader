using System.ComponentModel;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
namespace WebApplication3.Controllers;

[ApiController]
[Route("[controller]")]
public class TranscriptController : ControllerBase
{
    
        [HttpPost]
        public Task TranscriptDownload([FromForm(Name = "audio_url")]String url)
        
        {
            DownloadService myService = new DownloadService();
            myService.safeUrlParam(url);
            myService.DownloadAudio();
            
            // might not be needed but still there just in case of the error "media type unsupported"
            //HttpContext.Response.Headers.Add("Content-Type","application/octet-stream");
            
            // returns a Stream of the read file
            Stream filestream = System.IO.File.OpenRead(myService.myDownloadObject.getUniqueAudioName + ".mp3");

            // this writes the Stream to myresult and we return it at the end of the codeblock
            // to the user (Client gets download in browser)
            
            IResult myresult = Results.File(filestream, "application/octet-stream", myService.myDownloadObject.getUniqueAudioName+".mp3", null, null , true );
            
            // Here: Request to Whisper-Endpoint to get the transcript and return it in form of text in the return statement
            var client = new RestClient("http://localhost:8080/v1/audio/transcriptions");
            var request = new RestRequest("/v1/audio/transcriptions");
            // Ensure multipart/form-data encoding
            request.AlwaysMultipartFormData = true; // Ensure multipart/form-data encoding
            
            request.AddHeader("Content-Type","multipart/form-data");
            request.AddParameter("model", "whisper-1");
            request.AddFile("file",myService.myDownloadObject.getUniqueAudioName + ".mp3");

            client.PostAsync(request);
            // var myjson = JsonSerializer.Serialize(response);
            //Console.WriteLine(response.Result);
            // Console.WriteLine(response.ResponseStatus);
            // Console.WriteLine(response.ContentType);
            // Console.WriteLine(response.IsSuccessful);

            
            
            return client.PostAsync(request);
            
            
        }
    
}