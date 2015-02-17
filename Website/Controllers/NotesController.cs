using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{

    public class NotesController : Controller
    {
        // GET: Notes
        public ActionResult Index()
        {
            var model = new List<Note>();

            model.Add(new Note { Title = "Title 1", Contents = "LoremIpsum", DateCreated = DateTime.Now, NoteId = 0 } );
            model.Add(new Note { Title = "Title 2", Contents = "BaconIpsum", DateCreated = DateTime.Now, NoteId = 1 });
            model.Add(new Note { Title = "Title 3", Contents = "BananaIpsum", DateCreated = DateTime.Now, NoteId = 2 });
            model.Add(new Note { Title = "Title 4", Contents = "RandomIpsum", DateCreated = DateTime.Now, NoteId = 3 });

            return View(model);
        }









        public ActionResult Temp()
        {

            return View();
        }


    }

  
}