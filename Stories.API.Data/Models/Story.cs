using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.API.Data.Models
{
    public class Story
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public int QuantVotes { get; set; }

        private Story()
        {
        }

        public Story(string title, string description, string department, int quantVotes)
        {
            // Construtor público para criar uma nova instância de Story com valores iniciais.
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("The title not is null.", nameof(title));
            }

            Title = title;
            Description = description;
            Department = department;
            QuantVotes = quantVotes;
        }

        public List<Vote> Vote { get; set; } = new List<Vote>();
        
    }
}
