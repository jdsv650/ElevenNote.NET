using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class NoteService
    {
        /// <summary>
        /// Get all notes for a user
        /// </summary>
        /// <param name="requestingUserId"></param>
        /// <returns></returns>
        public List<NoteListViewModel> GetAll(String requestingUserId)
        {
            using (var context = Dependencies.DataContext)
            {
                return (from r in context.Notes
                        where r.ApplicationUserId == requestingUserId
                        select new NoteListViewModel()
                        {
                            DateCreated = r.DateCreated,
                            DateModified = r.DateModified,
                            Id = r.NoteId,
                            Title = r.Title
                        }).OrderBy(o => o.DateModified).ToList();
            }
        }

        /// <summary>
        /// Get a note by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestingUserId"></param>
        /// <returns></returns>
        public NoteDetailViewModel GetById(int id, String requestingUserId)
        {
            using (var context = Dependencies.DataContext)
            {
                if (UserOwnsNote(id, requestingUserId))
                    return (from r in context.Notes
                            where r.ApplicationUserId == requestingUserId
                            && r.NoteId == id
                            select new NoteDetailViewModel
                            {
                                DateCreated = r.DateCreated,
                                DateModified = r.DateModified,
                                Content = r.Contents,
                                Id = r.NoteId,
                                Title = r.Title
                            }).OrderBy(o => o.DateModified).SingleOrDefault();
                else
                    return null;
            }

        }


        /// <summary>
        /// Update a note
        /// </summary>
        /// <param name="model"></param>
        /// <param name="requestingUserId"></param>
        /// <returns></returns>
        public bool Update(NoteDetailViewModel model, String requestingUserId)
        {
            using (var context = Dependencies.DataContext)
            {
                if (UserOwnsNote(model.Id, requestingUserId))
                {
                    var note = (from r in context.Notes
                                where r.ApplicationUserId == requestingUserId
                                && r.NoteId == model.Id
                                select r).SingleOrDefault();

                    // Make sure we received a note back?
                    if (null == note) return false;
                    else
                    {
                        note.Title = model.Title;
                        note.Contents = model.Content;
                        note.DateModified = DateTime.Now;
                        return 1 == context.SaveChanges();   // 1 == # of items affected by SaveChanges
                    }
                }
                else
                    return false;
            }

        }

        /// <summary>
        /// Delete a note.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestingUserId"></param>
        /// <returns></returns>
        public bool Delete(int id, String requestingUserId)
        {
            using (var context = Dependencies.DataContext)
            {
                if (UserOwnsNote(id, requestingUserId))
                {
                    var note = (from r in context.Notes
                                where r.ApplicationUserId == requestingUserId
                                && r.NoteId == id
                                select r).SingleOrDefault();

                    // Make sure we received a note back?
                    if (null == note) return false;

                    context.Notes.Remove(note);
                    return 1 == context.SaveChanges();
                    
                }
                else
                    return false;

            }

        }

        /// <summary>
        /// Create a new note.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="requestingUserId"></param>
        /// <returns></returns>
        public bool Create(NoteDetailViewModel model, String requestingUserId)
        {
            using (var context = Dependencies.DataContext)
            {
                context.Notes.Add(new Models.Note
                {
                    ApplicationUserId = requestingUserId,
                    Contents = model.Content,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Title = model.Title
                });

                return 1 == context.SaveChanges();
            }
        }

        private bool UserOwnsNote(int id, string userId)
        {
            using (var context = Dependencies.DataContext)
            {
                //return context.Notes.Where(w => w.NoteId == id && w.ApplicationUserId == userId).Any();

                // this is better *
                return context.Notes.Any(a => a.NoteId == id && a.ApplicationUserId == userId);
            }
        }

    }
}
