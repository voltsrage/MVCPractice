using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View("OurCompanyProducts");
        }

        public ActionResult Contacts()
        {
            ViewBag.Phone = "886-222-222-2222";
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult GetProductId(string id)
        {
            var products = new[]
            {
                new{ProductId = 1,ProductName = "English",PassingGrade=80},
                new{ProductId  = 2,ProductName = "Mathematics",PassingGrade=70},
                new{ProductId  = 3,ProductName = "Chinese",PassingGrade=65}
            };

            if(id == null)
            {
                return Content("Please enter a subject id" );
            }
            else
            {
                int prodId = 0;
                foreach(var pro in products)
                {
                    if(pro.ProductName == id)
                    {
                        prodId = pro.ProductId;
                    }
                }
                return Content(prodId.ToString());
            }
        }

        //Using Content Type to get content from a list or db
        //Use Content when you need to send a specific type of content such as plain text
        [Route("home/GetSubjectName/{subId}")]
        public ActionResult GetSubjectName(string subId)
        {
            var subjects = new[]
            {
                new{SubId = "Eng",SubName = "English",PassingGrade=80},
                new{SubId = "Math",SubName = "Mathematics",PassingGrade=70},
                new{SubId = "Ch",SubName = "Chinese",PassingGrade=65}
            };

            
            if(subId == null)
            {
                return Content("Please enter a subject id"+ subId);
            }
            else
            {
                string matchSubName = "";
                foreach (var item in subjects)
                {
                    if (subId == item.SubId)
                    {
                        matchSubName = item.SubName;
                    }

                }
                return Content(matchSubName);
            }           

            //return new ContentResult() { Content = matchSubName, ContentType = "text/plain" };
            
        }

        //File Action
        public ActionResult GetSubTest(string SubId)
        {
            string fileName = "~/" + SubId + "Test.pdf";
            return File(fileName,"application/pdf");
        }

        public ActionResult GetTestSite(string SubId)
        {
            var subjects = new[]
            {
                new{SubId = "Engl",SubName = "English",PassingGrade=80},
                new{SubId = "Math",SubName = "Mathematics",PassingGrade=70},
                new{SubId = "Ch",SubName = "Chinese",PassingGrade=65}
            };

            string urlLink = null;

            foreach(var item in subjects)
            {
                if(SubId == item.SubId)
                {
                    urlLink = "https://tw.search.yahoo.com/search?fr=yfp-search-sb&p=" + item.SubName + "Test";
                }
            }
            if (urlLink == null)
            {
                return Content("Invalid Sub Id");
            }
            else
            {
                return Redirect(urlLink);
            }            
        }

        public ActionResult StudentDetails()
        {
            ViewBag.StudentId = 101;
            ViewBag.StudentName = "Scott";
            ViewBag.Marks = 80.0;
            ViewBag.Year = "Grade 6";
            ViewBag.Subjects = new List<string>() { "Maths","English","Chinese" };
            ViewBag.SubjectGrades = new List<int>() { 90, 70, 80 };

            return View();
        }

        public ActionResult RequestExample()
        {
            ViewBag.Url = Request.Url;
            ViewBag.PhysicalPath = Request.PhysicalApplicationPath;
            ViewBag.Path = Request.Path;
            ViewBag.BrowserType = Request.Browser.Type;
            ViewBag.QueryString = Request.QueryString["n"];
            ViewBag.HttpMethod = Request.HttpMethod;
            ViewBag.Headers = Request.Headers["Accept"];

            return View();
        }

        public ActionResult ResponseExample()
        {
            Response.Write("Hi, just responding to your request, browser");

            return View();
        }
    }
}