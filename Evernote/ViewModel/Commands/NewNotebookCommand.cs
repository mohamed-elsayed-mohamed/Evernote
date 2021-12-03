using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Evernote.ViewModel.Commands
{
    public class NewNotebookCommand : ICommand
    {
        public NotesVM NotesVM { get; set; }

        public event EventHandler CanExecuteChanged;

        public NewNotebookCommand(NotesVM notesVM)
        {
            this.NotesVM = notesVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NotesVM.CreateNotebook();
        }
    }
}
