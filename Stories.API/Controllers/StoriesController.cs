using Microsoft.AspNetCore.Mvc;
using Stories.API.Service.DTOs;
using Stories.API.Service.Interfaces;
using System;

namespace Stories.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoriesController : ControllerBase
    {
        private readonly IStoryService _storyService;

        public StoriesController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var stories = _storyService.GetAll();

                if (stories == null)
                {
                    return NotFound("No stories found");
                }
                return Ok(stories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var story = _storyService.GetById(id);
                if (story == null)
                {
                    return NotFound($"Story with ID {id} not found");
                }
                return Ok(story);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] StoryDTO storyDTO)
        {
            try
            {
                _storyService.Add(storyDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _storyService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("AddVotes")]
        public IActionResult AddVotes([FromBody] VoteDTO voteDTO)
        {
            try
            {
                _storyService.AddVotes(voteDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("GetPositiveVotes/{storyId}")]
        public IActionResult GetPositiveVotes(int storyId)
        {
            try
            {
                var positiveVotes = _storyService.GetPositiveVotes(storyId);
                return Ok(positiveVotes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("GetNegativeVotes/{storyId}")]
        public IActionResult GetNegativeVotes(int storyId)
        {
            try
            {
                var negativeVotes = _storyService.GetNegativeVotes(storyId);
                return Ok(negativeVotes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
