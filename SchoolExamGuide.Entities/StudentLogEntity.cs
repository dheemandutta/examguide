using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExamGuide.Entities
{
    public class StudentLogEntity
    {
        public int ID { get; set; }

        public int PageID { get; set; }

        public DateTime AccessDate { get; set; }
    }
}