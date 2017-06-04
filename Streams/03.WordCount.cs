//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace _07.Exercise_StreamsAndFiles
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // reads file named words.txt containing the words
//            using (var sr = new StreamReader(@"..\..\TextFiles\words.txt"))
//            {
//                var words = ProcessFile(sr);

//                // reads file named text.txt containing the text
//                using (var fr = new StreamReader(@"..\..\TextFiles\text.txt"))
//                {
//                    var counter = PopulateCounter(words, fr);

//                    // creates file result.txt containing the result
//                    using (var sw = new StreamWriter(@"..\..\TextFiles\result.txt"))
//                    {
//                        CreateFile(counter, sw);
//                    }

//                }

//            }
//        }

//        private static void CreateFile(Dictionary<string, int> counter, StreamWriter sw)
//        {
//            foreach (var entry in counter.OrderByDescending(x => x.Value))
//            {
//                sw.WriteLine($"{entry.Key} - {entry.Value}");
//            }
//        }

//        private static Dictionary<string, int> PopulateCounter(HashSet<string> words, StreamReader fr)
//        {
//            var counter = new Dictionary<string, int>();
//            var file = fr.ReadToEnd().ToLower();

//            foreach (var word in words)
//            {
//                var regex = $"\\b{word}\\b";
//                counter.Add(word, Regex.Matches(file, regex).Count);
//            }

//            return counter;
//        }

//        private static HashSet<string> ProcessFile(StreamReader sr)
//        {
//            var line = sr.ReadLine();
//            var words = new HashSet<string>();
//            while (line != null)
//            {
//                words.Add(line.Trim());
//                line = sr.ReadLine();
//            }

//            return words;
//        }
//    }
//}
