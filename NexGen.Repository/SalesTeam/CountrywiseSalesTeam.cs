using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.Repository.SalesTeam
{
    public class CountrywiseSalesTeam
    {
        public string? Region { get; set; }
        public string? Country { get; set; }
        public int TFS { get; set; }
        public int TFC { get; set; }
        public int TFE { get; set; }
        public int Total { get; set; }
    }
}
