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
            var url = "http://html-agility-pack.net/";
            var web = new HtmlWeb();
            var doc = web.Load(url);
        }
    }
}
