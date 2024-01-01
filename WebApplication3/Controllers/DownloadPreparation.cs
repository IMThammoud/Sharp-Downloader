namespace WebApplication3.Controllers;

public class DownloadPreparation
{
    public String pathToBinary = "./yt-dlp";

    public String myUrl;

    public String uniqueVideoName = "videos/"+"1";
    
    public String getUniqueVideoNameAudio = "videos/" + System.Guid.NewGuid();

    public String getPathToBinary()
    {
        return pathToBinary;
    }

    public String getMyUrl()
    {
        return myUrl;
    }

    public void setPathToBinary(String pathToBinary)
    {
        this.pathToBinary = pathToBinary;
    }

    public void setMyUrl(String myUrl)
    {
        this.myUrl = myUrl;
    }

    public void setBinaryType()
    {
        if (System.OperatingSystem.IsWindows())
        {
            setPathToBinary(".\\yt-dlp.exe");
        }
    }

}