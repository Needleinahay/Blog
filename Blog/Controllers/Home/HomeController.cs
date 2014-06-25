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
        BlogRepo blogData;
        public HomeController()
        {
            blogData = new BlogRepo(new BlogDbContext());
        }

        // Returns home page which includes link to topics' list
        [HttpGet]
        public ActionResult Index()
        {
            return View(blogData.GetVotes());
        }

        [HttpPost]
        public ActionResult Index(Vote voted)
        {
            blogData.SetVote(voted.VoteId);
            return View(blogData.GetVotes());
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

        // Returns comments' list leaved by guests earlier
        [HttpGet]
        public ActionResult Comments()
        {
            return View(blogData.GetComments());
        }

        // adds new comment to DB
        [HttpPost]
        public ActionResult Comments(Comment newCom)
        {
            newCom.PostedDate = DateTime.Now;
            blogData.SetComment(newCom);
            return View(blogData.GetComments());
        }

    }
}
