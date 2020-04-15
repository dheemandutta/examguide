using SchoolExamGuide.Entities;
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
    public class ChapterMasterController : Controller
    {
        // GET: ChapterMaster
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveUpdateChapterMaster(ChapterMasterEntity chapter)
        {
            ChapterMasterBL chapterBl= new ChapterMasterBL();
            int rowAffected = chapterBl.SaveUpdateChapter(chapter);
            return Json(rowAffected, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteChapterMaster(int ChapterID)
        {
            ChapterMasterBL chapterBl = new ChapterMasterBL();
            int rowAffected = chapterBl.DeleteChapter(ChapterID);
            return Json(rowAffected, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChapterDetailsByChapterID(int chapterID)
        {
            ChapterMasterBL chapterBl = new ChapterMasterBL();
            return Json(chapterBl.ChapterDetailsByChapterID(chapterID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadAllChapterPageWise()
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

            ChapterMasterBL chapterBl = new ChapterMasterBL();
            int totalrecords = 0;

            List<ChapterMasterEntity> chapterList = new List<ChapterMasterEntity>();
            chapterList = chapterBl.GetChapterDetailsPagewise(pageIndex, ref totalrecords, length);

            var data = chapterList;
            return Json(new { draw = draw, recordsFiltered = totalrecords, recordsTotal = totalrecords, data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetChapterDetailsBySubjectID(int subjectID)
        {
            ChapterMasterBL chapterBl = new ChapterMasterBL();
            return Json(chapterBl.GetChapterDetailsBySubjectID(subjectID), JsonRequestBehavior.AllowGet);
        }

        public void GetChapterDetailsAll()
        {
            ChapterMasterBL chapterBl = new ChapterMasterBL();
            List<ChapterMasterEntity> chapterList = new List<ChapterMasterEntity>();
            chapterList = chapterBl.GetChapterDetailsAll();
            ViewBag.getchapterall=chapterList.Select(x =>
                new SelectListItem
                {
                    Text=x.ChapterName,
                    Value=x.Id.ToString(),
                }
            );
        }
    }
}