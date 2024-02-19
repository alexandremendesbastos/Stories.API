using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.API.Data.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int StoryId { get; set; }
        public int UserId { get; set; }
        public bool VoteValue { get; set; }
 
        public Story Story { get; set; }
        public User User { get; set; }
    }
}
