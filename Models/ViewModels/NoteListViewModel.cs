using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class NoteListViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name="Created")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Last Modified")]
        public DateTime DateModified { get; set; }



    }
}
