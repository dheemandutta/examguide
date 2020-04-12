using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolExamGuide.UI.Models
{
    public class ExamTimeEntity
    {
        public int ID { get; set; }

        public DateTime ExamTime { get; set; }

        public int StudentID { get; set; }
    }
}