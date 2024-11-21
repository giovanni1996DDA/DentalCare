using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Helpers;

namespace UI.Generic.EventHandlers
{
    internal class UsuariosFormEventHandler : EventHandler
    {
        public UsuariosFormEventHandler(Form form) 
        {
            _form = form;
        }
        public override void HandleOnCreate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnDelete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
            FormHelpers.TranslateControls(_form);

            TabControl tbcUsuarios = (TabControl)FormHelpers.FindControl(_form, "tbcUsuarios");

            tbcUsuarios.SelectedIndex = 0;

            FormHelpers.LoadFormInTab(tbcUsuarios.SelectedTab);
        }

        public override void HandleOnLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnSaveChanges(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
