﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExamGuide.Entities
{
    public class AnswerMasterEntity
    {
        public int ID { get; set; }

        public string AnswerText { get; set; }

        public bool? IsRightAnswer { get; set; }

        public int QuestionID { get; set; }
    }
}