using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    interface ITag
    {
        IEnumerable<Tag> GetTagsOfTopic(Topic topic);
        IEnumerable<Tag> GetAllTags();
        Tag GetTagById(int id);
    }
}
