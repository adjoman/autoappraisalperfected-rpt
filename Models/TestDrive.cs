using System;
using testAAP.DB;

namespace testAAP.Models
{
    public class TestDrive
    {
        private AppraisalsContext context;
        public string testdrive_comment{ get; set; }
        public string bouce_test { get; set; }
        public string suspension_noise { get; set; }
    }
}
