
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
    public class ClassMasterController : Controller
    {
        // GET: ClassMaster
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveUpdateClassMaster(ClassMasterEntity classMaster)
        {
            ClassMasterBL classMasterBl = new ClassMasterBL();
            int rowAffected = classMasterBl.SaveUpdateClassMaster(classMaster);
            return Json(rowAffected, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteClassMaster(int ID)
        {
            ClassMasterBL classMasterBl = new ClassMasterBL();
            int rowAffected = classMasterBl.DeleteClassMaster(ID);
            return Json(rowAffected, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetClassMasterDetailsByID(int ID)
        {
            ClassMasterBL classMasterBl = new ClassMasterBL();
            return Json(classMasterBl.GetClassMasterDetailsByID(ID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadClassMasterPageWise()
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

            ClassMasterBL classMasterBl = new ClassMasterBL();
            int totalrecords = 0;

            List<ClassMasterEntity> list = new List<ClassMasterEntity>();
            list = classMasterBl.GetClassMasterDetailsPagewise(pageIndex, ref totalrecords, length);

            var data = list;
            return Json(new { draw = draw, recordsFiltered = totalrecords, recordsTotal = totalrecords, data = data }, JsonRequestBehavior.AllowGet);
        }

    }
}