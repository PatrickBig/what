using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace whatWeb.Models
{
    public class QuestionPreview
    {
        public string Title { get; set; }

        public string ContentPreview { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }
    }
}
