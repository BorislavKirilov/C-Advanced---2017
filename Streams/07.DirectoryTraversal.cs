//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _07.Exercise_StreamsAndFiles
//{
//    class File
//    {
//        public File(string name, double size)
//        {
//            this.Name = name;
//            this.Size = size;
//        }
//        public string Name { get; set; }
//        private double size;

//        public double Size
//        {
//            get
//            {
//                return this.size / 1000.0;
//            }
//            set { size = value; }
//        }

//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //get directory path
//            DirectoryInfo di = new DirectoryInfo(@"..\..\TextFiles\");
//            var fi = di.GetFiles("*");
//            var files = new Dictionary<string, List<File>>();

//            foreach (var fileInfo in fi)
//            {
//                var fileName = fileInfo.Name;
//                var fileExtension = fileInfo.Extension;
//                var fileSize = fileInfo.Length;
//                if (!files.ContainsKey(fileExtension))
//                {
//                    var list = new List<File>();
//                    files.Add(fileExtension, list);
//                }
//                var file = new File(fileName, fileSize);
//                files[fileExtension].Add(file);
//            }


//            foreach (var entry in files.OrderByDescending(x => x.Value.Count))
//            {
//                Console.WriteLine(entry.Key);
//                foreach (var file in entry.Value.OrderBy(x => x.Size))
//                {
//                    Console.WriteLine($"--{file.Name}{entry.Key} - {file.Size}kb");
//                }
//            }
//        }


//    }
//}
