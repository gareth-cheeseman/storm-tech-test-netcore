using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Todo.Models;

namespace Todo.Filters
{
    public class JavascriptStatusFilter : IActionFilter, IPageFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as Controller;
            if (controller == null)
            {
                return;
            }

            var cookies = context.HttpContext.Request.Cookies;
            if (cookies.ContainsKey("hasjs") && cookies["hasjs"].Equals("true"))
            {
                ((Controller) context.Controller).ViewData.IsJavascriptOn(true);
            }
            else
            {
                ((Controller) context.Controller).ViewData.IsJavascriptOn(false);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var cookies = context.HttpContext.Request.Cookies;
            if (cookies.ContainsKey("hasjs") && cookies["hasjs"].Equals(false))
            {
                ((PageModel)context.HandlerInstance).PageContext.ViewData.IsJavascriptOn(false);
            }
            else
            {
                ((PageModel)context.HandlerInstance).PageContext.ViewData.IsJavascriptOn(true);
            }
            
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }
    }
}
