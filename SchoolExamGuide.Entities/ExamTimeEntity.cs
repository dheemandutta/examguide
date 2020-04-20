using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExamGuide.Entities

{
    public class ExamTimeEntity
    {
        public int ID { get; set; }

        public DateTime ExamTime { get; set; }

        public int StudentID { get; set; }
    }
}