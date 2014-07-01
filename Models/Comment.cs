﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    // Model of Comment. includes id, comment's text, author's name and the date message was posted
    public class Comment
    {
        public int CommentId { get; set; }
        [Required]
        public string CommentText { get; set; }
        [Required]
        public string AuthorName { get; set; }
        public DateTime PostedDate { get; set; }

        public bool isGuestEntry { get; set; }
    }
}