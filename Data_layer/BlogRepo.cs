﻿using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog.Context_Management
{  // This class creates  DB context object and provides with tools that push/retrieve data
    public class BlogRepo : IRepo
    {
        private BlogDbContext context;

        public BlogRepo(BlogDbContext db)
        {
            context = db;
        }

        public IEnumerable<Topic> GetTopicsList()
        {
            IEnumerable<Topic> topics = context.Topics;
            return topics;
        }
        public Topic GetTopic(int id)
        {
            Topic toReturn = context.Topics.Find(id);
            //toReturn.Comments = GetCommentsOnTopic(toReturn).ToList();
            return toReturn;
        }
        public IEnumerable<Comment> GetComments()
        {
            IEnumerable<Comment> comments = context.Comments;
            return comments;
        }
        public IEnumerable<Tag> GetAllTags()
        {
            IEnumerable<Tag> tags = context.Tags;
            return tags;
        }
        public Tag GetTagById(int id)
        {
            return context.Tags.Find(id);
        }
        public void SetComment(Comment newCom)
        {
            newCom.PostedDate = DateTime.Now;
            context.Comments.Add(newCom);
            context.SaveChanges();
        }
        public void SetTopic(Topic newTop)
        {
            newTop.PublishDate = DateTime.Now;
            context.Topics.Add(newTop);
            context.SaveChanges();
        }

        public IEnumerable<Tag> GetTagsOfTopic(Topic topic)
        {
            return topic.Tags;
        }
        public IEnumerable<TopicComment> GetCommentsOnTopic(Topic topic)
        {
            return topic.Comments;
        }
        //public void SetCommentOnTopic(CommentOnTopic com, int topicId)
        //{
        //    com.baseComment.PostedDate = DateTime.Now;
        //    context.CommentsOnTopic.
        //}
    }
}