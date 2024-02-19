using Stories.API.Data.Models;
using Stories.API.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Azure.Core;

namespace Stories.API.Data.Services
{
    public class StoryRepository : IStoryRepository
    {
        private readonly MyDataContext _context;
        public StoryRepository(MyDataContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        public IEnumerable<Story> GetAll()
        {
            return _context.Stories.ToList();
        }
        public Story GetbyId(int id)
        {
            return _context.Stories.Find(id);
        }
        public void Add(Story story)
        {
            ArgumentNullException.ThrowIfNull(story, nameof(story));

            _context.Stories.Add(story);
            _context.SaveChanges();
        }
        public void Delete(Story story)
        {
            _context.Stories.Remove(story);
            _context.SaveChanges();
        }

        public void AddVotes(Vote vote)
        {
            ArgumentNullException.ThrowIfNull(vote, nameof(vote));

            _context.Votes.Add(vote);
            _context.SaveChanges();
        }

        public int GetPositiveVotes(int storyId)
        {
            ArgumentNullException.ThrowIfNull(storyId, nameof(storyId));

            return _context.Votes.Count(v => v.StoryId == storyId && v.VoteValue);

        }

        public int GetNegativeVotes(int storyId)
        {
            ArgumentNullException.ThrowIfNull(storyId , nameof(storyId));

            return _context.Votes.Count(v => v.StoryId == storyId && !v.VoteValue);           }
        }
}