﻿using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog.Context_Management
{  // This class creates  DB context object and provides with tools that push/retrieve data
    public class BlogRepo : IRepo, ITag, IComment, ITopic, IVote
    {
        private BlogDbContext context;
        public BlogRepo(BlogDbContext db)
        {
            context = db;
        }

        //----------------IRepo----------------------
        public IEnumerable<Topic> GetTopicsList()
        {
            IEnumerable<Topic> topics = context.Topics;
            return topics;
        }

        //----------------ITopic----------------------
        public Topic GetTopic(int id)
        {
            Topic toReturn = context.Topics.Find(id);
            toReturn.Comments = GetCommentsOnTopic(toReturn).ToList();
            return toReturn;
        }
        public void SetTopic(Topic newTop)
        {
            newTop.PublishDate = DateTime.Now;
            context.Topics.Add(newTop);
            context.SaveChanges();
        }

        //----------------ITag----------------------
        public IEnumerable<Tag> GetTagsOfTopic(Topic topic)
        {
            return topic.Tags;
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

        //----------------IComment----------------------
        public IEnumerable<Comment> GetComments()
        {
            IEnumerable<Comment> comments = context.Comments;
            return comments;
        }
        public void SetComment(Comment newCom)
        {
            newCom.PostedDate = DateTime.Now;
            context.Comments.Add(newCom);
            context.SaveChanges();
        }

        //----------------IVote----------------------
        public IEnumerable<Vote> GetVotes()
        {
            return context.Votes;
        }
        public void SetVote(int voted)
        {
            context.Votes.Find(voted).Count++;
            context.SaveChanges();
        }
        public IEnumerable<TopicComment> GetCommentsOnTopic(Topic topic)
        {
            // hope no one will find tihs crap
            List<Comment> toBeComments = new List<Comment>();
            foreach (TopicComment c in topic.Comments)
            {
                toBeComments.Add(context.Comments.Find(c.CommentId));
            }
            return topic.Comments;
        }
    }
}