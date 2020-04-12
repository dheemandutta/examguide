using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolExamGuide.UI.Models
{
    public class SubjectMasterModel
    {
        public int ID { get; set; }

        public string SubjectName { get; set; }

        public int ClassID { get; set; }
    }
}