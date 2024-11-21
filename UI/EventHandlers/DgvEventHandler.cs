using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Interfaces;

namespace UI.EventHandlers
{
    public abstract class DgvEventHandler<T> : IDgvEventHandler<T>
    {
        protected Form _form;
        public abstract void FillDgv(List<T> datasource);
        public abstract void HandleAddItem(object sender, EventArgs e);
        public abstract void HandleDoubleClick(object sender, DataGridViewCellEventArgs e);
        public abstract void HandleRemoveItem(object sender, EventArgs e);
        public abstract void RefreshDgv();
    }
}
