﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    // Model of Topic. includes id, topic's title, content and the date of the post
    public class Topic
    {
        public Topic()
        {
            Comments = new List<TopicComment>();
        }
        public int TopicId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime  PublishDate { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<TopicComment> Comments { get; set; }
    }
}