using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Interfaces;

namespace UI.NonProfessional.EventHandlers
{
    public abstract class DgvEventHandler : IDgvEventHandler
    {
        protected Form _form;
        public abstract void HandleDoubleClick(object sender, DataGridViewCellEventArgs e);
    }
}
