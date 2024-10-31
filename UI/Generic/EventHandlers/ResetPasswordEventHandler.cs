
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
            User loggedUser = SessionManagerFacade.GetLoggedUser();

            loggedUser.Password = txtPassword.Text;

            try
            {
                loggedUser.PasswordResetted = false;

                UserFacade.Update(loggedUser);
                _form.DialogResult = DialogResult.OK;

                MessageBox.Show($"La contraseña se cambió correctamente", "Operación exitosa",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                _form.Hide();
            }
            catch (InvalidUserException ex)
            {
                MessageBox.Show($"{ex.Message}", "Usuario inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.", "Ocurrió un error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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