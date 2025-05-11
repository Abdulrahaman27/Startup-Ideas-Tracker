using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace startupIdeasTracker
{
    public class StartupIdea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Problem { get; set; }
        public string TargetMarket { get; set; }
        public string Solution { get; set; }
        public string Status { get; set; }
        public string NextSteps { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
