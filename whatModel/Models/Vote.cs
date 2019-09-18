using System;
using System.Collections.Generic;
using System.Text;

namespace whatModel.Models
{
    public enum VoteType
    {
        Up,
        Down
    }

    public class Vote : Base
    {
        public VoteType VoteType { get; set; }

        public DateTime VoteDate { get; set; }

        public string UserId { get; set; }
    }
}
