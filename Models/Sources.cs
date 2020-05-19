using System;
using testAAP.DB;

namespace testAAP.Models
{
    public class Sources
    {
        private AppraisalsContext context;
        public string vehicle_sources_nada { get; set; }
        public string vehicle_sources_kbb { get; set; }
        public string vehicle_sources_haggerty { get; set; }
        public string vehicle_sources_comment { get; set; }
    }
}
