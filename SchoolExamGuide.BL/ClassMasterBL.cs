using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolExamGuide.Entities;
using SchoolExamGuide.DAL;

namespace SchoolExamGuide.BL
{
    public class ClassMasterBL
    {
        public int SaveUpdateClassMaster(ClassMasterEntity classMaster)
        {
            ClassMasterDAL classMasterDal = new ClassMasterDAL();
            return classMasterDal.SaveUpdateClassMaster(classMaster);
        }

        public int DeleteClassMaster(int ID)
        {
            ClassMasterDAL classMasterDal = new ClassMasterDAL();
            return classMasterDal.DeleteClassMaster(ID);
        }

        public ClassMasterEntity GetClassMasterDetailsByID(int ID)
        {
            ClassMasterDAL classMasterDal = new ClassMasterDAL();
            return classMasterDal.GetClassMasterDetailsByID(ID);
        }

        public List<ClassMasterEntity> GetClassMasterDetailsPagewise(int pageIndex, ref int recordCount, int length)
        {
            ClassMasterDAL classMasterDal = new ClassMasterDAL();
            return classMasterDal.GetClassMasterDetailsPagewise(pageIndex, ref recordCount, length);
        }
    }
}
