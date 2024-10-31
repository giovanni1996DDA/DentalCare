using MaterialSkin.Controls;
using Services.Domain;
using Services.Facade;
using Services.Logic;
using Services.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Enums;
using UI.Helpers;
using UI.NonProfessional.FormsParametrizaciones.FormsRoles;

namespace UI.NonProfessional.EventHandlers.Parametrizaciones.Roles
{
    public class DgvRolEventHandler : DgvEventHandler<Rol>, IObservable<object>
    {
        private DataGridView dgvRol;

        private List<IObserver<object>> observers = new List<IObserver<object>>();
        public DgvRolEventHandler(Form form) 
        { 
            _form = form;

            dgvRol = (DataGridView)FormHelpers.FindControl(_form, "dgvRol");
        }
        public override void HandleDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verificar que el clic no sea en el encabezado
            {
                DataGridView dgv = sender as DataGridView;
                Rol selectedRol = dgv?.Rows[e.RowIndex].DataBoundItem as Rol;

                if (selectedRol != null)
                {
                    MaterialTextBox txtRol = (MaterialTextBox)FormHelpers.FindControl(_form, "txtRol");
                    MaterialButton btnSearch = (MaterialButton)FormHelpers.FindControl(_form, "btnSearch");

                    txtRol.Text = selectedRol.Nombre;

                    btnSearch.PerformClick();
                }
            }
        }

        public override void HandleAddItem(object sender, EventArgs e)
        {
            AddRolePopup addRolePopup = new AddRolePopup();
            addRolePopup.ShowDialog();

            if(addRolePopup.Canceled)
                return;

            try
            {
                AccesoService.Instance.AgregarRolaRol((_form as GestionRolesForm).previewingRole, addRolePopup.selectedRol);
                RefreshDgv();

                if(observers.Count > 0)
                    observers.ForEach(obs => obs.OnNext(null));
            }
            catch (RecursiveRoleAdditionException ex)
            {
                MessageBox.Show(ex.Message,
                    "Error en la adición de rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(RoleAlreadyExistInFatherException ex)
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
        public override void HandleRemoveItem(object sender, EventArgs e)
        {
            if (dgvRol.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar el rol a eliminar.",
                                "Error en la eliminación de rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((_form as GestionRolesForm).previewingRole.Accesos.Count == 1)
            {
                MessageBox.Show("El rol no puede estar vacío.",
                                "Error en la eliminación de rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = dgvRol.SelectedRows[0];

            Rol rolSeleccionado = selectedRow.DataBoundItem as Rol;

            try
            {
                AccesoFacade.RemoveRolFromRol((_form as GestionRolesForm).previewingRole, rolSeleccionado);
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
        public override void RefreshDgv()
        {
            List<Rol> childrenRoles = null;

            if (dgvRol.Rows.Count > 0)
                dgvRol.DataSource = null;

            if ((_form as GestionRolesForm).previewingRole != null)
            {
                childrenRoles = new List<Rol>();

                foreach (Acceso acc in (_form as GestionRolesForm).previewingRole.Accesos)
                {
                    if (acc is Rol)
                        childrenRoles.Add((Rol)acc);
                }
                FillDgv(childrenRoles);
            }
        }
        public override void FillDgv(List<Rol> datasource)
        {
            dgvRol.DataSource = datasource;

            dgvRol.Columns["Id"].Visible = false;
            dgvRol.Columns["HasChildren"].Visible = false;
        }


        // Implementación de Subscribe
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
    }
}
