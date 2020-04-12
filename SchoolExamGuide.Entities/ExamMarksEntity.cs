using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExamGuide.Entities
{
    public class ExamMarksEntity
    {
        public int ID { get; set; }

        public int StudentID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal MarksObtained { get; set; }

        public decimal TotalMarks { get; set; }
    }
}