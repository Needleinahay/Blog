using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    // Model of Comment. includes id, comment's text, author's name and the date message was posted
    public class Tag
    {
        public int TagId { get; set; }
        public string TagWord { get; set; }

        public Tag() { }
        public Tag(string toBeWord)
        {
            TagWord = toBeWord;
        }

        public virtual ICollection<Topic> Topics { get; set; }
    }
}