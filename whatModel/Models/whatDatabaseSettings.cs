using System;
using System.Collections.Generic;
using System.Text;

namespace whatModel.Models
{
    public class whatDatabaseSettings : IwhatDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IwhatDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

}
