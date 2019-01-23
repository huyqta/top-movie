using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movie.Services.Models;
using TopMovie.Helpers;
using TopMovie.Models;
using Google.Apis.Drive.v3;
using System.Net;

namespace TopMovie
{
    [AuthorizationAttribute]
    public class MovieController : Controller
    {
        webphimContext context = new webphimContext();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public List<TbMovie> GetAll()
        {
            CategoriesMoviesModel model = new CategoriesMoviesModel();
            model.categories = context.TbCategoryMovie.ToList();
            model.movies = context.TbMovie.ToList();
            return model.movies.ToList();
        }

        [HttpGet]
        public TbMovie GetById(int id)
        {
            return context.TbMovie.FirstOrDefault(c => c.Id == id);
        }

        [HttpPost]
        public int Create([FromBody] TbMovie movie)
        {
            context.TbMovie.Add(movie);
            var result = context.SaveChanges();
            return result;
        }

        [HttpPost]
        public int Update([FromBody] TbMovie movie)
        {
            var oldMovie = context.TbMovie.FirstOrDefault(c => c.Id == movie.Id);
            context.Entry<TbMovie>(oldMovie).CurrentValues.SetValues(movie);
            var result = context.SaveChanges();
            return result;
        }

        [HttpGet]
        public int Delete(int id)
        {
            var movie = context.TbMovie.FirstOrDefault(c => c.Id == id);
            context.TbMovie.Remove(movie);
            var result = context.SaveChanges();
            return result;
        }

        [HttpGet]
        public int AdjustLike([FromBody] int id, bool upvote)
        {
            var oldMovie = context.TbMovie.FirstOrDefault(c => c.Id == id);
            if (upvote)
            {
                oldMovie.CountLike += 1;
            }
            else
            {
                oldMovie.CountLike -= 1;
            }
            context.Entry<TbMovie>(oldMovie).CurrentValues.SetValues(oldMovie);
            var result = context.SaveChanges();
            return result;
        }

        [HttpGet]
        public JsonResult UpdateGoogleDriveLink()
        {
            List<string> listMovieUpdated = new List<string>();
            List<string> listMovieFailed = new List<string>();

            string apiOpenLoad = "https://api.openload.co/1/file/listfolder?login=549c7e7ad7483265&key=H5AkWvBr";
            var client = new WebClient();
            //client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
            var response = client.DownloadString(apiOpenLoad);
            Models.OpenLoadModel.RootObject result = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.OpenLoadModel.RootObject>(response);
            
            foreach (var file in result.result.files)
            {
                var movie = context.TbMovie.FirstOrDefault(m => file.name.Contains(m.ImdbId));
                if (movie != null && movie.GoogleDrive == string.Empty)
                {
                    movie.GoogleDrive = string.Format(@"<iframe src='{0}' scrolling='no' frameborder='0' width='700' height='430' allowfullscreen='true' webkitallowfullscreen='true' mozallowfullscreen='true'></iframe>", file.link.Replace("/f/", "/embed/"));
                    context.SaveChanges();
                    listMovieUpdated.Add(movie.ImdbId);
                }
                else
                {
                    listMovieFailed.Add(file.name.Split(" ")[0] == "EN" ? file.name.Split(" ")[1] : file.name.Split(" ")[0]);
                }
            }

            //GoogleDriveHelpers gd = new GoogleDriveHelpers();
            //var service = gd.InitGoogleDriveService();

            //FilesResource.ListRequest MylistRequest =
            //servce.Files.List();
            //MylistRequest.PageSize = 10;
            //MylistRequest.Fields = "nextPageToken, files(id, name)";

            //IList<Google.Apis.Drive.v3.Data.File> files = MylistRequest.Execute().Files;

            //if (files != null && files.Count > 0)
            //{
            //    foreach (var file in files)
            //    {
            //        var movie = context.TbMovie.FirstOrDefault(m => file.Name.Contains(m.ImdbId));
            //        if (movie != null && movie.GoogleDrive == string.Empty)
            //        {
            //            movie.GoogleDrive = string.Format("https://drive.google.com/file/d/{0}/preview", file.Id);
            //            context.SaveChanges();
            //            listMovieUpdated.Add(movie.ImdbId);
            //        }
            //        else
            //        {
            //            listMovieFailed.Add(file.Name.Split(" ")[0] == "EN" ? file.Name.Split(" ")[1] : file.Name.Split(" ")[0]);
            //        }
            //    }
            //}
            return Json(new { updated = listMovieUpdated, failed = listMovieFailed });
        }
    }
}