using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.API.Service.DTOs
{
    public class VoteDTO(int id, int storyid, int voterid, bool votevalue)
    {
        public int Id { get; set; } = id;
        public int Storyid { get; set; } = storyid;
        public int Voterid { get; set; } = voterid;
        public bool VoteValue { get; set; } = votevalue;
    }
}