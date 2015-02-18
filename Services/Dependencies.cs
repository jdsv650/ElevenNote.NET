using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class Dependencies
    {
        public static ElevenNoteDataContext DataContext
        {
            get
            {
                return new ElevenNoteDataContext();
            }

        }

    }
}
