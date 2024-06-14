using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
namespace WebApplication3.Controllers;

[ApiController]
[Route("[controller]")]
public class TranscriptController : ControllerBase
{
    
        [HttpPost]
        public IResult TranscriptDownload([FromForm(Name = "audio_url")]String url)
        
        {
            DownloadService myService = new DownloadService();
            myService.safeUrlParam(url);
            myService.DownloadAudio();
            
            // Here: Request to Whisper-Endpoint to get the transcript and return it in form of text in the return statement
            var client = new RestClient("http://localhost:8080");
            var request = new RestRequest("/v1/audio/transcriptions");
            // Ensure multipart/form-data encoding
            request.AlwaysMultipartFormData = true; // Ensure multipart/form-data encoding
            
            request.AddHeader("Content-Type","multipart/form-data");
            request.AddParameter("model", "whisper-1");
            request.AddFile("file",myService.myDownloadObject.getUniqueAudioName + ".mp3");

            RestResponse response = client.Post(request);

            // Parse the Json-Response to an object and filter the text using property "text"
            JObject responseAsObject = JObject.Parse(response.Content);
            string finalText = (string)responseAsObject.GetValue("text");

            
            String fileguid = Guid.NewGuid().ToString();
            FileStream myfilestream = System.IO.File.Create(fileguid + "transcript.txt");

            byte[] bytesFromfinaltext = Encoding.ASCII.GetBytes(finalText);
            myfilestream.Write(bytesFromfinaltext);
            
            IResult myresults = Results.File(bytesFromfinaltext,null,"transcript.txt");
            
            

            
            
           
            return myresults;
            
        }
    
}