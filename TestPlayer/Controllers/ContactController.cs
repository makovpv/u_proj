using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestPlayer.Models;
using DomainModel.Abstract;

namespace TestPlayer.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View();
        }

        
        public string Get()
        {
            string[] rrr = new string[] { "hhhhhhhh", "wwwwwww" };
            
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();

            return js.Serialize(rrr);
        }
        public string Get2()
        {
            return "RRRRRRRRR";
        }

        public string Get3()
        {
            Contact[] vv = new Contact[] {
                new Contact () {Id=120, Name="sdsdsds"},
                new Contact () {Id=230, Name="PPPPPPP"}
            };

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            return js.Serialize(vv);
        }

        public string Get4()
        {
            return (System.IO.File.OpenText(HttpContext.Server.MapPath(@"~\Content\TestData.txt")).ReadToEnd());
        }



        
        //needs to move to API controller
        /////[[HttpPost]]
        public void MyPostAction (string p_json_obj)
        {
        }

    }
}
