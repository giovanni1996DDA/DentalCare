using MaterialSkin.Controls;
using Services.Domain;
using Services.Facade;
using Services.Logic;
using Services.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Enums;
using UI.Generic;
using UI.Helpers;
using UI.NonProfessional.FormsParametrizaciones.FormsRoles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using EventHandler = UI.Generic.EventHandler;

namespace UI.NonProfessional.EventHandlers.Parametrizaciones.Roles
{
    public class GestionRolesEventHandler : EventHandler, IObserver<object>
    {
        private DataGridView dgvRol;
        private DataGridView dgvPermiso;
        private MaterialTextBox txtRol;
        private MaterialTextBox txtDescripcion;
        private MaterialButton btnSave;
        private MaterialButton btnAddRole;
        private MaterialButton btnRemoveRole;
        private MaterialButton btnAddPermiso;
        private MaterialButton btnRemovePermiso;


        public GestionRolesEventHandler(Form form)
        {
            _form = form;

            dgvRol           = (DataGridView)FormHelpers.FindControl(_form, "dgvRol");
            txtRol           = (MaterialTextBox)FormHelpers.FindControl(_form, "txtRol");
            txtDescripcion   = (MaterialTextBox)FormHelpers.FindControl(_form, "txtDescripcion");
            dgvPermiso       = (DataGridView)FormHelpers.FindControl(_form, "dgvPermiso");
            btnSave          = (MaterialButton)FormHelpers.FindControl(_form, "btnSave");
            btnAddRole       = (MaterialButton)FormHelpers.FindControl(_form, "btnAddRole");
            btnRemoveRole    = (MaterialButton)FormHelpers.FindControl(_form, "btnRemoveRole");
            btnAddPermiso    = (MaterialButton)FormHelpers.FindControl(_form, "btnAddPermiso");
            btnRemovePermiso = (MaterialButton)FormHelpers.FindControl(_form, "btnRemovePermiso");
        }
        public override void HandleOnExit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnCreate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnLoad(object sender, EventArgs e)
        {
            (_form as GestionRolesForm).dgvRolEventHandler.Subscribe(this);
            (_form as GestionRolesForm).dgvPermisoEventHandler.Subscribe(this);
        }

        public override void HandleOnLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnTabChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnSaveChanges(object sender, EventArgs e)
        {
            try
            {
                Rol previewingRole = (_form as GestionRolesForm).previewingRole;

                previewingRole.Descripcion = txtDescripcion.Text;

                AccesoFacade.CreateOrUpdate(previewingRole);

                MessageBox.Show($"El rol {previewingRole.Nombre} se guardó con exito.",
                    "Operación exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnSave.Enabled = false;
                btnSave.TextChanged -= HandleOnDescriptionChanged;

            }
            catch (EmptyRoleException ex)
            {
                MessageBox.Show($"{ex.Message}",
                    "Error Guardando cambios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.",
                                 "Error inesperado", 
                                 MessageBoxButtons.OK, 
                                 MessageBoxIcon.Error);
            }
        }

        public override void HandleOnVisualize(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRol.Text))
            {
                DialogResult wishToContinue = MessageBox.Show("Debe especificar al menos un rol",
                                                              "Complete los campos obligatorios", 
                                                              MessageBoxButtons.OK, 
                                                              MessageBoxIcon.Error);
                return;
            }

            try
            {
                Rol protoRol = new Rol(){
                                            Nombre = txtRol.Text,
                                        };

                bool RoleExists = AccesoFacade.Exists(protoRol);
                
                if(RoleExists)
                {
                    protoRol = AccesoFacade.GetOne(new Rol(){
                                                                Nombre = txtRol.Text
                                                            });
                }
                else
                {
                    DialogResult wishToContinue = MessageBox.Show("El rol no existe, desea crearlo?",
                                                                  "Rol Inexistente", 
                                                                  MessageBoxButtons.YesNo, 
                                                                  MessageBoxIcon.Question);
                    
                    if (wishToContinue == DialogResult.No)
                    {
                        RefreshScreen();
                        return;
                    }
                }

                txtDescripcion.Text = protoRol.Descripcion;
                (_form as GestionRolesForm).previewingRole = protoRol;

                (_form as GestionRolesForm).dgvRolEventHandler.RefreshDgv();
                (_form as GestionRolesForm).dgvPermisoEventHandler.RefreshDgv();

                if (AccesoFacade.GetPermisosFromUser(SessionManager.GetCurrentUser())
                    .Any(p => p.TipoPermiso == (int)TiposPermisoEnum.Actualizar))
                {
                    btnAddRole.Enabled = true;
                    btnRemoveRole.Enabled = true;
                    btnAddPermiso.Enabled = true;
                    btnRemovePermiso.Enabled = true;
                    txtDescripcion.Enabled = true;
                }

            }
            catch (NoRolesFoundException ex)
            {
                MessageBox.Show(ex.Message,
                        "Error en la búsqueda de roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.",
                                $"Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void HandleOnDescriptionChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(object value)
        {
            btnSave.Enabled = true;
        }

        public override void HandleOnShowPassword(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnDelete(object sender, EventArgs e)
        {
            Rol previewingRole = (_form as GestionRolesForm).previewingRole;

            if (MessageBox.Show($"Esta seguro de que desea eliminar el rol {previewingRole.Nombre}",
                                "Eliminar rol",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                AccesoFacade.Delete(previewingRole);

                (_form as GestionRolesForm).previewingRole = null;

                RefreshScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.",
                                $"Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshScreen()
        {
            FormHelpers.ClearControls(_form);
            (_form as GestionRolesForm).dgvRolEventHandler.RefreshDgv();
            (_form as GestionRolesForm).dgvPermisoEventHandler.RefreshDgv();
        }
    }
}
