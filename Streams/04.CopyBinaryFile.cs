//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _07.Exercise_StreamsAndFiles
//{
//    class Program
//    {
//        public const int Buffer = 154767;

//        static void Main(string[] args)
//        {
//            // reads a binary file named peppers.png in this directory
//            using (var br = new BinaryReader(new FileStream(@"..\..\TextFiles\peppers.png", FileMode.Open)))
//            {
//                using (var bw = new BinaryWriter(new FileStream(@"..\..\TextFiles\peppers_copy.png", FileMode.Create)))
//                {
//                    BinaryCopy(br, bw, Buffer);
//                }
//            }
//        }

//        private static void BinaryCopy(BinaryReader br, BinaryWriter bw, int bufferSize)
//        {
//            while (true)
//            {
//                var buffer = new byte[bufferSize];
//                var readBytes = br.Read(buffer, 0, buffer.Length);
//                bw.Write(buffer, 0, readBytes);
//                if (readBytes == 0)
//                {
//                    break;
//                }
//            }
//        }
//    }

//}
