using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    public class Note
    {
        public string Tittle { get; set; }
        public string Notes { get; set; }
        public Note() { }
        public Note(string tittle, string notes) {
            Tittle = tittle;
            Notes = notes;
        }
    }
}
