using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using whatModel.Models;

namespace whatWeb.Models
{
    public class QuestionPreview
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public int Votes { get; set; }

        public int Views { get; set; }

        public int Answers { get; set; }

        public DateTime PostDate { get; set; }

        public string UserId { get; set; }

        // Limit the tags
        public List<Tag> Tags { get; set; }
    }
}
