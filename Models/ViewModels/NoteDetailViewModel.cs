using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class NoteDetailViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(Int32.MaxValue)]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name = "Created")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Last Modified")]
        public DateTime DateModified { get; set; }


    }
}
