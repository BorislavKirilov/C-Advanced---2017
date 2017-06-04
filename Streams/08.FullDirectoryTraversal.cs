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

//            var files = new Dictionary<string, List<File>>();

//            // gets root dir
//            DirectoryInfo root = new DirectoryInfo(@"..\..\..");
//            var dirs = root.GetDirectories();

//            GetAllFilesInDirectory(files, root);
            
//            PrintFoundFiles(files);
//        }

//        private static void PrintFoundFiles(Dictionary<string, List<File>> files)
//        {
//            foreach (var entry in files.OrderByDescending(x => x.Value.Count))
//            {
//                Console.WriteLine(entry.Key);
//                foreach (var file in entry.Value.OrderBy(x => x.Size))
//                {
//                    Console.WriteLine($"--{file.Name}{entry.Key} - {file.Size}kb");
//                }
//            }
//        }

//        private static void GetAllFilesInDirectory(Dictionary<string, List<File>> files, DirectoryInfo di)
//        {
//            var filesInDirectory = di.GetFiles("*", SearchOption.AllDirectories);
//            foreach (var fileInfo in filesInDirectory)
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
//        }
//    }
//}
