using System;
using testAAP.DB;

namespace testAAP.Models
{
    public class Comment
    {
        private AppraisalsContext context;
        public string testdrive_comment{ get; set; }
        public string engine_comment { get; set; }
        public string transmission_comment { get; set; }
        public string steering_comment { get; set; }
        public string brake_comment { get; set; }
        public string rearend_comment { get; set; }
    }
}
