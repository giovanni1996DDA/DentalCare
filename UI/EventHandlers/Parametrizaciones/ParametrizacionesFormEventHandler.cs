using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Generic;
using UI.Helpers;
using EventHandler = UI.Generic.EventHandler;

namespace UI.EventHandlers.Parametrizaciones
{
    public class ParametrizacionesFormEventHandler : EventHandler
    {
        public ParametrizacionesFormEventHandler(Form form)
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
            TabControl TabCtrlParametrizaciones = (TabControl)FormHelpers.FindControl(_form, "tabCtrlParametrizaciones");

            TabCtrlParametrizaciones.SelectedIndex = 0;

            FormHelpers.LoadFormInTab(TabCtrlParametrizaciones.SelectedTab);
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
