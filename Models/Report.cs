﻿using System;
using testAAP.Models;
using System.Collections.Generic;

namespace testAAP.Models
{
    public class Report
    {
        public Report()
        {
            basicInfo       = new BasicInfo();
            client          = new Client();
            signature       = new Signature();
            comments        = new Comment();
            transmission    = new Transmission();
            testDrive       = new TestDrive();
            engine          = new Engine();
            source          = new Sources();
        }

        public Sources source { get; set; }
        public Engine engine { get; set; }
        public TestDrive testDrive { get; set; }
        public BasicInfo basicInfo { get; set; }
        public Client client { get; set; }
        public Signature signature { get; set; }
        public List<Photo> photos { get; set; }
        public Comment comments { get; set; }
        public Transmission transmission { get; set; }
    }
}
