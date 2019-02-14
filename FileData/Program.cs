using System;

namespace FileData
{
    public static class Program
    {
        public static void Main( string[] args )
        {
          var processor = new Processor( new FileDetailsRetriever() );
          //Console.WriteLine( processor.Process( args ) );

          while (true)
          {
            var input = Console.ReadLine();
            args = input.Split(' ');
            Console.WriteLine(processor.Process(args));
          }
        }
    }
}
