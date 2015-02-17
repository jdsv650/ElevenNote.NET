using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Represents a note in the system
    /// </summary>
    public class Note
    {

        [Display(Name = "ID")]
        public int NoteId { get; set; }

        [Display(Name = "Application User Id")]
        public string ApplicationUserId { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Contents")]
        public string Contents { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime DateModified { get; set; }
    }
}




