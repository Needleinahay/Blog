using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Blog.Areas.Admin.Models
{
    public class TopicVM// : Blog.Models.Topic ????
    {
        public Topic topic { get; set; }
        public List<int> TagsPossible { get; set; }
        public IEnumerable<int> SelectedTags { get; set; }

        public TopicVM()
        {
            TagsPossible = new List<int>();
        }
    }
}