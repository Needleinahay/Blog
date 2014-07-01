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
        // instance of repository
        BlogRepo blogData;
        public AdminController ()
	    {
            blogData = new BlogRepo(new BlogDbContext());
	    }

        [HttpGet]
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


        // Very heavy actions... Probably impossible to reduce since using server validation?
        [HttpPost]
        public ActionResult Index(TopicVM newTop)
        {
            if (ModelState.IsValid)
            {
                Topic toSave = new Topic();
                toSave.Title = newTop.topic.Title;
                toSave.Content = newTop.topic.Content;
                toSave.Tags = new List<Tag>();
                if (newTop.SelectedTags == null)
                {
                    toSave.Tags.Add(blogData.GetTagById(1));
                }
                else
                {
                    foreach (string i in newTop.SelectedTags)
                    {
                        toSave.Tags.Add(blogData.GetTagById(Convert.ToInt32(i)));
                    }
                }
                blogData.SetTopic(toSave);
                return RedirectToAction("Index");
            }


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
    }
}
