using Services.Domain;
using Services.Facade;
using Services.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Generic.EventHandlers;

namespace UI.Generic
{
    public partial class ResetPasswordForm : Form
    {
        private ResetPasswordEventHandler _eventHandler;
        public ResetPasswordForm()
        {
            InitializeComponent();

            _eventHandler = new ResetPasswordEventHandler(this);

            InitializeHandlers();
        }
        private void InitializeHandlers()
        {
            btnReset.Click += _eventHandler.HandleOnSaveChanges;
            chkShowPassword.CheckedChanged += _eventHandler.HandleOnShowPassword;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            User loggedUser = SessionManagerFacade.GetLoggedUser();

            loggedUser.Password = txtPassword.Text;

            try
            {
                loggedUser.PasswordResetted = false;

                UserFacade.Update(loggedUser);
                this.DialogResult = DialogResult.OK;

                MessageBox.Show($"La contraseña se cambió correctamente", "Operación exitosa",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                this.Close();
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
    }
}
