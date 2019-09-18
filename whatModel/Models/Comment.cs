using System;
using System.Collections.Generic;
using System.Text;

namespace whatModel.Models
{
    public class Comment : Base
    {
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public bool Deleted { get; set; }

        public string DeleteUserId { get; set; }

        public DateTime? EditDate { get; set; }

        public DateTime PostDate { get; set; }


        public ICollection<Flag> Flags { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}
