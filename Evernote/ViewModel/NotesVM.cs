﻿using Evernote.ViewModel.Commands;
using Evernote.ViewModel.Helpers;
using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Evernote.ViewModel
{
    public class NotesVM : INotifyPropertyChanged
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }
        public ObservableCollection<Note> Notes { get; set; }

        private Notebook selectedNotebook;

        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set
            {
                selectedNotebook = value;
                OnPropertyChanged("SelectedNotebook");
                GetNotes();
            }
        }

        public NewNotebookCommand NewNotebookCommand { get; set; }

        public NewNoteCommand NewNoteCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public NotesVM()
        {
            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);

            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();

            GetNotebooks();
        }

        public void CreateNotebook()
        {
            Notebook newNotebook = new Notebook { Name = "Notebook" };

            DatabaseHelper.Insert(newNotebook);

            GetNotebooks();
        }

        public void CreateNote(int notebookId)
        {
            Note newNote = new Note
            {
                NotebookId = notebookId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Title = $"Note for {DateTime.Now}"
            };

            DatabaseHelper.Insert(newNote);

            GetNotes();
        }

        private void GetNotebooks()
        {
            var notebooks = DatabaseHelper.Read<Notebook>();
            Notebooks.Clear();
            foreach (var notebook in notebooks)
            {
                Notebooks.Add(notebook);
            }
        }

        private void GetNotes()
        {
            if (SelectedNotebook == null) return;

            var notess = DatabaseHelper.Read<Note>().Where(n => n.NotebookId == SelectedNotebook.Id).ToList();
            Notes.Clear();
            foreach (var note in notess)
            {
                Notes.Add(note);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
