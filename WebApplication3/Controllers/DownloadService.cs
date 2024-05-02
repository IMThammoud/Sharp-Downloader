
using System.Diagnostics;

namespace WebApplication3.Controllers;

// This class has the runDownloader() method that uses the yt-dlp binary
// The arguments for the binary can be edited here
// myProcess().waitForExit() will wait until the download of the video finishes before ending the block.
public class DownloadService
{
    public DownloadPreparation myDownloadObject = new DownloadPreparation();

    
    public static String currentDir = System.IO.Directory.GetCurrentDirectory();
    public String uniqueVideoName;
    public FileInfo myFile = new FileInfo(currentDir);
    
    public DownloadService()
    {
    this.uniqueVideoName = myDownloadObject.uniqueVideoName;

    }

    public void safeUrlParam(String url)
    {
        myDownloadObject.myUrl = url;
    }

    public void DownloadVideo()
    {
         String binaryArguments = "-S res,ext:mp4:m4a";
        // String binaryArguments = "-S res,ext:mp4:m4a --recode mp4";
        myDownloadObject.setBinaryType();
        // added .mp4 to filenime incase the arguments above leads to error when download cant be converted to mp4
        Process myprocess = Process.Start(myDownloadObject.pathToBinary,
            binaryArguments+" -o" + myDownloadObject.uniqueVideoName + ".mp4 " + myDownloadObject.myUrl);


        myprocess.Start(); 
        myprocess.WaitForExit();
    }

    public void DownloadAudio()
    {
        String binaryArguments = "--extract-audio --audio-format wav";
        
        myDownloadObject.setBinaryType();
        
        Process myProcess = Process.Start(myDownloadObject.pathToBinary,
            binaryArguments + " -o" + myDownloadObject.getUniqueAudioName + ".mp3 " + myDownloadObject.myUrl);

        myProcess.Start();
        myProcess.WaitForExit();
    }
    // DownloadTranscript() pulls the mp3 data and extract the text with AI using LocalAI Model "Whisper"
    public void DownloadTranscript()
    {
        String binaryArguments = "--extract-audio --audio-format wav";
        
        myDownloadObject.setBinaryType();
        
        Process myProcess = Process.Start(myDownloadObject.pathToBinary,
            binaryArguments + " -o" + myDownloadObject.getUniqueAudioName + ".mp3 " + myDownloadObject.myUrl);

        myProcess.Start();
        myProcess.WaitForExit();
    }
    
    
    
}