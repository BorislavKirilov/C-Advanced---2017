//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.IO.Compression;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _07.Exercise_StreamsAndFiles
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {

//            var parts = 2; // keep it like this for tests
//            var homeDirectory = @"..\..\TextFiles";
//            var sourceFile = @"..\..\TextFiles\peppers.png";
//            // If you keep keep splice to two parts you shouldn't change anything here
//            List<string> partsNames = new List<string>() { "Part - 1.zip", "Part - 2.zip" };


//            Slice(sourceFile, homeDirectory, parts);

//            Assemble(partsNames, homeDirectory);

//        }

//        private static void Assemble(List<string> partsNames, string homeDirectory)
//        {
//            Console.WriteLine($"assembling");
//            int bufferSize = 4096;
//            var buffer = new byte[bufferSize];
//            using (var bw = new FileStream($"{homeDirectory}\\Result.zip", FileMode.Create))
//            {
//                using (var gs = new GZipStream(bw, CompressionMode.Compress))
//                {
//                    foreach (var part in partsNames)
//                    {

//                        using (var br = new FileStream($"{homeDirectory}\\{part}", FileMode.Open))
//                        {
//                            using (var dcmp = new GZipStream(br, CompressionMode.Decompress))
//                            {
//                                var readBytes = dcmp.Read(buffer, 0, buffer.Length);

//                                while (true)
//                                {
//                                    if (readBytes == 0)
//                                    {
//                                        break;
//                                    }
//                                    gs.Write(buffer, 0, readBytes);
//                                    readBytes = dcmp.Read(buffer, 0, buffer.Length);
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//        }

//        private static bool Slice(string sourceFile, string homeDirectory, int parts)
//        {

//            Console.WriteLine("slicing");
//            int bufferSize = 4096;
//            long fileSize = GetFileSize(sourceFile, bufferSize);
//            var buffer = new byte[bufferSize];
//            long pageSize = fileSize / parts;


//            using (var br = new BinaryReader(new FileStream(sourceFile, FileMode.Open)))
//            {
//                var part = 1;
//                while (true)
//                {
//                    var thisPartSize = 0;

//                    using (var bw = new FileStream($"{homeDirectory}\\Part - {part}.zip", FileMode.OpenOrCreate))
//                    {
//                        int readBytes = 0;
//                        using (var gs = new GZipStream(bw, CompressionMode.Compress, false))
//                        {
//                            while (true)
//                            {
//                                readBytes = br.Read(buffer, 0, buffer.Length);
//                                gs.Write(buffer, 0, readBytes);
//                                thisPartSize += buffer.Length;

//                                if (thisPartSize >= pageSize)
//                                {
//                                    part++;
//                                    break;
//                                }

//                                if (readBytes == 0)
//                                {
//                                    return true;
//                                }

//                            }
//                        }
//                    }
//                }
//            }
//        }

//        private static long GetFileSize(string sourceFile, int bufferSize)
//        {
//            long fileSize = 0;
//            using (var br = new BinaryReader(new FileStream(sourceFile, FileMode.Open)))
//            {
//                while (true)
//                {
//                    var buffer = new byte[bufferSize];
//                    var readBytes = br.Read(buffer, 0, buffer.Length);

//                    fileSize += buffer.Length;

//                    if (readBytes == 0)
//                    {
//                        break;
//                    }
//                }
//            }
//            return fileSize;
//        }
//    }
//}
