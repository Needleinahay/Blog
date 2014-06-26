using Blog.Context_Management;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        IRepo blogData;
        public HomeController()
        {
            blogData = new BlogRepo(new BlogDbContext());
        }

        // Returns home page which includes link to topics' list
        public ActionResult Index()
        {
            return View();
        }

        // Returns topics' list
        public ActionResult Topics()
        {
            return View(blogData.GetTopicsList());
        }

        // Returns particular topic
        [HttpGet]
        public ActionResult Post(int Id)
        {
            return View(blogData.GetTopic(Id));
        }


        [HttpPost]
        public ActionResult Post(Topic newCom)
        {

            return View();
        }

        // Returns comments' list leaved by guests earlier
        [HttpGet]
        public ActionResult Comments()
        {
            List<Comment> toView = new List<Comment>();
            IEnumerable<Comment> fromData = blogData.GetComments();
            foreach (Comment c in fromData)
            {
                if (c.isGuestEntry == true)
                {
                    toView.Add(c);
                }
            }
            return View(toView);
        }

        // adds new comment to DB
        [HttpPost]
        public ActionResult Comments(Comment newCom)
        {
            newCom.PostedDate = DateTime.Now;
            newCom.isGuestEntry = true;
            blogData.SetComment(newCom);
            return RedirectToAction("Comments");
        }

    }
}
