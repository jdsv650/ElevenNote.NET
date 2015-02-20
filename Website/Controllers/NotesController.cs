using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Models.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Website.Controllers
{

    [Authorize]
    public class NotesController : Controller
    {
        NoteService _service = new NoteService();

        #region Index / Initial List

        // GET: Notes
        [HttpGet]
        public ActionResult Index()
        {
            var list = _service.GetAll(User.Identity.GetUserId());

            return View(list);
        }

        #endregion

        #region Add

        [HttpGet]
        [ActionName("Add")]
        public ActionResult AddGet()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        [ValidateInput(false)]
        public ActionResult AddPost(NoteDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _service.Create(model, User.Identity.GetUserId());
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
           
        }
        #endregion


        #region Edit

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult EditGet(int id)
        {
            // display note or 404
            var note = _service.GetById(id, User.Identity.GetUserId());
            if (null == note) return HttpNotFound();

            return View(note);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateInput(false)]
        public ActionResult EditPost(NoteDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _service.Update(model, User.Identity.GetUserId());
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }

        }


        #endregion


        #region View

        public ActionResult View(int id)
        {
            var note = _service.GetById(id, User.Identity.GetUserId());
            if (null == note) return HttpNotFound();
            else return View(note);

        }


        #endregion

        #region Delete

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteGet(int id)
        {
            // display note or 404
            var note = _service.GetById(id, User.Identity.GetUserId());
            if (null == note) return HttpNotFound();

            return View(note);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateInput(false)]
        public ActionResult DeletePost(int id)
        {
            var result = _service.Delete(id, User.Identity.GetUserId());
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ActionName("DeleteService")]
        public JsonResult DeletePostService(int id)
        {
            var result = _service.Delete(id, User.Identity.GetUserId());
            return Json(result);
        }



      

        #endregion






    }

  
}