using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;



namespace AndDigital.CustomerAPI.Filters
{

    public class CustomExceptionFilter : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true; // mark exception as handled
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.StatusCode = 400;
            context.HttpContext.Response.ContentType = new MediaTypeHeaderValue("text/html").ToString();
            var home = string.Format("{0}://{1}", context.HttpContext.Request.Scheme, context.HttpContext.Request.Host);
            var htmlString = context.Exception.Message;
            context.HttpContext.Response.WriteAsync(htmlString, Encoding.UTF8);
        }


    }
}
