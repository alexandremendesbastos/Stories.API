using System;
using Stories.API.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.API.Data.Interfaces
{
    public interface IStoryRepository
    {
        IEnumerable<Story> GetAll();
        Story GetbyId(int storyId);
        void Add(Story story);
        void AddVotes(Vote vote);
        int GetPositiveVotes(int storyId);
        int GetNegativeVotes(int storyId);
        void Delete(Story story);
    }
}
