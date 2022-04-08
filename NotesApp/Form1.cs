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
       
        private void PopulateNotes()
        {
            BindingSource bs= new BindingSource();
            bs.DataSource = _notes;
            grdNotes.DataSource = _notes;

        }

        private void ClearForm()
        {
            txtTitle.Text = string.Empty;
            txtNotes.Text = string.Empty;
        }

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
    }
}
