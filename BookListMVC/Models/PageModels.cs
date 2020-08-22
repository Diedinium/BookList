using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListMVC.Models
{
    public class IndexModel
    {
        public List<Book> Books { get; set; }
    }

    public class CreateModel
    {
        public Book Book { get; set; }
    }

    public class JsonExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var result = new ObjectResult(new
            {
                code = "500",
                message = "An unhandled server error occurred",
                detailedMessage = context.Exception.Message
            });

            result.StatusCode = 500;
            context.Result = result;
        }
    }
}
