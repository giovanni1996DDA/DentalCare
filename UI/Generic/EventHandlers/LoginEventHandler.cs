using Dao;
using Logic;
using Logic.Exceptions;
using MaterialSkin.Controls;
using Services.Domain;
using Services.Facade;
using Services.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Exceptions;
using UI.Generic;
using UI.Helpers;
using UI.NonProfessional;
using UI.Perofessional;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Services.Facade.Extensions;

namespace UI.Login.EventHandler
{
    public class LoginEventHandler
    {
        private readonly Form _form;

        public LoginEventHandler(Form form)
        {
            _form = form;
        }
        public void HandleOnLogin(object sender, EventArgs e)
        {
            Form? nextForm = null;

            try
            {

                ValidateFields();

                MaterialTextBox txtUname = (MaterialTextBox)FormHelpers.FindControl(_form, "txtUname");
                MaterialTextBox txtPassword = (MaterialTextBox)FormHelpers.FindControl(_form, "txtPassword");

                User user = new User()
                {
                    UserName = txtUname.Text,
                    Password = txtPassword.Text,
                };

                UserFacade.Login(user);

                user = SessionManagerFacade.GetLoggedUser();

                Especialidad especialidad = EspecialidadService.Instance.GetOneByUser(user);

                nextForm = (especialidad == null) ? new NonProfessionalLayoutForm() : new ProfessionalLayoutForm();

                nextForm.Show();

                _form.Hide();

            }
            catch (NoUsersFoundException)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.".Translate(), "Error de autenticación".Translate(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch(EmptyFieldException)
            {
                MessageBox.Show("Complete el usuario y la contraseña.".Translate(), "Error de autenticación".Translate(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocurrió un error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void HandleShowPassword(object sender, EventArgs e)
        {
            MaterialTextBox txtPassword = (MaterialTextBox)FormHelpers.FindControl(_form, "txtPassword");

            txtPassword.Password = !txtPassword.Password;
            txtPassword.Refresh();
        }

        public void HandleExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ValidateFields()
        {
            ValidateUname();
            ValidatePassword();
        }

        private void ValidateUname()
        {
            MaterialTextBox txtUname = (MaterialTextBox)FormHelpers.FindControl(_form, "txtUname");

            txtUname.Focus();

            if (txtUname.Text == "")
            {
                throw new EmptyFieldException("Usuario".Translate());
            }
        }

        private void ValidatePassword()
        {
            MaterialTextBox txtPassword = (MaterialTextBox)FormHelpers.FindControl(_form, "txtPassword");

            txtPassword.Focus();

            if (txtPassword.Text == "")
            {
                throw new EmptyFieldException("Contraseña".Translate());
            }
        }

        internal void HanldeOnLoad(object? sender, EventArgs e)
        {
            FormHelpers.TranslateControls(_form);
        }
    }
}
