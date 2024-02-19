using Stories.API.Data.Models;
using Stories.API.Data;
using Stories.API.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.API.Service.Interfaces
{
    public interface IStoryService
    {
        IEnumerable<StoryDTO> GetAll();
        StoryDTO GetById(int id);
        void Add(StoryDTO storyDTO);
        void Delete(int id);
        void AddVotes(VoteDTO votedto);
        int GetPositiveVotes(int storyId);
        int GetNegativeVotes(int storyId);
      
    }
}