using Evernote.ViewModel.Commands;
using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Evernote.ViewModel
{
    public class NotesVM
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }

        private Notebook selectedNotebook;

        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set
            {
                selectedNotebook = value;
            }
        }

        public ObservableCollection<Note> Notes { get; set; }

        public NewNoteCommand NewNoteCommand { get; set; }

        public NewNotebookCommand NewNotebookCommand { get; set; }

        public NotesVM()
        {
            NewNoteCommand = new NewNoteCommand(this);
            NewNotebookCommand = new NewNotebookCommand(this);
        }
    }
}
