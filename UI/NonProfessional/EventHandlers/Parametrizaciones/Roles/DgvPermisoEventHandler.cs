using Services.Domain;
using Services.Logic.Exceptions;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Enums;
using UI.Helpers;
using UI.NonProfessional.FormsParametrizaciones.FormsRoles;
using Services.Facade;

namespace UI.NonProfessional.EventHandlers.Parametrizaciones.Roles
{
    public class DgvPermisoEventHandler : DgvEventHandler<Permiso>, IObservable<object>
    {
        private DataGridView dgvPermiso;

        private List<IObserver<object>> observers = new List<IObserver<object>>();
        public DgvPermisoEventHandler(Form form)
        {
            _form = form;

            dgvPermiso = (DataGridView)FormHelpers.FindControl(_form, "dgvPermiso");
        }
        public override void RefreshDgv()
        {
            List<Permiso> childrenPermisos = null;

            if (dgvPermiso.Rows.Count > 0)
                dgvPermiso.DataSource = null;

            if ((_form as GestionRolesForm).previewingRole != null)
            {
                childrenPermisos = new List<Permiso>();

                foreach (Acceso acc in (_form as GestionRolesForm).previewingRole.Accesos)
                {
                    if (acc is Permiso)
                        childrenPermisos.Add(acc as Permiso);
                }
                FillDgv(childrenPermisos);
            }
        }
        public override void FillDgv(List<Permiso> datasource)
        {
            dgvPermiso.DataSource = datasource;

            dgvPermiso.Columns["Id"].Visible = false;
            dgvPermiso.Columns["HasChildren"].Visible = false;
            dgvPermiso.Columns["Modulo"].Visible = false;
            dgvPermiso.Columns["TipoPermiso"].Visible = false;

            if (!dgvPermiso.Columns.Contains("ModuloNombre"))
            {
                dgvPermiso.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ModuloNombre",
                    HeaderText = "Módulo"
                });
            }

            if (!dgvPermiso.Columns.Contains("TipoPermisoNombre"))
            {
                dgvPermiso.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TipoPermisoNombre",
                    HeaderText = "Tipo de Permiso"
                });
            }

            if (datasource == null)
                return;

            foreach (DataGridViewRow row in dgvPermiso.Rows)
            {
                Permiso boundPermiso = row.DataBoundItem as Permiso;

                string moduloNombre = Enum.GetName(typeof(SystemModulesEnum), boundPermiso.Modulo.Value) ?? "Desconocido";

                row.Cells["ModuloNombre"].Value = moduloNombre;

                string TipoPermisoNombre = Enum.GetName(typeof(TiposPermisoEnum), boundPermiso.TipoPermiso.Value) ?? "Desconocido";

                row.Cells["TipoPermisoNombre"].Value = TipoPermisoNombre;
            }
        }
        public IDisposable Subscribe(IObserver<object> observer)
        {
            // Agregar el observador a la lista si no está ya registrado
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }

            // Devolver una instancia de Unsubscriber para permitir la cancelación
            return new Unsubscriber(observers, observer);
        }


        public override void HandleAddItem(object sender, EventArgs e)
        {
            AddPermisoPopup addPermisoPopup = new AddPermisoPopup();
            addPermisoPopup.ShowDialog();

            if (addPermisoPopup.Canceled)
                return;

            try
            {
                AccesoFacade.AgregarPermisoaRol((_form as GestionRolesForm).previewingRole, addPermisoPopup.selectedPermiso);

                RefreshDgv();

                if (observers.Count > 0)
                    observers.ForEach(obs => obs.OnNext(null));
            }
            catch (RecursiveRoleAdditionException ex)
            {
                MessageBox.Show(ex.Message,
                    "Error en la adición de rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (RoleAlreadyExistInFatherException ex)
            {
                MessageBox.Show(ex.Message,
                    "Error en la adición de rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.",
                                        "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void HandleDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleRemoveItem(object sender, EventArgs e)
        {
            if (dgvPermiso.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar el permiso a eliminar.",
                                "Error en la eliminación de rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((_form as GestionRolesForm).previewingRole.Accesos.Count == 1)
            {
                MessageBox.Show("El rol no puede estar vacío.",
                                "Error en la eliminación de rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = dgvPermiso.SelectedRows[0];

            Permiso permisoSeleccionado = selectedRow.DataBoundItem as Permiso;

            try
            {
                AccesoFacade.RemovePermisoFromRol((_form as GestionRolesForm).previewingRole, permisoSeleccionado);
                RefreshDgv();

                if (observers.Count > 0)
                    observers.ForEach(obs => obs.OnNext(null));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.",
                                        "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
