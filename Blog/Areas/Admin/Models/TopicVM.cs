using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Models
{
    public class TopicVM
    {
        public Topic topic { get; set; }
        public List<SelectListItem> TagsPossible { get; set; }
        public IEnumerable<string> SelectedTags { get; set; }

        public TopicVM()
        {
            TagsPossible = new List<SelectListItem>();
        }
    }
}