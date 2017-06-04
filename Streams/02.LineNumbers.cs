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
//            var buffer = new Queue<string>();
//            //populate buffer
//            PopulateBuffer(sr, buffer);

//            //creates file named index_numbered_lines.html in ..\..\TextFiles\index_numbered_lines.html
//            CreateLineNumberedFile(buffer);
//        }

//        private static void PopulateBuffer(StreamReader sr, Queue<string> buffer)
//        {
//            var line = sr.ReadLine();
//            var counter = 1;
//            while (line != null)
//            {
//                buffer.Enqueue($"Line {counter++}:{line}");
//                line = sr.ReadLine();
//            }
//        }

//        private static void CreateLineNumberedFile(Queue<string> buffer)
//        {
//            using (var sw = new StreamWriter(@"..\..\TextFiles\index_numbered_lines.html"))
//            {
//                while (buffer.Count > 0)
//                {
//                    sw.WriteLine(buffer.Dequeue());
//                }
//            }
//        }
//    }
//}
