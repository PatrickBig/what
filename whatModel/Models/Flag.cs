using System;
using System.Collections.Generic;
using System.Text;

namespace whatModel.Models
{
    public enum FlagType
    {
        Mean,
        Outdated,
        Other
    }

    public class Flag : Base
    {
        public FlagType FlagType { get; set; }

        public string Other { get; set; }

        public DateTime FlagDate { get; set; }

        public string UserId { get; set; }
    }
}
