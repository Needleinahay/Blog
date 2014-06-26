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
        BlogRepo blogData;
        public AdminController ()
	    {
            blogData = new BlogRepo(new BlogDbContext());
	    }

        public ActionResult Index()
        {
            TopicVM toCreate = new TopicVM();
            List<SelectListItem> tags = new List<SelectListItem>();
            foreach (Tag t in blogData.GetAllTags())
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Value = t.TagId.ToString(),
                    Text = t.TagWord.ToString(),
                    Selected = false
                };
                tags.Add(selectListItem);
            }
            toCreate.TagsPossible = tags;
            return View(toCreate);
        }

        [HttpPost]
        public ActionResult Index(TopicVM newTop)
        {
            Topic toSave = new Topic();
            toSave.Title = newTop.topic.Title;
            toSave.Content = newTop.topic.Content;

            if (newTop.SelectedTags == null)
            {
                toSave.Tags = new List<Tag>();
                toSave.Tags.Add(blogData.GetTagById(1));
            }
            else
            {
                toSave.Tags = new List<Tag>();
                foreach (string i in newTop.SelectedTags)
                {
                    toSave.Tags.Add(blogData.GetTagById(Convert.ToInt32(i)));
                }
            }
            blogData.SetTopic(toSave);
            return RedirectToAction("Index");
        }
    }
}
