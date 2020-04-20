using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolExamGuide.UI.Models
{
    public class AnswerMasterModel
    {
        public int ID { get; set; }

        public string AnswerText { get; set; }

        public bool? IsRightAnswer { get; set; }

        public int QuestionID { get; set; }
    }
}