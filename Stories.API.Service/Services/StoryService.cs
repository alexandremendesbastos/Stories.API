using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.API.Service.DTOs;
using Stories.API.Data.Services;
using Stories.API.Data.Models;
using Stories.API.Data.Interfaces;
using Stories.API.Service.Interfaces;

namespace Stories.API.Service.Services
{
    public class StoryService(IStoryRepository storyRepository) : IStoryService
    {
        private readonly IStoryRepository _storyRepository = storyRepository;
        public IEnumerable<StoryDTO> GetAll()
        {
            var stories = _storyRepository.GetAll();

            return stories.Select
                (s => new StoryDTO(s.Title, s.Id, s.Description, s.Department, s.QuantVotes));
        }
        public StoryDTO GetById(int id)
        {
            var story = _storyRepository.GetbyId(id);
            var storyDTO = new StoryDTO(story.Title, story.Id, story.Department, story.Description, story.QuantVotes);

            return storyDTO;
        }

        public void Add(StoryDTO storyDTO)
        {
            if (storyDTO == null)
            {
                throw new ArgumentNullException(nameof(storyDTO));
            }

            var story = new Story(storyDTO.Title, storyDTO.Description, storyDTO.Department, storyDTO.QuantVotes);

            _storyRepository.Add(story);
        }

        public void Delete(int id)
        {
            var existingStory = _storyRepository.GetbyId(id);
            if (existingStory != null) { }

            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }
            _storyRepository.Delete(existingStory);
        }

        public void AddVotes(VoteDTO voteDTO)
        {
            if (voteDTO == null)
            {
                throw new ArgumentNullException(nameof(voteDTO));
            }

            var vote = new Vote
            {
                StoryId = voteDTO.Storyid,
                UserId = voteDTO.Voterid,
                VoteValue = voteDTO.VoteValue
            };

            _storyRepository.AddVotes(vote);
        }

        public int GetPositiveVotes(int storyId)
        {
            return _storyRepository.GetPositiveVotes(storyId);
        }

        public int GetNegativeVotes(int storyId)
        {
            return _storyRepository.GetNegativeVotes(storyId);
        }
    }
}