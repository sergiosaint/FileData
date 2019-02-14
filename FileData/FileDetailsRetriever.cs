using ThirdPartyFileDetails = ThirdPartyTools.FileDetails;

namespace FileData {
  public class FileDetailsRetriever : IFileDetails
  {

    private readonly ThirdPartyFileDetails _fileDetails;

    public FileDetailsRetriever()
    {
      _fileDetails = new ThirdPartyFileDetails();
    }

    public string Version( string filePath )
    {
      return _fileDetails.Version( filePath );
    }

    public int Size(string filePath)
    {
      return _fileDetails.Size( filePath );
    }
  }
}
