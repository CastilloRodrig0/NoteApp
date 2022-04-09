using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesApp
{
    public partial class Form1 : Form
    { 

        List<Note> _notes = new List<Note>();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /*
 1.
 2.
 3.
 4.
 5.

  */
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtNotes.Text))
            {   
            var note = new Note();
            note.Tittle = txtTitle.Text;
            note.Notes = txtNotes.Text;
            _notes.Add(note);
            PopulateNotes();
            ClearForm();

            }
        }
        /*
 1.
 2.
 3.
 4.
 5.

  */

        private void PopulateNotes()
        {
            BindingSource bs= new BindingSource();
            bs.DataSource = _notes;
            grdNotes.DataSource = bs;

        }
        /*
 1.
 2.
 3.
 4.
 5.

  */

        private void ClearForm()
        {
            txtTitle.Text = string.Empty;
            txtNotes.Text = string.Empty;
        }
        /*
 1.
 2.
 3.
 4.
 5.

  */
        private void btnRead_Click(object sender, EventArgs e)
        {
            if(grdNotes.SelectedRows != null)
            {
                var title = grdNotes.SelectedCells[0].Value.ToString();
                var notes = GetNotesByTittle(title);

                txtTitle.Text = title;
                txtNotes.Text = notes;
            }
        }
        /*
 1.
 2.
 3.
 4.
 5.

  */
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grdNotes.SelectedRows != null)
            {
                var title = grdNotes.SelectedCells[0].Value.ToString();
                DeleteByTitle(title);
                PopulateNotes();
            }
        }
        /*
        1. Creo un objeto de tipo Note y lo inicializo en null
        2. recorro cada nota de mi lista de _notas
        3.un if comparando cada nota.tittle con el titulo que entra
        4.si lo encuentra lo guarda en el objeto noteToRemove
        5. un if diciendo si encontro un valor que borre la nota de la lista de notas
         */
        private void DeleteByTitle(string title)
        {
            Note noteToRemove = null;
            foreach (var note in _notes)
            {
                if (note.Tittle == title)
                    noteToRemove = note;
            }
            if (noteToRemove!=null)
            {
                _notes.Remove(noteToRemove);
            }
        }
        /*
        1.
        2.
        3.
        4.
        5.

         */
        private string GetNotesByTittle(string tittle)
        {
            var notes = string.Empty;
            foreach (var note in _notes)
            {
                if (note.Tittle == tittle)
                    notes = note.Notes;
            }
            return notes;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
