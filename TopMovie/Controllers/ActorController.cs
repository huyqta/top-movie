using Microsoft.AspNetCore.Mvc;
using Movie.Services.Models;
using System.Collections.Generic;
using System.Linq;
using TopMovie.Helpers;

namespace TopMovie.Controllers
{
    [AuthorizationAttribute]
    public class ActorController : Controller
    {
        webphimContext context = new webphimContext();

        public IActionResult Index()
        {
            //CategoriesMoviesModel model = new CategoriesMoviesModel();
            //model.categories = context.TbCategoryMovie.ToList();
            //model.movies = context.TbMovie.ToList();
            return View();
        }

        [HttpPost]
        public List<TbActor> GetAll()
        {
            //var draw = Request.Form.GetValues("draw").FirstOrDefault();
            //var start = Request.Form.GetValues("start").FirstOrDefault();
            //var length = Request.Form.GetValues("length").FirstOrDefault();
            //var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            //var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            //var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


            ////Paging Size (10,20,50,100)    
            //int pageSize = length != null ? Convert.ToInt32(length) : 0;
            //int skip = start != null ? Convert.ToInt32(start) : 0;
            //int recordsTotal = 0;

            //CategoriesMoviesModel model = new CategoriesMoviesModel();
            //model.categories = context.TbActor.ToList();
            //model.movies = context.TbMovie.ToList();
            return context.TbActor.ToList();
        }

        [HttpGet]
        public TbActor GetById(int id)
        {
            return context.TbActor.FirstOrDefault(c=>c.Id == id);
        }

        [HttpPost]
        public int Create([FromBody] TbActor actor)
        {
            context.TbActor.Add(actor);
            var result = context.SaveChanges();
            return result;
        }

        [HttpPost]
        public int Update([FromBody] TbActor actor)
        {
            var oldActor = context.TbActor.FirstOrDefault(c=>c.Id == actor.Id);
            context.Entry<TbActor>(oldActor).CurrentValues.SetValues(actor);
            var result = context.SaveChanges();
            return result;
        }

        [HttpGet]
        public int Delete(int id)
        {
            var actor = context.TbActor.FirstOrDefault(c => c.Id == id);
            context.TbActor.Remove(actor);
            var result = context.SaveChanges();
            return result;
        }
    }
}