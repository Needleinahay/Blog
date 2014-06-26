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

        // Returns main page with a link on articles and voting bar 
        // ViewModel is used to perform voting
        [HttpGet]
        public ActionResult Index()
        {
            List<Vote> votes = blogData.GetVotes().ToList();
            VoteVM votesToView = new VoteVM();
            votesToView.votes = votes;

            return View(votesToView);
        }

        //Saves voting results
        [HttpPost]
        public ActionResult Index(VoteVM v)
        {
            blogData.SetVote(v.selectedVote);
            return RedirectToAction("Index");
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
