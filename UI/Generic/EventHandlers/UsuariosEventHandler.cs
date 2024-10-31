using Dao;
using Logic.Exceptions;
using Logic;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Helpers;
using System.ComponentModel;
using UI.Enums;
using MaterialSkin.Controls;
using UI.Generic.FormUsuarios.PopUps;
using Services.Facade;
using Services.Logic.Exceptions;

namespace UI.Generic.EventHandlers
{
    internal abstract class UsuariosEventHandler : EventHandler
    {
        protected MaterialTextBox txtNombre;
        protected MaterialTextBox txtApellido;
        protected MaterialTextBox txtUsuario;
        protected MaterialTextBox txtPassword;
        protected MaterialTextBox txtEmail;
        protected DataGridView dgvEspecialidades;
        protected DataGridView dgvRoles;
        protected DataGridView dgvPermisos;
        protected MaterialButton btnAddRole;
        protected MaterialButton btnRemoveRole;
        protected MaterialButton btnAddPermiso;
        protected MaterialButton btnRemovePermiso;
        protected MaterialButton btnAddEspecialidad;
        protected MaterialButton btnRemoveEspecialidad;
        protected MaterialButton btnSave;
        protected MaterialButton btnDelete;
        protected MaterialButton btnResetPassword;

        public BindingList<Permiso> dataSourcePermiso = new BindingList<Permiso>();
        public BindingList<Rol> dataSourceRol = new BindingList<Rol>();
        public BindingList<Especialidad> dataSourceEspecialidad = new BindingList<Especialidad>();

        protected User modifyingUser;
        protected UsuariosEventHandler(Form form)
        {
            _form = form;

            txtNombre = (MaterialTextBox)FormHelpers.FindControl(_form, "txtNombre");
            txtApellido = (MaterialTextBox)FormHelpers.FindControl(_form, "txtApellido");
            txtUsuario = (MaterialTextBox)FormHelpers.FindControl(_form, "txtUsuario");
            txtPassword = (MaterialTextBox)FormHelpers.FindControl(_form, "txtPassword");
            txtEmail = (MaterialTextBox)FormHelpers.FindControl(_form, "txtEmail");
            dgvEspecialidades = (DataGridView)FormHelpers.FindControl(_form, "dgvEspecialidades");
            dgvRoles = (DataGridView)FormHelpers.FindControl(_form, "dgvRoles");
            dgvPermisos = (DataGridView)FormHelpers.FindControl(_form, "dgvPermisos");
            btnAddRole = (MaterialButton)FormHelpers.FindControl(_form, "btnAddRole");
            btnRemoveRole = (MaterialButton)FormHelpers.FindControl(_form, "btnRemoveRole");
            btnAddPermiso = (MaterialButton)FormHelpers.FindControl(_form, "btnAddPermiso");
            btnRemovePermiso = (MaterialButton)FormHelpers.FindControl(_form, "btnRemovePermiso");
            btnAddEspecialidad = (MaterialButton)FormHelpers.FindControl(_form, "btnAddEspecialidad");
            btnRemoveEspecialidad = (MaterialButton)FormHelpers.FindControl(_form, "btnRemoveEspecialidad");
            btnSave = (MaterialButton)FormHelpers.FindControl(_form, "btnSave");
            btnDelete = (MaterialButton)FormHelpers.FindControl(_form, "btnDelete");
            btnResetPassword = (MaterialButton)FormHelpers.FindControl(_form, "btnResetPassword");
        }

        public void HandleOnDgvPermisosCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPermisos.Columns[e.ColumnIndex].Name == "ModuloText")
            {
                if (e.Value != null && e.Value is int moduloValue)
                {
                    // Convertir el valor de Modulo a su nombre en el enum
                    e.Value = Enum.GetName(typeof(SystemModulesEnum), moduloValue) ?? "Desconocido";
                    e.FormattingApplied = true;
                }
            }
            else if (dgvPermisos.Columns[e.ColumnIndex].Name == "TipoPermisoText")
            {
                if (e.Value != null && e.Value is int tipoPermisoValue)
                {
                    // Convertir el valor de TipoPermiso a su nombre en el enum
                    e.Value = Enum.GetName(typeof(TiposPermisoEnum), tipoPermisoValue) ?? "Desconocido";
                    e.FormattingApplied = true;
                }
            }
        }
        public void HandleOnAddPermiso(object sender, EventArgs e)
        {
            AddPermisoPopUp addPermisoPopup = new AddPermisoPopUp();
            addPermisoPopup.ShowDialog();

            if (addPermisoPopup.Canceled)
                return;

            try
            {
                bool permisoExists = dataSourcePermiso.Any(x => x.Id == addPermisoPopup.selectedPermiso.Id);

                if (permisoExists)
                {
                    MessageBox.Show($"El rol ya se agregó anteriormente.",
                                    "Rol existente",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                dataSourcePermiso.Add(addPermisoPopup.selectedPermiso);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.",
                                        "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void HandleOnRemovePermiso(object sender, EventArgs e)
        {

            if (dgvPermisos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar el permiso a eliminar.",
                                "Error en la eliminación de rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = dgvPermisos.SelectedRows[0];

            Permiso selectedPermiso = selectedRow.DataBoundItem as Permiso;

            dataSourcePermiso.Remove(selectedPermiso);
        }

        public void HandleOnAddRol(object sender, EventArgs e)
        {
            AddRolesPopUp addRolPopup = new AddRolesPopUp();
            addRolPopup.ShowDialog();

            if (addRolPopup.Canceled)
                return;

            try
            {
                bool roleExists = dataSourceRol.Any(x => x.Id == addRolPopup.selectedRol.Id);

                if (roleExists)
                {
                    MessageBox.Show($"El rol ya se agregó anteriormente.",
                                    "Rol existente",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                dataSourceRol.Add(addRolPopup.selectedRol);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.",
                                        "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void HandleOnRemoveRol(object sender, EventArgs e)
        {

            if (dgvRoles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar el rol a eliminar.",
                                "Error en la eliminación de rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = dgvRoles.SelectedRows[0];

            Rol selectedRol = selectedRow.DataBoundItem as Rol;

            dataSourceRol.Remove(selectedRol);
        }
        public void HandleOnAddEspecialidad(object sender, EventArgs e)
        {
            AddEspecialidadesPopUp addEspecialidadesPopup = new AddEspecialidadesPopUp();
            addEspecialidadesPopup.ShowDialog();

            if (addEspecialidadesPopup.Canceled)
                return;

            try
            {
                bool especialidadExists = dataSourceEspecialidad.Any(x => x.Id == addEspecialidadesPopup.selectedEspecialidad.Id);

                if (especialidadExists)
                {
                    MessageBox.Show($"La especialidad ya se agregó anteriormente.",
                                    "Especialidad existente",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                dataSourceEspecialidad.Add(addEspecialidadesPopup.selectedEspecialidad);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.",
                                        "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void HandleOnRemoveEspecialidad(object sender, EventArgs e)
        {

            if (dgvEspecialidades.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar la especialidad a eliminar.",
                                "Error en la eliminación de especialidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = dgvEspecialidades.SelectedRows[0];

            Especialidad selectedEspecialidad = selectedRow.DataBoundItem as Especialidad;

            dataSourceEspecialidad.Remove(selectedEspecialidad);
        }
        protected void ClearScreen()
        {
            FormHelpers.ClearControls(_form);

            ClearGrids();

        }

        private void ClearGrids()
        {
            dataSourcePermiso.Clear();
            dgvPermisos.Refresh();

            dataSourceRol.Clear();
            dgvRoles.Refresh();

            dataSourceEspecialidad.Clear();
            dgvEspecialidades.Refresh();
        }

        private void ConfigureDgvPermisos()
        {
            // Configuración del DataGridView
            dgvPermisos.AutoGenerateColumns = false; // Deshabilitar la generación automática de columnas

            dgvPermisos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Opcional: Ajustar la última columna para que ocupe el espacio restante
            dgvPermisos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Agregar columna de Nombre
            dgvPermisos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "Nombre"
            });

            // Agregar columna para el texto del Modulo
            dgvPermisos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Modulo",
                HeaderText = "Modulo",
                Name = "ModuloText"
            });

            // Agregar columna para el texto del TipoPermiso
            dgvPermisos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TipoPermiso",
                HeaderText = "Tipo de Permiso",
                Name = "TipoPermisoText"
            });

            // Vincular el BindingList como DataSource
            dgvPermisos.DataSource = dataSourcePermiso;
            dgvPermisos.ClearSelection();
        }
        private void ConfigureDgvRoles()
        {
            // Configuración del DataGridView
            dgvRoles.AutoGenerateColumns = false; // Deshabilitar la generación automática de columnas

            dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Opcional: Ajustar la última columna para que ocupe el espacio restante
            dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Agregar columna de Nombre
            dgvRoles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "Nombre"
            });

            // Agregar columna para el texto del Modulo
            dgvRoles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descripcion",
                HeaderText = "Descripcion",
                Name = "Descripcion"
            });

            // Vincular el BindingList como DataSource
            dgvRoles.DataSource = dataSourceRol;
            dgvRoles.ClearSelection();
        }
        private void ConfigureDgvEspecialidad()
        {
            // Configuración del DataGridView
            dgvEspecialidades.AutoGenerateColumns = false; // Deshabilitar la generación automática de columnas

            dgvEspecialidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Opcional: Ajustar la última columna para que ocupe el espacio restante
            dgvEspecialidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Agregar columna de Nombre
            dgvEspecialidades.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "Nombre"
            });
            // Vincular el BindingList como DataSource
            dgvEspecialidades.DataSource = dataSourceEspecialidad;
            dgvEspecialidades.ClearSelection();
        }
        public override void HandleOnLoad(object sender, EventArgs e)
        {
            ConfigureDgvPermisos();
            ConfigureDgvRoles();
            ConfigureDgvEspecialidad();
        }
        protected void VisualizeUser()
        {
            ClearGrids();

            User protoUser = new User()
            {
                UserName = txtUsuario.Text
            };
            try
            {
                modifyingUser = UserFacade.GetOne(protoUser);

                txtNombre.Text = modifyingUser.Nombre;
                txtPassword.Text = modifyingUser.Password; 
                txtApellido.Text = modifyingUser.Apellido;
                txtEmail.Text = modifyingUser.Email;

                modifyingUser.Accesos.ForEach(a =>
                {
                    if (a is Rol)
                    {
                        dataSourceRol.Add(a as Rol);
                    }

                    if (a is Permiso)
                    {
                        dataSourcePermiso.Add(a as Permiso);
                    }
                });

            }
            catch (NoUsersFoundException ex)
            {
                MessageBox.Show($"{ex.Message}", "Usuario inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearScreen();
                return;
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.",
                                "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                modifyingUser.Especialidades = EspecialidadService.Instance.GetByUser(modifyingUser);

                modifyingUser.Especialidades.ForEach(dataSourceEspecialidad.Add);
            }
            catch (NoEspecialidadFoundException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.",
                                "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dgvEspecialidades.Refresh();
            dgvRoles.Refresh();
            dgvPermisos.Refresh();

            dgvEspecialidades.ClearSelection();
            dgvRoles.ClearSelection();
            dgvPermisos.ClearSelection();

        }
        protected User buildProtoUser()
        {
            User protoUser = new User()
            {
                Nombre = txtNombre.Text,
                Email = txtEmail.Text,
                Apellido = txtApellido.Text,
                Password = txtPassword.Text,
                UserName = txtUsuario.Text,
            };
            List<Especialidad> especialidades = new List<Especialidad>();

            foreach (DataGridViewRow row in dgvEspecialidades.Rows)
            {
                if (row.DataBoundItem is Especialidad especialidad)
                {
                    especialidades.Add(especialidad); // Agregar el objeto Rol a la lista de accesos
                }
            }

            protoUser.Especialidades.AddRange(especialidades);

            List<Acceso> accesos = new List<Acceso>();

            foreach (DataGridViewRow row in dgvRoles.Rows)
            {
                if (row.DataBoundItem is Rol rol)
                {
                    accesos.Add(rol); // Agregar el objeto Rol a la lista de accesos
                }
            }

            foreach (DataGridViewRow row in dgvPermisos.Rows)
            {
                if (row.DataBoundItem is Permiso permiso)
                {
                    accesos.Add(permiso); // Agregar el objeto Permiso a la lista de accesos
                }
            }

            protoUser.Accesos.AddRange(accesos);

            return protoUser;
        }
    }
}
