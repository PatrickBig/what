using System;
using System.Collections.Generic;

namespace whatModel.Models
{
    public class Question : Base
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string PostUserId { get; set; }

        public DateTime? EditDate { get; set; }

        public string EditUserId { get; set; }

        public DateTime PostDate { get; set; }

        public ICollection<Vote> Votes { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<QuestionView> Views { get; set; }
    }
}
