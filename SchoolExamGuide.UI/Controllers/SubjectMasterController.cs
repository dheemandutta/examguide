using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using Microsoft.Ajax.Utilities;
using SchoolExamGuide.BL;
using SchoolExamGuide.Entities;

namespace SchoolExamGuide.UI.Controllers
{
    public class SubjectMasterController : Controller
    {
        // GET: Subject
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SaveUpdateSubjectMaster(SubjectMasterEntity subject)
        {
            SubjectMasterBL subjectBl = new SubjectMasterBL();
            int rowAffected = subjectBl.SaveUpdateSubjectMaster(subject);
            return Json(rowAffected, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteSubjectMaster(int subjectID)
        {
            SubjectMasterBL subjectBl = new SubjectMasterBL();
            int rowAffected = subjectBl.DeleteSubjectByID(subjectID);
            return Json(rowAffected, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSubjectDetailsBySubjectID(int subjectID)
        {
            SubjectMasterBL subjectBl = new SubjectMasterBL();
            return Json(subjectBl.GetSubjectDetailsBySubjectID(subjectID), JsonRequestBehavior.AllowGet);
        }


        //GetSubjectDetailsPagewise(int pageIndex, ref int recordCount, int length)

        public JsonResult LoadAllSubjectPageWise()
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

            SubjectMasterBL subjectBl = new SubjectMasterBL();
            int totalrecords = 0;

            List<SubjectMasterEntity> subjectList = new List<SubjectMasterEntity>();
            subjectList= subjectBl.GetSubjectDetailsPagewise(pageIndex, ref totalrecords, length);

            var data = subjectList;
            return Json(new { draw = draw, recordsFiltered = totalrecords, recordsTotal = totalrecords, data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSubjectDetailsByClassID(int classID)
        {
            SubjectMasterBL subjectBl = new SubjectMasterBL();
            return Json(subjectBl.GetSubjectDetailsByClassID(classID), JsonRequestBehavior.AllowGet);
        }
   
        public void GetAllSubject()
        {
            SubjectMasterBL subjectBl = new SubjectMasterBL();
            List<SubjectMasterEntity> subjectList = new List<SubjectMasterEntity>();
            subjectList = subjectBl.GetSubjectDetailsAll();
            ViewBag.getsubjectall = subjectList.Select(x=>
                new SelectListItem
                {
                    Text = x.SubjectName,
                    Value=x.ID.ToString()
                });
        }
    }
}