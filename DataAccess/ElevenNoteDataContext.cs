using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ElevenNoteDataContext : DbContext
    {
        #region Constructor

        public ElevenNoteDataContext() :base("DefaultConnection")
        {

        }
        #endregion

        #region Datasets

        public DbSet<Note> Notes { get; set; }

        #endregion





    }
}
