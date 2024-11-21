using MaterialSkin.Controls;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Generic;
using UI.Helpers;
using EventHandler = UI.Generic.EventHandler;

namespace UI.EventHandlers.Pacientes
{
    public class PacientesFormEventHandler : EventHandler
    {
        public PacientesFormEventHandler(Form form)
        {
            _form = form;
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
            TabControl TabCtrlPacientes = (TabControl)FormHelpers.FindControl(_form, "TabCtrlPacientes");

            TabCtrlPacientes.SelectedIndex = 0;

            FormHelpers.LoadFormInTab(TabCtrlPacientes.SelectedTab);
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
