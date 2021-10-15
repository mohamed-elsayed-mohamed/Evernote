using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Evernote.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginVM LoginVM { get; set; }

        public event EventHandler CanExecuteChanged;

        public LoginCommand(LoginVM loginVM)
        {
            this.LoginVM = loginVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
        }
    }
}
