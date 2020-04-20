using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolExamGuide.UI.Models
{
    public class QuestionMasterModel
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public decimal Marks { get; set; }

        public bool? IsActive { get; set; }

        public int SubjectID { get; set; }

        public int ClassID { get; set; }

        public string ImagePath { get; set; }
    }
}