using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolExamGuide.UI.Models
{
    public class StudentLogModel
    {
        public int ID { get; set; }

        public int PageID { get; set; }

        public DateTime AccessDate { get; set; }
    }
}