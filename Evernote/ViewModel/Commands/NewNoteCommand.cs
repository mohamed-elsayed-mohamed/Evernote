using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Evernote.ViewModel.Commands
{
    public class NewNoteCommand : ICommand
    {
        public NotesVM NotesVM { get; set; }

        public event EventHandler CanExecuteChanged;

        public NewNoteCommand(NotesVM notesVM)
        {
            this.NotesVM = notesVM;
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
