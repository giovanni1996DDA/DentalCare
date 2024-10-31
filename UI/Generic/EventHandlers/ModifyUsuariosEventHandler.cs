using Dao;
using MaterialSkin.Controls;
using Services.Domain;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Enums;
using UI.Helpers;
using UI.NonProfessional.FormsParametrizaciones.FormsRoles;

namespace UI.Generic.EventHandlers
{
    internal class ModifyUsuariosEventHandler : UsuariosEventHandler
    {
        public ModifyUsuariosEventHandler(Form form) : base(form)
        {
        }
        public override void HandleOnCreate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnDelete(object sender, EventArgs e)
        {
            User previewingUser = modifyingUser;

            txtPassword.Enabled = true;

            if (MessageBox.Show($"Esta seguro de que desea eliminar el usuario {modifyingUser.UserName}?",
                                "Eliminar usuario",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                UserFacade.Delete(modifyingUser);

                MessageBox.Show($"El usuario {previewingUser.UserName} se eliminó correctamente.",
                                "Operación exitosa.",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                modifyingUser = null;

                ClearScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.",
                                $"Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void HandleOnExit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    OnEnterPressed();
                    break;
            }
        }
        private void OnEnterPressed()
        {
            VisualizeUser();

            User loggedUser = SessionManagerFacade.GetLoggedUser();

            if(AccesoFacade.GetPermisosFromUser(loggedUser).Any(p => p.Modulo == (int)SystemModulesEnum.Usuarios 
                                                                  && p.TipoPermiso == (int)TiposPermisoEnum.Actualizar))
            {
                EnableFields();
            }

            if (AccesoFacade.GetPermisosFromUser(loggedUser).Any(p => p.Modulo == (int)SystemModulesEnum.Usuarios
                                                                  && p.TipoPermiso == (int)TiposPermisoEnum.Eliminar))
            {
                btnDelete.Enabled = true;
            }
        }
        private void EnableFields()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtEmail.Enabled = true;
            btnAddRole.Enabled = true;
            btnRemoveRole.Enabled = true;
            btnAddPermiso.Enabled = true;
            btnRemovePermiso.Enabled = true;
            btnAddEspecialidad.Enabled = true;
            btnRemoveEspecialidad.Enabled = true;
            btnSave.Enabled = true;
            btnResetPassword.Enabled = true;
        }
        public override void HandleOnLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public void HandleOnResetPassword(object sender, EventArgs e)
        {
            txtPassword.Enabled = true;
        }

        public override void HandleOnSaveChanges(object sender, EventArgs e)
        {
            try
            {
                User protoUser = buildProtoUser();

                protoUser.Id = modifyingUser.Id;

                if (protoUser.Password != modifyingUser.Password)
                    protoUser.PasswordResetted = true;

                UserFacade.Update(protoUser);

                MessageBox.Show($"El usuario {protoUser.UserName} Se actualizó correctamente.",
                                "Operación exitosa.", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.", "Error inesperado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void HandleOnShowPassword(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnTabChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnVisualize(object sender, EventArgs e)
        {
            VisualizeUser();
        }


    }
}
