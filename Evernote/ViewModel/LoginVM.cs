using Evernote.ViewModel.Commands;
using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evernote.ViewModel
{
    public class LoginVM
    {
        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public RegisterCommand RegisterCommand { get; set; }

        public LoginCommand LoginCommand { get; set; }

        public LoginVM()
        {
            this.LoginCommand = new LoginCommand(this);
            this.RegisterCommand = new RegisterCommand(this);
        }
    }
}
