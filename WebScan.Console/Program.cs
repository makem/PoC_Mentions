using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebScan.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var document = new HtmlDocument();
            System.Console.OutputEncoding = Encoding.Unicode;
            using (var client = new WebClient())
            {
                using (var stream = client.OpenRead("http://mmgp.ru/showthread.php?t=19304&page=268"))
                {
                    var reader = new StreamReader(stream, Encoding.GetEncoding("Windows-1251"));
                    var html = reader.ReadToEnd();
                    document.LoadHtml(html);
                }
            }
            var selection = document.DocumentNode.SelectNodes(@"//div[starts-with(@id,'post_message_')]");
            foreach (var node in selection)
            {
                System.Console.WriteLine("{0}", node.InnerText);
            }
            System.Console.WriteLine("привет");
        }
    }
}
