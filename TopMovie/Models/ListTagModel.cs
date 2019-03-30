using System;
using System.Collections.Generic;
using Movie.Services.Models;
using System.Linq;

namespace TopMovie.Models
{
    public class ListTagModel
    {
        webphimContext context = new webphimContext();

        public string TagType { get; set; }
        public string Action { get; set; }
        public string PageTitle { get; set; }

        private List<TagModel> _ListTagModel;

        public List<TagModel> ListTags
        {
            get
            {
                //if (this._ListTagModel == null) this._ListTagModel = new List<TagModel>();
                //switch (TagType)
                //{
                //    case "Tag":
                //        var allMovieTags = string.Join(",", context.TbMovie.Select(m => m.MovieTag)).Split(",").Distinct();
                //        foreach (var tag in allMovieTags)
                //        {
                //            this._ListTagModel.Add(new TagModel() { name = tag, quantity = context.TbMovie.Count(m => m.MovieTag.Contains(tag)) });
                //        }
                //        this.Action = "Tag";
                //        this.PageTitle = "List of Tags";
                //        break;
                //    case "Category":
                //        var allCategoryTags = string.Join(",", context.TbMovie.Select(m => m.CategoryTag)).Split(",").Distinct();
                //        foreach (var tag in allCategoryTags)
                //        {
                //            this._ListTagModel.Add(new TagModel() { name = tag, quantity = context.TbMovie.Count(m => m.CategoryTag.Contains(tag)) });
                //        }
                //        this.Action = "Category";
                //        this.PageTitle = "List of Categories";
                //        break;
                //    case "Actress":
                //        var allActorTags = string.Join(",", context.TbMovie.Select(m => m.ActorTag)).Split(",");
                //        this._ListTagModel = allActorTags.Distinct().Select(a => new TagModel() { name = a, quantity = allActorTags.Count(m => m.Contains(a)) }).ToList();
                //        //foreach (var tag in allActorTags)
                //        //{
                //        //    this._ListTagModel.Add(new TagModel() { name = tag, quantity = context.TbMovie.Count(m => m.ActorTag.Contains(tag)) });
                //        //}
                //        this.Action = "Actor";
                //        this.PageTitle = "List of Actress";
                //        break;
                //    case "Studio":
                //        var allStudioTags = string.Join(",", context.TbMovie.Select(m => m.StudioTag)).Split(",").Distinct();
                //        foreach (var tag in allStudioTags)
                //        {
                //            this._ListTagModel.Add(new TagModel() { name = tag, quantity = context.TbMovie.Count(m => m.StudioTag.Contains(tag)) });
                //        }
                //        this.Action = "Studio";
                //        this.PageTitle = "List of Studios";
                //        break;
                //}
                return this._ListTagModel;
            }
            set
            {
                this._ListTagModel = value;
            }
        }
    }

    public class TagModel
    {
        public int quantity { get; set; }
        public string name { get; set; }
    }
}