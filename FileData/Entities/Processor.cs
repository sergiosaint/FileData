using System;
using System.Linq;

namespace FileData {
  public class Processor {
    private static readonly string[] SizeArguments = { "-s", "--s", @"/s", "--size" };
    private static readonly string[] VersionArguments = { "-v", "--v", @"/v", "--version" };
    public static readonly string Instructions = $"first argument must be one of { string.Join( ",", SizeArguments ) } to check the file size or {Environment.NewLine}" +
                                                 $"one of { string.Join( ",", VersionArguments ) } to check file version{Environment.NewLine}" +
                                                 $"second argument must be a file path{Environment.NewLine}" +
                                                 $"Examples:{Environment.NewLine}" +
                                                 $" '-v c:/test.txt'{Environment.NewLine}" +
                                                 $" '/s c:/test.txt'";

    private readonly IFileDetails _fileDetails;
    public Processor( IFileDetails fileDetails ) {
      _fileDetails = fileDetails;
    }

    public string Process( string[] args ) {
      if ( args == null || args.Length != 2 ) {
        throw new ArgumentException( "2 parameters are expected" );
      }

      if ( string.IsNullOrEmpty( args[1] ) ) {
        throw new ArgumentException( "Second parameter must be a valid file path" );
      }

      if ( SizeArguments.Contains( args[0] ) ) {
        return $"File Size: {_fileDetails.Size( args[1] )}Kb";
      }

      if ( VersionArguments.Contains( args[0] ) ) {
        return $"Version: {_fileDetails.Version( args[1] )}";
      }

      throw new ArgumentException( Instructions );
    }
  }
}
