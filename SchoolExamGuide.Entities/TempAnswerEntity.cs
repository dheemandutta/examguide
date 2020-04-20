using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExamGuide.Entities
{
    public class TempAnswerEntity
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