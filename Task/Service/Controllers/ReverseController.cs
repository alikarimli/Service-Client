using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace Service.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReverseController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "API started!";
        }

        [HttpGet]
        public string  ReverseText()
        {
            StringValues text = "";
            var b = Request.Headers.TryGetValue("text", out text);
            if (b)
            {
                return Reverse(text);
            }
            return "Error";

        }
        private static string Reverse(string text)
        {
            string str = "";
            for (int i = text.Length - 1; i >= 0; i--)
            {
                str += text[i];
            }
            return str;
        }
    }
}
