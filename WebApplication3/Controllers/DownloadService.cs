
using System.Diagnostics;

namespace WebApplication3.Controllers;

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
        Process myprocess = Process.Start("./yt-dlp",binaryArguments+" -o downloaded-video "+myDownloadObject.myUrl);

        myprocess.Start();
    }
    
    
    
}