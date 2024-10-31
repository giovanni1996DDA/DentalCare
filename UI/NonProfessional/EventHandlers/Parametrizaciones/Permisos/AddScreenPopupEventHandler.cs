using Services.Domain;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Generic;
using UI.Helpers;
using UI.NonProfessional.FormsParametrizaciones.FormPermisos;
using UI.NonProfessional.FormsParametrizaciones.FormsRoles;
using EventHandler = UI.Generic.EventHandler;
using Screen = Services.Domain.Screen;

namespace UI.NonProfessional.EventHandlers.Parametrizaciones.Permisos
{
    internal class AddScreenPopupEventHandler : EventHandler
    {
        DataGridView dgvScreens;
        public AddScreenPopupEventHandler(Form form)
        {
            _form = form;
            dgvScreens = (DataGridView)FormHelpers.FindControl(_form, "dgvScreens");
        }
        public override void HandleOnLoad(object sender, EventArgs e)
        {
            List<Screen> screens = ScreenFacade.Get(new Screen());

            dgvScreens.DataSource = screens;
        }
        public void HandleOnAdd(object sender, EventArgs e)
        {
            if (dgvScreens.SelectedRows.Count == 0)
            {
                MessageBox.Show($"Debe seleccionar la screen a agregar.",
                                $"Error en la adición de screen",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            DataGridViewRow selectedRow = dgvScreens.SelectedRows[0];

            Screen screenSeleccionado = selectedRow.DataBoundItem as Screen;

            (_form as AddScreenPopup).selectedScreen = screenSeleccionado;

            _form.Close();
        }
        public override void HandleOnExit(object sender, EventArgs e)
        {
            (_form as AddScreenPopup).Canceled = true;
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
