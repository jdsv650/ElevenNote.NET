using Models.ViewModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace WebServices.Controllers
{
    [Authorize]
    public class NotesController : ApiController
    {




        /// <summary>
        /// Gets all notes for current user.
        /// </summary>
        /// <returns></returns>
        public List<NoteListViewModel> GetNotes()
        {
            var service = new NoteService();
            var userId = User.Identity.GetUserId();
            return service.GetAll(userId);
            
        }

        /// <summary>
        /// Add a new note for current user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddNote(NoteDetailViewModel model)
        {
           var service = new NoteService();
           return service.Create(model, User.Identity.GetUserId());

        }


    }
}
