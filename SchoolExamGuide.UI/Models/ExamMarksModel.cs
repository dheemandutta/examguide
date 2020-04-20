using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolExamGuide.UI.Models
{
    public class ExamMarksModel
    {
        public int ID { get; set; }

        public int StudentID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal MarksObtained { get; set; }

        public decimal TotalMarks { get; set; }
    }
}