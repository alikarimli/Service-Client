using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
   
    [WebService(Namespace = "localhost")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
  
    public class ReviseService : System.Web.Services.WebService
    {
        [WebMethod]
        public string ReverseText(string text)
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
