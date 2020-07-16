using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Models
{
    public class Response
    {
        public string ResponseMessage { get; set; }

        public Response(string message)
        {
            ResponseMessage = message;
        }
    }
}
