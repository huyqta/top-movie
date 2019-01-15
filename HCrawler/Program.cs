using System;
using HtmlAgilityPack;
using Movie.Services.Models;
using System.Globalization;

namespace HCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var site_url = "https://javfor.me";
                Console.WriteLine("Hello World!");
                webphimContext context = new webphimContext();
                var url = "https://javfor.me/list/hot/3.html";
                var web = new HtmlWeb();
                var html = web.Load(url);
                var htmlDoc = web.Load(url);
                var movie_url = string.Empty;
                int index = 1;
                var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='video-img']/a");
                foreach (var node in nodes)
                {
                    var movie = new TbMovie();
                    movie_url = site_url + node.Attributes[0].Value;
                    htmlDoc = web.Load(movie_url);
                    //movie.GoogleDrive = movie_url;
                    movie.MovieName = htmlDoc.DocumentNode.SelectNodes("//h5[@class='py-2']")[0].InnerHtml;
                    movie.PosterUrl = node.ChildNodes[1].Attributes[1].Value;
                    movie.ImageUrl = movie.PosterUrl;
                    var movie_infor = htmlDoc.DocumentNode.SelectNodes("//div[@class='movie-description mt-3']/div");
                    for (int i = 0; i < 4; i++)
                    {
                        movie.ReleaseDate = DateTime.ParseExact(movie_infor[0].InnerText.Split(":")[1].Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        movie.ActorTag = movie_infor[1].InnerText.Split(":")[1].Trim();
                        movie.StudioTag = movie_infor[2].InnerText.Split(":")[1].Trim();
                        movie.MovieTag = movie_infor[3].InnerText.Split(":")[1].Trim();
                        movie.CategoryTag = "JAV,HD";
                        movie.Country = "Japan";
                        movie.ImdbId = movie.MovieName.Split(" ")[0];
                        movie.StudioTag = movie.ImdbId.Split("-")[0];
                        movie.MovieType = "PS";
                    }
                    context.TbMovie.Add(movie);
                    Console.WriteLine(index + "-" + movie.ImdbId);
                    index++;
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            
            // Actor crawler
            //var actor = new TbActor()
            //{
            //    ActorName = nodes[0].InnerText,
            //    ActorType = "JAV",
            //    Title = nodes[0].Attributes.Count == 2 ? nodes[0].Attributes[1].Value : string.Empty
            //};
            //foreach (var node in nodes)
            //{
            //    context.TbActor.Add(new TbActor()
            //    {
            //        ActorName = node.InnerText,
            //        ActorType = "JAV",
            //        Title = node.Attributes.Count == 2 ? node.Attributes[1].Value : string.Empty
            //    });
            //    Console.WriteLine(node.InnerText + "|" + nodes.IndexOf(node));
            //}

            //context.SaveChanges();
            //Console.ReadLine();
        }

        static string UppercaseWords(string value)
        {
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }
    }
}
