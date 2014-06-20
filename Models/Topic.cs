using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    // Model of Topic. includes id, topic's title, content and the date of the post
    public class Topic
    {
        public int TopicId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime  PublishDate { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}