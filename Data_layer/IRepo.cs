﻿using Models;
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
    }
}
