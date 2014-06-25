using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Context_Management;

namespace Blog
{
    public interface IRepo
    {
        IEnumerable<Topic> GetTopicsList();
        Topic GetTopic(int id);
        IEnumerable<Comment> GetComments();
        IEnumerable<Tag> GetAllTags();
        Tag GetTagById(int id);
        void SetComment(Comment newCom);
        void SetTopic(Topic newTop);
        IEnumerable<Tag> GetTagsOfTopic(Topic topic);
        IEnumerable<TopicComment> GetCommentsOnTopic(Topic topic);

    }
}
