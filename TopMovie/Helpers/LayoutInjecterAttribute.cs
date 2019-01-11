using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace TopMovie.Helpers
{
    public class LayoutInjecterAttribute : ActionFilterAttribute
    {
        private readonly string _masterName;
        public LayoutInjecterAttribute(string masterName)
        {
            _masterName = masterName;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //base.OnActionExecuted(filterContext);
            //var result = filterContext.Result as ViewResult;
            //if (result != null)
            //{
            //    result.ViewData["Layout"] = this.layout;
            //}
        }
    }
}
