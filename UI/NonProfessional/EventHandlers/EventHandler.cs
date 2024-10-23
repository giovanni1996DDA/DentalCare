using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Interfaces;

namespace UI.NonProfessional.EventHandlers
{
    public abstract class EventHandler : IEventHandler
    {
        protected Form _form;

        public abstract void HandleExit(object sender, EventArgs e);

        public abstract void HandleOnCreate(object sender, EventArgs e);

        public abstract void HandleOnKeyDown(object sender, KeyEventArgs e);

        public abstract void HandleOnLoad(object sender, EventArgs e);

        public abstract void HandleOnLogin(object sender, EventArgs e);

        public abstract void HandleOnTabChanged(object sender, EventArgs e);

        public abstract void HandleSaveChanges(object sender, EventArgs e);

        public void HandleShowPassword(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public abstract void HandleVisualize(object sender, EventArgs e);
    }
}
