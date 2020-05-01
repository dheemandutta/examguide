using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolExamGuide.UI.Models
{
    public class StudentDetailsModel
    {
        public int StudentId { get; set; }

        public string GuardiansName { get; set; }

        public string GuardiansMob { get; set; }

        public int StateId { get; set; }

        public int DistrictId { get; set; }

        public int ID { get; set; }


        public int ClassId { get; set; }


        public string Name { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string ClassName { get; set; }
    }
}