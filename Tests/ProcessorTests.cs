using System;
using FileData;
using FileData.Entities;
using FileData.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Tests {
  public class ProcessorTests
  {
    private Processor _processor;
    private IFileDetails _fileDetails;

    [SetUp]
    public void Setup()
    {
      _fileDetails = Substitute.For<IFileDetails>();
      _fileDetails.Version(null).ReturnsForAnyArgs("1.1.1" );
      _fileDetails.Size( null ).ReturnsForAnyArgs( 123 );

      _processor = new Processor( _fileDetails );
    }

    [Test]
    [TestCase( "-v c:/test extra" )]
    [TestCase( "-v" )]
    [TestCase( "" )]
    public void IncorrectNumberOfArgumentsThrowsException( string rawArgs ) {
      var args = rawArgs.Split( ' ' );
      var ex = Assert.Throws<ArgumentException>( () => _processor.Process( args ) );
      Assert.That( ex.Message, Is.EqualTo( "2 parameters are expected" ) );
    }

    [Test]
    public void NullArgumentsThrowsException() {
      var ex = Assert.Throws<ArgumentException>( () => _processor.Process( null ) );
      Assert.That( ex.Message, Is.EqualTo( "2 parameters are expected" ) );
    }

    [Test]
    [TestCase( "-v", "" )]
    [TestCase( "--v", "" )]
    [TestCase( "/v", "" )]
    [TestCase( "--version", "" )]
    [TestCase( "-s", "" )]
    [TestCase( "--s", "" )]
    [TestCase( "/s", "" )]
    [TestCase( "--size", "" )]
    [TestCase( "-v", null )]
    [TestCase( "--v", null )]
    [TestCase( "/v", null )]
    [TestCase( "--version", null )]
    [TestCase( "-s", null )]
    [TestCase( "--s", null )]
    [TestCase( "/s", null )]
    [TestCase( "--size", null )]
    public void IncorrectFilePathArgumentsThrowsException( string function, string filePath ) {
      var args = new string[] { function, filePath };
      var ex = Assert.Throws<ArgumentException>( () => _processor.Process( args ) );
      Assert.That( ex.Message, Is.EqualTo( "Second parameter must be a valid file path" ) );
    }

    [Test]
    public void NonExistingFunctionThrowsException() {
      var args = new string[] { "NonExistingFunction", "c:/test.txt" };
      var ex = Assert.Throws<ArgumentException>( () => _processor.Process( args ) );
      Assert.That( ex.Message, Is.EqualTo( Processor.Instructions ) );
    }

    [Test]
    [TestCase( "-v" )]
    [TestCase( "--v" )]
    [TestCase( "/v" )]
    [TestCase( "--version" )]
    public void WhenAskedForVersionFileVersionIsReturned( string versionVariant ) {
      var args = new string[] { versionVariant, "c:/test.txt" };
      Assert.That( _processor.Process( args ), Is.EqualTo( "Version: 1.1.1" ) );
    }

    [Test]
    [TestCase( "-s" )]
    [TestCase( "--s" )]
    [TestCase( "/s" )]
    [TestCase( "--size" )]
    public void WhenAskedForSizeFileSizeIsReturned( string sizeVariant )
    {
      var args = new string[] {sizeVariant, "c:/test.txt"};
      Assert.That( _processor.Process( args ), Is.EqualTo( "File Size: 123Kb" ) );
    }
  }
}