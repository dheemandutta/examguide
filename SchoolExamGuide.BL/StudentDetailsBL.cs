using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolExamGuide.Entities;
using SchoolExamGuide.DAL;

namespace SchoolExamGuide.BL
{
    public class StudentDetailsBL
    {
        public int SaveUpdateStudentDetails(StudentDetailsEntity studentDetails)
        {
            StudentDetailsDAL studentDetailsDAL = new StudentDetailsDAL();
            return studentDetailsDAL.SaveUpdateStudentDetails(studentDetails);
        }

        public int DeleteStudentDetails(int ID)
        {
            StudentDetailsDAL studentDetailsDAL = new StudentDetailsDAL();
            return studentDetailsDAL.DeleteStudentDetails(ID);
        }

        public StudentDetailsEntity GetStudentDetailsByID(int ID)
        {
            StudentDetailsDAL studentDetailsDAL = new StudentDetailsDAL();
            return studentDetailsDAL.GetStudentDetailsByID(ID);
        }

        public List<StudentDetailsEntity> GetStudentDetailsPagewise(int pageIndex, ref int recordCount, int length)
        {
            StudentDetailsDAL studentDetailsDAL = new StudentDetailsDAL();
            return studentDetailsDAL.GetStudentDetailsPagewise(pageIndex, ref recordCount, length);
        }


        //for Student drp
        public List<StudentDetailsEntity> GetStudentForDrp()
        {
            StudentDetailsDAL studentDetailsDAL = new StudentDetailsDAL();
            return studentDetailsDAL.GetStudentForDrp();
        }

        //for ClassMaster drp
        public List<StudentDetailsEntity> GetClassMasterForDrp()
        {
            StudentDetailsDAL studentDetailsDAL = new StudentDetailsDAL();
            return studentDetailsDAL.GetClassMasterForDrp();
        }

        //for DistrictMaster drp
        public List<StudentDetailsEntity> GetDistrictMasterForDrp()
        {
            StudentDetailsDAL studentDetailsDAL = new StudentDetailsDAL();
            return studentDetailsDAL.GetDistrictMasterForDrp();
        }

        //for StateMaster drp
        public List<StudentDetailsEntity> GetStateMasterForDrp()
        {
            StudentDetailsDAL studentDetailsDAL = new StudentDetailsDAL();
            return studentDetailsDAL.GetStateMasterForDrp();
        }

    }
}
