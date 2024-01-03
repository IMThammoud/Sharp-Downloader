namespace WebApplication3.Controllers;
// This class is used for setting the path of the binary and
// storing the URL that the client will pass through the form
// on the Index.HTML page
// setPathToBinary() sets the binary path depending on the OS youre running (windows/Linux)
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