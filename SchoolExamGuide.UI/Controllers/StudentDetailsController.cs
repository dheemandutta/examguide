
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolExamGuide.BL;
using SchoolExamGuide.Entities;
using System.Net.Http.Headers;

namespace SchoolExamGuide.UI.Controllers
{
    public class StudentDetailsController : Controller
    {
        // GET: StudentDetails
        public ActionResult Index()
        {
            GetStudentForDrp();
            GetClassMasterForDrp();
            GetDistrictMasterForDrp();
            GetStateMasterForDrp();

            return View();
        }

        public ActionResult SaveUpdateStudentDetails(StudentDetailsEntity studentDetails)
        {
            StudentDetailsBL studentDetailsBL = new StudentDetailsBL();
            int rowAffected = studentDetailsBL.SaveUpdateStudentDetails(studentDetails);
            return Json(rowAffected, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteStudentDetails(int ID)
        {
            StudentDetailsBL studentDetailsBL = new StudentDetailsBL();
            int rowAffected = studentDetailsBL.DeleteStudentDetails(ID);
            return Json(rowAffected, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStudentDetailsByID(int ID)
        {
            StudentDetailsBL studentDetailsBL = new StudentDetailsBL();
            return Json(studentDetailsBL.GetStudentDetailsByID(ID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadStudentDetailsPageWise()
        {
            int draw, start, length;
            int pageIndex = 0;

            if (null != Request.Form.GetValues("draw"))
            {
                draw = int.Parse(Request.Form.GetValues("draw").FirstOrDefault().ToString());
                start = int.Parse(Request.Form.GetValues("start").FirstOrDefault().ToString());
                length = int.Parse(Request.Form.GetValues("length").FirstOrDefault().ToString());
            }
            else
            {
                draw = 1;
                start = 0;
                length = 50;
            }

            if (start == 0)
            {
                pageIndex = 1;
            }
            else
            {
                pageIndex = (start / length) + 1;
            }

            StudentDetailsBL studentDetailsBL = new StudentDetailsBL();
            int totalrecords = 0;

            List<StudentDetailsEntity> list = new List<StudentDetailsEntity>();
            list = studentDetailsBL.GetStudentDetailsPagewise(pageIndex, ref totalrecords, length);

            var data = list;
            return Json(new { draw = draw, recordsFiltered = totalrecords, recordsTotal = totalrecords, data = data }, JsonRequestBehavior.AllowGet);
        }


        //for Student drp
        //[TraceFilterAttribute]
        public void GetStudentForDrp()
        {
            StudentDetailsBL studentDetailsBL = new StudentDetailsBL();
            List<StudentDetailsEntity> pocoList = new List<StudentDetailsEntity>();

            pocoList = studentDetailsBL.GetStudentForDrp();
            List<StudentDetailsEntity> itmasterList = new List<StudentDetailsEntity>();

            foreach (StudentDetailsEntity up in pocoList)
            {
                StudentDetailsEntity unt = new StudentDetailsEntity();
                unt.ID = up.ID;
                unt.Name = up.Name;

                itmasterList.Add(unt);
            }

            ViewBag.Student = itmasterList.Select(x =>
                                            new SelectListItem()
                                            {
                                                Text = x.Name,
                                                Value = x.ID.ToString()
                                            });

        }

        //for ClassMaster drp
        //[TraceFilterAttribute]
        public void GetClassMasterForDrp()
        {
            StudentDetailsBL studentDetailsBL = new StudentDetailsBL();
            List<StudentDetailsEntity> pocoList = new List<StudentDetailsEntity>();

            pocoList = studentDetailsBL.GetClassMasterForDrp();
            List<StudentDetailsEntity> itmasterList = new List<StudentDetailsEntity>();

            foreach (StudentDetailsEntity up in pocoList)
            {
                StudentDetailsEntity unt = new StudentDetailsEntity();
                unt.ID = up.ID;
                unt.ClassName = up.ClassName;

                itmasterList.Add(unt);
            }

            ViewBag.ClassMaster = itmasterList.Select(x =>
                                            new SelectListItem()
                                            {
                                                Text = x.ClassName,
                                                Value = x.ID.ToString()
                                            });

        }

        //for DistrictMaster drp
        //[TraceFilterAttribute]
        public void GetDistrictMasterForDrp()
        {
            StudentDetailsBL studentDetailsBL = new StudentDetailsBL();
            List<StudentDetailsEntity> pocoList = new List<StudentDetailsEntity>();

            pocoList = studentDetailsBL.GetDistrictMasterForDrp();
            List<StudentDetailsEntity> itmasterList = new List<StudentDetailsEntity>();

            foreach (StudentDetailsEntity up in pocoList)
            {
                StudentDetailsEntity unt = new StudentDetailsEntity();
                unt.ID = up.ID;
                unt.District = up.District;

                itmasterList.Add(unt);
            }

            ViewBag.DistrictMaster = itmasterList.Select(x =>
                                            new SelectListItem()
                                            {
                                                Text = x.District,
                                                Value = x.ID.ToString()
                                            });

        }

        //for StateMaster drp
        //[TraceFilterAttribute]
        public void GetStateMasterForDrp()
        {
            StudentDetailsBL studentDetailsBL = new StudentDetailsBL();
            List<StudentDetailsEntity> pocoList = new List<StudentDetailsEntity>();

            pocoList = studentDetailsBL.GetStateMasterForDrp();
            List<StudentDetailsEntity> itmasterList = new List<StudentDetailsEntity>();

            foreach (StudentDetailsEntity up in pocoList)
            {
                StudentDetailsEntity unt = new StudentDetailsEntity();
                unt.ID = up.ID;
                unt.State = up.State;

                itmasterList.Add(unt);
            }

            ViewBag.StateMaster = itmasterList.Select(x =>
                                            new SelectListItem()
                                            {
                                                Text = x.State,
                                                Value = x.ID.ToString()
                                            });

        }

    }
}