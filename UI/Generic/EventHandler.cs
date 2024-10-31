using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Interfaces;

namespace UI.Generic
{
    public abstract class EventHandler : IEventHandler
    {
        protected Form _form;
        public abstract void HandleOnExit(object sender, EventArgs e);
        public abstract void HandleOnCreate(object sender, EventArgs e);
        public abstract void HandleOnKeyDown(object sender, KeyEventArgs e);
        public abstract void HandleOnLoad(object sender, EventArgs e);
        public abstract void HandleOnLogin(object sender, EventArgs e);
        public abstract void HandleOnTabChanged(object sender, EventArgs e);
        public abstract void HandleOnSaveChanges(object sender, EventArgs e);
        public abstract void HandleOnVisualize(object sender, EventArgs e);
        public abstract void HandleOnShowPassword(object sender, EventArgs e);
        public abstract void HandleOnDelete(object sender, EventArgs e);
    }
}
