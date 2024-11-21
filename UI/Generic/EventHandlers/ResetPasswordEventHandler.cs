
using MaterialSkin.Controls;
using Services.Domain;
using Services.Facade;
using Services.Logic;
using Services.Logic.Exceptions;
using UI.Helpers;

namespace UI.Generic.EventHandlers
{
    internal class ResetPasswordEventHandler : EventHandler
    {
        MaterialTextBox txtPassword;
        public ResetPasswordEventHandler(Form form)
        {
            _form = form;
            txtPassword = (MaterialTextBox)FormHelpers.FindControl(_form, "txtPassword");

        }
        public override void HandleOnCreate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnDelete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnExit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnLoad(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnSaveChanges(object sender, EventArgs e)
        {
            
        }
        public override void HandleOnShowPassword(object sender, EventArgs e)
        {
            txtPassword.Password = !txtPassword.Password;
            txtPassword.Refresh();
        }

        public override void HandleOnTabChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnVisualize(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}