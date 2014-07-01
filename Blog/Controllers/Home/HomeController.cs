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
        // repository instance
        BlogRepo blogData;
        public HomeController()
        {
            blogData = new BlogRepo(new BlogDbContext());
        }

        // Returns main page with a link on articles and voting bar 
        // View model is used to perform voting
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

        // Returns particular topic on id
        // View model is used in order to combine the topic and comments
        [HttpGet]
        public ActionResult Post(int Id)
        {
            TopicCommentVM toView = new TopicCommentVM();
            toView.topic = blogData.GetTopic(Id);
            return View(toView);
        }

        // Adds new comment on topic
        [HttpPost]
        public ActionResult Post(TopicCommentVM newCom)
        {
            if (newCom.CommentToAdd.Comment.AuthorName != null && newCom.CommentToAdd.Comment.CommentText != null)
            {
                TopicComment toAdd = new TopicComment();
                toAdd.Comment = newCom.CommentToAdd.Comment;
                blogData.SetCommentOnTopic(toAdd, newCom.topic.TopicId);
                return RedirectToAction("Post");
            }
            else
            {
                return RedirectToAction("Post");
            }
                
        }

        // Returns guests' book page
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
            ViewBag.ExistingComments = toView;
            return View();
        }

        // adds new guest book entry (weird solution...)
        [HttpPost]
        public ActionResult Comments(Comment newCom)
        {
            if (ModelState.IsValid)
            {
                newCom.PostedDate = DateTime.Now;
                newCom.isGuestEntry = true;
                blogData.SetComment(newCom);
                return RedirectToAction("Comments");
            }
            List<Comment> toView = new List<Comment>();
            IEnumerable<Comment> fromData = blogData.GetComments();
            foreach (Comment c in fromData)
            {
                if (c.isGuestEntry == true)
                {
                    toView.Add(c);
                }
            }
            ViewBag.ExistingComments = toView;
            return View();
        }

    }
}
