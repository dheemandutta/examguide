using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolExamGuide.Entities;
using SchoolExamGuide.DAL;

namespace SchoolExamGuide.BL
{
    public class SubjectMasterBL
    {
        public int SaveUpdateSubjectMaster(SubjectMasterEntity subject)
        {
            SubjectMasterDAL subjectDal = new SubjectMasterDAL();
            return subjectDal.SaveUpdateSubjectMaster(subject);
        }

        public int DeleteSubjectByID(int ID)
        {
            SubjectMasterDAL subjectDal = new SubjectMasterDAL();
            return subjectDal.DeleteSubjectByID(ID);
        }

        public SubjectMasterEntity GetSubjectDetailsBySubjectID(int ID)
        {
            SubjectMasterDAL subjectDal = new SubjectMasterDAL();
            return subjectDal.GetSubjectDetailsBySubjectID(ID);
        }

        public List<SubjectMasterEntity> GetSubjectDetailsPagewise(int pageIndex, ref int recordCount, int length)
        {
            SubjectMasterDAL subjectDal = new SubjectMasterDAL();
            return subjectDal.GetSubjectDetailsPagewise(pageIndex, ref recordCount, length);
        }

        public List<SubjectMasterEntity> GetSubjectDetailsByClassID(int classID)
        {
            SubjectMasterDAL subjectDal = new SubjectMasterDAL();
            return subjectDal.GetSubjectDetailsByClassID(classID);
        }

        public List<SubjectMasterEntity> GetSubjectDetailsAll()
        {
            SubjectMasterDAL subjectDal = new SubjectMasterDAL();
            return subjectDal.GetSubjectDetailsAll();
        }
        public List<SubjectMasterEntity> GetClassDetailsAll()
        {
            SubjectMasterDAL subjectDal = new SubjectMasterDAL();
            return subjectDal.GetClassDetailsAll();
        }

    }
}
