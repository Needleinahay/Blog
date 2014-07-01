using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TopicCommentVM
    {
         public Topic topic { get; set; }
         public TopicComment CommentToAdd { get; set; }
         public TopicCommentVM()
         {
             CommentToAdd = new TopicComment();
         }
    }
}
