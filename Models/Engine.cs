using System;
using testAAP.DB;

namespace testAAP.Models
{
    public class Engine
    {
        private AppraisalsContext context;
        public string engine_comment{ get; set; }
        public string engine_size { get; set; }
        public string engine_performance { get; set; }
        public string oil_level_quality { get; set; }
    }
}
