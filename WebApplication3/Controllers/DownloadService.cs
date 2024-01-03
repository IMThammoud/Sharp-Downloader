
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

    public void runDownloader()
    {
        String binaryArguments = "-S res,ext:mp4:m4a --recode mp4";
        myDownloadObject.setBinaryType();
        Process myprocess = Process.Start(myDownloadObject.pathToBinary,binaryArguments+" -o downloaded-video "+myDownloadObject.myUrl);


        myprocess.Start(); 
        myprocess.WaitForExit();
    }
    
    
    
}