using System;
using testAAP.DB;

namespace testAAP.Models
{
    public class BasicInfo
    {
        private AppraisalsContext context;
        public string year{ get; set; }
        public string make { get; set; }
        public string mileage { get; set; }
        public string model { get; set; }
        public string vin { get; set; }
        public string location { get; set; }
        public string color { get; set; }
    }
}
