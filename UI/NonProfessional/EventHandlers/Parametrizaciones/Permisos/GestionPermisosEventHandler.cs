using MaterialSkin.Controls;
using Services.Domain;
using Services.Facade;
using Services.Logic.Exceptions;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Enums;
using UI.Helpers;
using UI.NonProfessional.FormsParametrizaciones.FormsRoles;
using UI.NonProfessional.FormsParametrizaciones.FormPermiso;
using System.Data.SqlClient;
using UI.Generic;
using EventHandler = UI.Generic.EventHandler;

namespace UI.NonProfessional.EventHandlers.Parametrizaciones.Permisos
{
    public class GestionPermisosEventHandler : EventHandler, IObserver<object>
    {
        private DataGridView dgvScreens;
        private MaterialTextBox txtNombre;
        private MaterialComboBox cbxModulo;
        private MaterialComboBox cbxTipoPermiso;
        private MaterialButton btnSave;
        private MaterialButton btnDelete;
        private MaterialButton btnAddScreen;
        private MaterialButton btnRemoveScreen;
        public GestionPermisosEventHandler(Form form) 
        {
            _form = form;
            dgvScreens = (DataGridView)FormHelpers.FindControl(_form, "dgvScreens");
            txtNombre = (MaterialTextBox)FormHelpers.FindControl(_form, "txtNombre");
            cbxModulo = (MaterialComboBox)FormHelpers.FindControl(_form, "cbxModulo");
            cbxTipoPermiso = (MaterialComboBox)FormHelpers.FindControl(_form, "cbxTipoPermiso");
            btnSave = (MaterialButton)FormHelpers.FindControl(_form, "btnSave");
            btnDelete = (MaterialButton)FormHelpers.FindControl(_form, "btnDelete");
            btnAddScreen = (MaterialButton)FormHelpers.FindControl(_form, "btnAddScreen");
            btnRemoveScreen = (MaterialButton)FormHelpers.FindControl(_form, "btnRemoveScreen");
        }
        public override void HandleOnCreate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnDelete(object sender, EventArgs e)
        {
            Permiso previewingPermiso = (_form as GestionPermisosForm).previewingPermiso;

            if (MessageBox.Show($"Esta seguro de que desea eliminar el permiso {previewingPermiso.Nombre}",
                                "Eliminar rol",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                AccesoFacade.Delete(previewingPermiso);

                MessageBox.Show($"El permiso {previewingPermiso.Nombre} se borró correctamente.",
                "Operación exitosa",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                (_form as GestionPermisosForm).previewingPermiso = null;

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
            throw new NotImplementedException();
        }

        public override void HandleOnLoad(object sender, EventArgs e)
        {
            // Obtener los valores del enum y convertirlos a una lista
            var enumModules = Enum.GetValues(typeof(SystemModulesEnum))
                                 .Cast<SystemModulesEnum>()
                                 .Select(e => new
                                 {
                                     Value = (int)e,
                                     Text = e.ToString()
                                 })
                                 .ToList();

            // Asignar la lista al ComboBox
            cbxModulo.DataSource = enumModules;
            cbxModulo.DisplayMember = "Text"; // Lo que se muestra en la lista
            cbxModulo.ValueMember = "Value"; // Lo que se guarda internamente

            // Obtener los valores del enum y convertirlos a una lista
            var permissionType = Enum.GetValues(typeof(TiposPermisoEnum))
                                 .Cast<TiposPermisoEnum>()
                                 .Select(e => new
                                 {
                                     Value = (int)e,
                                     Text = e.ToString()
                                 })
                                 .ToList();

            // Asignar la lista al ComboBox
            cbxTipoPermiso.DataSource = permissionType;
            cbxTipoPermiso.DisplayMember = "Text"; // Lo que se muestra en la lista
            cbxTipoPermiso.ValueMember = "Value"; // Lo que se guarda internamente

            (_form as GestionPermisosForm).dgvScreenEventHandler.Subscribe(this);
        }

        public override void HandleOnLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnSaveChanges(object sender, EventArgs e)
        {
            try
            {
                Permiso previewingPermiso = (_form as GestionPermisosForm).previewingPermiso;

                previewingPermiso.Modulo = (int)cbxModulo.SelectedValue;
                previewingPermiso.TipoPermiso = (int)cbxTipoPermiso.SelectedValue;

                AccesoFacade.CreateOrUpdate(previewingPermiso);

                MessageBox.Show($"El permiso {previewingPermiso.Nombre} se guardó con exito.",
                    "Operación exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnSave.Enabled = false;
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                MessageBox.Show($"Ya existe un registro con ese tipo de permiso para ese módulo.",
                                 "Error guardando el rol",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.",
                                 "Error inesperado",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
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
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                DialogResult wishToContinue = MessageBox.Show("Debe especificar al menos un rol",
                                                              "Complete los campos obligatorios",
                                                              MessageBoxButtons.OK,
                                                              MessageBoxIcon.Error);
                return;
            }

            try
            {
                Permiso protoPermiso = new Permiso()
                {
                    Nombre = txtNombre.Text,
                };

                bool permisoExists = AccesoFacade.Exists(protoPermiso);

                if (permisoExists)
                {
                    protoPermiso = AccesoFacade.GetOne(new Permiso()
                    {
                        Nombre = txtNombre.Text
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

                if(protoPermiso.Modulo != null)
                    cbxModulo.SelectedValue = protoPermiso.Modulo;

                if(protoPermiso.TipoPermiso != null)
                    cbxTipoPermiso.SelectedValue = protoPermiso.TipoPermiso;

                (_form as GestionPermisosForm).previewingPermiso = protoPermiso;

                RefreshScreen();

                if (AccesoFacade.GetPermisosFromUser(SessionManager.GetCurrentUser())
                    .Any(p => p.TipoPermiso == (int)TiposPermisoEnum.Actualizar))
                {
                    btnDelete.Enabled = true;
                    btnSave.Enabled = true;
                    btnAddScreen.Enabled = true;
                    btnRemoveScreen.Enabled = true;
                    cbxModulo.Enabled = true;
                    cbxTipoPermiso.Enabled = true;
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

        public void RefreshScreen()
        {
            FormHelpers.RefreshControls(_form);
            (_form as GestionPermisosForm).dgvScreenEventHandler.RefreshDgv();
            //dgvScreens.DataSource = null;
        }
        private void ClearScreen()
        {
            FormHelpers.ClearControls(_form);
            (_form as GestionPermisosForm).dgvScreenEventHandler.RefreshDgv();
        }
    }
}
