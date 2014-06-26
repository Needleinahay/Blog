using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    interface IVote
    {
        IEnumerable<Vote> GetVotes();
        void SetVote(int voted);
    }
}
