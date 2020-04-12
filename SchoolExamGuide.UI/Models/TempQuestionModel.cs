using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolExamGuide.UI.Models
{
    public class TempQuestionModel
    {
        public int ID { get; set; }

        public string QuestionText { get; set; }

        public decimal Marks { get; set; }

        public decimal RowNo { get; set; }

        public int StudentID { get; set; }
    }
}