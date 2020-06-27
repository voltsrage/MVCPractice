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
            return View();
        }

        //Using Content Type to get content from a list or db
        //Use Content when you need to send a specific type of content such as plain text
        public ActionResult GetSubjectName(string SubId)
        {
            var subjects = new[]
            {
                new{SubId = "Eng",SubName = "English",PassingGrade=80},
                new{SubId = "Math",SubName = "Mathematics",PassingGrade=70},
                new{SubId = "Ch",SubName = "Chinese",PassingGrade=65}
            };

            string matchSubName = null;

            foreach(var item in subjects)
            {
                if(SubId == item.SubId)
                {
                    matchSubName = item.SubName;
                }
            }

            //return new ContentResult() { Content = matchSubName, ContentType = "text/plain" };
            return Content(matchSubName, "text/plain");
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
    }
}