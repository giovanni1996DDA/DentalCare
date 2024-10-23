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
using UI.Helpers;
using UI.NonProfessional;
using UI.Perofessional;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

                Especialidad especialidad = EspecialidadService.Instance.GetOne(user);

                nextForm = new ProfessionalLayoutForm();

            }
            catch (NoEspecialidadFoundException)
            {
                nextForm = new NonProfessionalLayoutForm();
            }
            catch (NoUsersFoundException)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch(EmptyFieldException)
            {
                MessageBox.Show("Complete el usuario y la contraseña.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _form.Hide();

            nextForm.ShowDialog();
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
                throw new EmptyFieldException("Usuario");
            }
        }

        private void ValidatePassword()
        {
            MaterialTextBox txtPassword = (MaterialTextBox)FormHelpers.FindControl(_form, "txtPassword");

            txtPassword.Focus();

            if (txtPassword.Text == "")
            {
                throw new EmptyFieldException("Contraseña");
            }
        }
    }
}
