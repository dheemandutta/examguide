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


        public int DeleteChapter(int Id)
        {
            ChapterMasterDAL chapterDal = new ChapterMasterDAL();
            return chapterDal.DeleteChapter(Id);
        }

        public ChapterMasterEntity ChapterDetailsByChapterID(int ID)
        {
            ChapterMasterDAL chapterDal = new ChapterMasterDAL();
            return chapterDal.ChapterDetailsByChapterID(ID);
        }

        public List<ChapterMasterEntity> GetChapterDetailsPagewise(int pageIndex, ref int recordCount, int length)
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

        public List<SubjectMasterEntity> GetClassDetailsAll()
        {
            SubjectMasterDAL subjectDal = new SubjectMasterDAL();
            return subjectDal.GetClassDetailsAll();
        }

        public List<ChapterMasterEntity> GetSubjectDetailsAll()
        {
            ChapterMasterDAL chapterDal = new ChapterMasterDAL();
            return chapterDal.GetSubjectDetailsAll();
        }

        public List<ChapterMasterEntity> GetSubjectDetailsByClassID(int classID)
        {
            ChapterMasterDAL chapterDal = new ChapterMasterDAL();
            return chapterDal.GetSubjectDetailsByClassID(classID);
        }

        public List<ChapterMasterEntity> GetChapterDetailsSubjectAndPagewise(int pageIndex, ref int recordCount, int length, int SubjectId)
        {
            ChapterMasterDAL chapterDal = new ChapterMasterDAL();
            return chapterDal.GetChaptertDetailsSubjectAndPagewise(pageIndex, ref recordCount, length, SubjectId);
        }
    }
}
