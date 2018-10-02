using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ServerForTestingClient.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            if (userName == "admin" && password == "123")
            {
                return Json("ok");
            }
            else
            {
                return Json("error");
            }
        }

        [HttpPost]
        public ActionResult Login2(Login2Request data)
        {
            //dynamic data = JsonConvert.DeserializeObject<dynamic>(content);
            string userName = data.userName;
            string password = data.password;
            if (userName == "admin" && password == "123")
            {
                return Json("ok");
            }
            else
            {
                return Json("error");
            }
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            string userName = Request.Headers["UserName"];
            string password = Request.Headers["Password"];
            if (userName == "admin" && password == "123")
            {
                file.SaveAs(Server.MapPath("~/" + file.FileName));
                return Json("ok");
            }
            else
            {
                return Json("error");
            }
        }

        [HttpGet]
        public ActionResult Export()
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person { Name="dalong",Age=18});
            persons.Add(new Person { Name="ava",Age=17});

            this.Response.AddHeader("Content-Disposition",
                "attachment; filename=1.txt");

            MemoryStream ms = new MemoryStream();
            StreamWriter writer = new StreamWriter(ms);
            {
                foreach (var p in persons)
                {
                    writer.WriteLine(p.Name + ":" + p.Age);
                }
            }
            writer.Flush();
            ms.Position = 0;
            return File(ms, "text/plain");
        }
    }
    public class Login2Request
    {
        public string userName { get; set; }
        public string password { get; set; }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}