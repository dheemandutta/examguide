﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExamGuide.Entities
{
    public class ChapterMasterEntity
    {
        public int Id { get; set; }
        public string ChapterName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}
