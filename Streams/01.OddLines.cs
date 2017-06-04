//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _07.Exercise_StreamsAndFiles
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // reads a file named index.html in this directory
//            using (var sr = new StreamReader(@"..\..\TextFiles\index.html"))
//            {
//                ProcessFile(sr);
//            }
//        }

//        private static void ProcessFile(StreamReader sr)
//        {
//            var line = sr.ReadLine();
//            var odd = true;
//            while (line != null)
//            {
//                PrintIfOdd(line, odd);
//                line = sr.ReadLine();
//                odd = !odd;
//            }
//        }

//        private static void PrintIfOdd(string line, bool odd)
//        {
//            if (odd)
//            {
//                Console.WriteLine(line);
//            }
//        }
//    }
//}
