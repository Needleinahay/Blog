﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TopicComment
    {

        public Comment Comment { get; set; }
        [Key, ForeignKey("Comment")]
        public int CommentId { get; set; } 

        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
