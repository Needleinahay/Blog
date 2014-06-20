using Blog.Areas.Admin.Models;
using Blog.Context_Management;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        IRepo blogData;
        public AdminController ()
	    {
            blogData = new BlogRepo(new BlogDbContext());
	    }

        public ActionResult Index()
        {
            TopicVM toCreate = new TopicVM();
            foreach (Tag t in blogData.GetAllTags())
            { 
                //toCreate.TagsPossible.Add(t);
            }
            return View(toCreate);//toCreate);
        }

        [HttpPost]
        public ActionResult Index(TopicVM newTop)
        {
            Topic toSave = new Topic();
            toSave.Title = newTop.topic.Title;
            toSave.Tags = newTop.topic.Tags;
            toSave.Content = newTop.topic.Content;
            blogData.SetTopic(toSave);
            return RedirectToAction("Index");
        }
    }
}
