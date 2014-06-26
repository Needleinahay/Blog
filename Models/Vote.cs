using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Vote
    {
        public int VoteId { get; set; }
        public string Position { get; set; }
        public int Count { get; set; }
    }
}
