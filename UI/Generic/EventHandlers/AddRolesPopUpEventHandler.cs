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
    internal class AddRolesPopUpEventHandler : EventHandler
    {
        DataGridView dgvRoles;
        public AddRolesPopUpEventHandler(Form form)
        {
            _form = form;

            dgvRoles = (DataGridView)FormHelpers.FindControl(_form, "dgvRoles");
        }
        public override void HandleOnLoad(object sender, EventArgs e)
        {

            List<Rol> roles = AccesoFacade.Get(new Rol());

            dgvRoles.DataSource = roles;
        }
        public void HandleOnAdd(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count == 0)
            {
                MessageBox.Show($"Debe seleccionar el rol a agregar.".Translate(),
                                $"Error en la adición de rol".Translate(),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = dgvRoles.SelectedRows[0];

            Rol rolSeleccionado = selectedRow.DataBoundItem as Rol;

            (_form as AddRolesPopUp).selectedRol = rolSeleccionado;

            _form.Close();
        }
        public override void HandleOnExit(object sender, EventArgs e)
        {
            (_form as AddRolesPopUp).Canceled = true;
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

