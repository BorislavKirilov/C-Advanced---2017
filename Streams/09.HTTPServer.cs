using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace _09.HTTPServer
{
    class Program
    {
        private const int Port = 8081;
        static void Main(string[] args)
        {
            var tcpListener = new TcpListener(IPAddress.Any, Port);
            tcpListener.Start();
            Console.WriteLine($"Experimental server listening on port {Port}...");

            while (!false)
            {
                using (NetworkStream stream = tcpListener.AcceptTcpClient().GetStream())
                {
                    byte[] requestBytes = new byte[4096];
                    stream.Read(requestBytes, 0, 4096);
                    var requestText = Encoding.UTF8.GetString(requestBytes);
                    var getRequestRegexPattern = @"GET\s+(.*?)\s+HTTP\/1.1";

                    var requestPath = Regex.Matches(requestText, getRequestRegexPattern)[0].Groups[1].ToString();

                    if (requestPath == "/")
                    {
                        byte[] bytes = System.IO.File.ReadAllBytes(@"..\..\TextFiles\index.html");

                        string header = "Content-type: text/html\r\n\r\n";
                        byte[] headerBytes = Encoding.UTF8.GetBytes(header);
                        stream.Write(headerBytes, 0, headerBytes.Length);
                        stream.Write(bytes, 0, bytes.Length);
                    }
                    else if (requestPath == "/info")
                    {
                        byte[] bytes = System.IO.File.ReadAllBytes(@"..\..\TextFiles\info.html");
                        string header = "Content-type: text/html\r\n\r\n";
                        byte[] headerBytes = Encoding.UTF8.GetBytes(header);
                        stream.Write(headerBytes, 0, headerBytes.Length);
                        stream.Write(bytes, 0, bytes.Length);
                    }
                    else
                    {
                        var htmlPath = @"..\..\TextFiles\error.html";
                        byte[] bytes = System.IO.File.ReadAllBytes(htmlPath);
                        string header = "Content-type: text/html\r\n\r\n";
                        byte[] headerBytes = Encoding.UTF8.GetBytes(header);
                        stream.Write(headerBytes, 0, headerBytes.Length);
                        stream.Write(bytes, 0, bytes.Length);
                    }

                }
            }

        }


    }
}
