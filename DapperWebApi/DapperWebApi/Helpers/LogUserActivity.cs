using Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace DapperWebApi.Helpers
{
    public class LogUserActivity<I, T> : IAsyncActionFilter where T: class, new() 
    {
        private Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary ModelState { get; set; }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            List<T> ts = new List<T>();
            var resultContext = await next();
            List<dynamic> dynamics = new List<dynamic>();

            string methodType = context.HttpContext.Request.Method;

            if (methodType == "GET")
            {
                // The action is a GET.
            }

            var c = context.ModelState.IsValid;
            ModelState = context.ModelState;
            if (c)
            {
                var keys = ModelState.Keys;
            }
            //var userId = int.Parse(resultContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var repo = resultContext.HttpContext.RequestServices.GetService<I>();

            //var user = await repo.GetUser(userId);
            //user.LastActivated = DateTime.Now;
            //await repo.SaveAll();

        }
    }
}
