﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCwithoutentity.Models
{
    public class StudentModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public DateTime dob { get; set; }

    }
}