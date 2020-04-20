using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExamGuide.Entities
{
    public class SubjectMasterEntity
    {
        public int ID { get; set; }

        public string SubjectName { get; set; }

        public int ClassID { get; set; }

        public string ClassName { get; set; }
    }
}