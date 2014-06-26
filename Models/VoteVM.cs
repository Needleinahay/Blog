using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class VoteVM
    {
        public List<Vote> votes { get; set; }
        public int selectedVote { get; set; }
    }
}
