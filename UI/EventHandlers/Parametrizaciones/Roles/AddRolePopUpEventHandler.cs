using Services.Domain;
using Services.Facade;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Generic;
using UI.Helpers;
using UI.NonProfessional.FormsParametrizaciones.FormsRoles;
using EventHandler = UI.Generic.EventHandler;
using Services.Facade.Extensions;
using UI.Generic.FormsParametrizaciones.FormsRoles;

namespace UI.EventHandlers.Parametrizaciones.Roles
{
    internal class AddRolePopUpEventHandler : EventHandler
    {
        DataGridView dgvRoles;
        public AddRolePopUpEventHandler(Form form)
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
                    $"Error en la adición de rol".Translate(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = dgvRoles.SelectedRows[0];

            Rol rolSeleccionado = selectedRow.DataBoundItem as Rol;

            (_form as AddRolePopup).selectedRol = rolSeleccionado;

            _form.Close();
        }
        public override void HandleOnExit(object sender, EventArgs e)
        {
            (_form as AddRolePopup).Canceled = true;
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
