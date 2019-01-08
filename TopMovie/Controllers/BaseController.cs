using Microsoft.AspNetCore.Mvc;
using Movie.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopMovie.Controllers
{
    public abstract class BaseController<TEntity> : Controller where TEntity : class, new()
    {
        webphimContext context = new webphimContext();
        
        //[HttpGet]
        //public TEntity GetById(int id)
        //{
        //    var entity = new TEntity()
        //    {
        //        Id = id
        //    };
        //    return context.Find(<TEntity>.FirstOrDefault(c => c.Id == id);
        //}

        //public void Delete(int id)
        //{
        //    var entity = new TEntity()
        //    {
        //        Id = id
        //    };
        //    Context.Entry(entity).State = EntityState.Deleted;
        //    Context.SaveChanges();
        //}

        [HttpPost]
        public int Create([FromBody] TbCategoryMovie categoryData)
        {
            context.TbCategoryMovie.Add(categoryData);
            var result = context.SaveChanges();
            return result;
        }

        [HttpPost]
        public int Update([FromBody] TbCategoryMovie categoryData)
        {
            var oldCategory = context.TbCategoryMovie.FirstOrDefault(c => c.Id == categoryData.Id);
            context.Entry<TbCategoryMovie>(oldCategory).CurrentValues.SetValues(categoryData);
            var result = context.SaveChanges();
            return result;
        }

        [HttpGet]
        public int Delete(int id)
        {
            var category = context.TbCategoryMovie.FirstOrDefault(c => c.Id == id);
            context.TbCategoryMovie.Remove(category);
            var result = context.SaveChanges();
            return result;
        }
    }
}
