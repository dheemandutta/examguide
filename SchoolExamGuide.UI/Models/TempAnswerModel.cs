using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolExamGuide.UI.Models
{
    public class TempAnswerModel
    {
        public int ID { get; set; }

        public int QuestionID { get; set; }

        public string ChoiceText { get; set; }

        public bool? IsAnswer { get; set; }

        public bool? IsUsedAnswer { get; set; }

        public int StudentID { get; set; }

        public int ChoiceID { get; set; }
    }
}