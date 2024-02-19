using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.API.Service.DTOs
{
    public class StoryDTO(string title, int id, string description, string department, int quantVotes)
    {
        public int Id { get; set; } = id;
        public string Title { get; set; } = title;
        public string Description { get; set; } = description;
        public int QuantVotes { get; set; } = quantVotes;
        public string Department { get; set; } = department;
    }
}