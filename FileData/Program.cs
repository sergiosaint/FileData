using System;
using FileData.Entities;

namespace FileData
{
    public static class Program
    {
        public static void Main( string[] args )
        {
          var processor = new Processor( new FileDetailsRetriever() );
          Console.WriteLine( processor.Process( args ) );
        }
    }
}
