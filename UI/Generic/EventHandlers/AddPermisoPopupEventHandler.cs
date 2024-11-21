using Services.Domain;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Generic.FormUsuarios.PopUps;
using UI.Helpers;
using Services.Facade.Extensions;

namespace UI.Generic.EventHandlers
{
    internal class AddPermisoPopupEventHandler : EventHandler
    {
        DataGridView dgvPermisos;
        public AddPermisoPopupEventHandler(Form form)
        {
            _form = form;
            dgvPermisos = (DataGridView)FormHelpers.FindControl(_form, "dgvPermisos");
        }
        public override void HandleOnLoad(object sender, EventArgs e)
        {

            List<Permiso> roles = AccesoFacade.Get(new Permiso());

            dgvPermisos.DataSource = roles;
        }
        public void HandleOnAdd(object sender, EventArgs e)
        {
            if (dgvPermisos.SelectedRows.Count == 0)
            {
                MessageBox.Show($"Debe seleccionar el permiso a agregar.".Translate(),
                                $"Error en la adición de permiso".Translate(),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = dgvPermisos.SelectedRows[0];

            Permiso permisoSeleccionado = selectedRow.DataBoundItem as Permiso;

            (_form as AddPermisoPopUp).selectedPermiso = permisoSeleccionado;

            _form.Close();
        }
        public override void HandleOnExit(object sender, EventArgs e)
        {
            (_form as AddPermisoPopUp).Canceled = true;
            _form.Close();
        }

        public override void HandleOnCreate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override void HandleOnVisualize(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnShowPassword(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnDelete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
