using System;
using HtmlAgilityPack;
using Movie.Services.Models;

namespace HCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            webphimContext context = new webphimContext();
            var url = "https://jav.guru/jav-actress-list";
            var web = new HtmlWeb();
            var html = web.Load(url);
            var htmlDoc = web.Load(url);
            
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id='byactress']/ul/li/a");

            //var actor = new TbActor()
            //{
            //    ActorName = nodes[0].InnerText,
            //    ActorType = "JAV",
            //    Title = nodes[0].Attributes.Count == 2 ? nodes[0].Attributes[1].Value : string.Empty
            //};
            foreach (var node in nodes)
            {
                context.TbActor.Add(new TbActor()
                {
                    ActorName = node.InnerText,
                    ActorType = "JAV",
                    Title = node.Attributes.Count == 2 ? node.Attributes[1].Value : string.Empty
                });
                Console.WriteLine(node.InnerText + "|" + nodes.IndexOf(node));
            }
            
            context.SaveChanges();
            Console.ReadLine();
        }
    }
}
