using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolExamGuide.Entities;
using SchoolExamGuide.DAL;

namespace SchoolExamGuide.BL
{
    public class ChapterMasterBL
    {
        public int SaveUpdateChapter(ChapterMasterEntity chapter)
        {
            ChapterMasterDAL chapterDal = new ChapterMasterDAL();
            return chapterDal.SaveUpdateChapter(chapter);
        }

        public int DeleteChapter(int ChapterID)
        {
            ChapterMasterDAL chapterDal = new ChapterMasterDAL();
            return chapterDal.DeleteChapter(ChapterID);
        }

        public ChapterMasterEntity ChapterDetailsByChapterID(int chapterID)
        {
            ChapterMasterDAL chapterDal = new ChapterMasterDAL();
            return chapterDal.ChapterDetailsByChapterID(chapterID);
        }

        public List<ChapterMasterEntity> GetSubjectDetailsPagewise(int pageIndex, ref int recordCount, int length)
        {
            ChapterMasterDAL chapterDal = new ChapterMasterDAL();
            return chapterDal.GetChaptertDetailsPagewise(pageIndex, ref recordCount, length);
        }

        public List<ChapterMasterEntity> GetChapterDetailsBySubjectID(int subjectID)
        {
            ChapterMasterDAL chapterDal = new ChapterMasterDAL();
            return chapterDal.GetChapterDetailsBySubjectID(subjectID);
        }

        public List<ChapterMasterEntity> GetChapterDetailsAll()
        {
            ChapterMasterDAL chapterDal = new ChapterMasterDAL();
            return chapterDal.GetChapterDetailsAll();
        }
    }
}
