using System;
using testAAP.DB;

namespace testAAP.Models
{
    public class Client
    {
        private AppraisalsContext context;
        public string customer_name { get; set; }
        public string customer_scope_of_work { get; set; }
    }
}
