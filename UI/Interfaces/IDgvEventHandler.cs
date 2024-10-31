using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Interfaces
{
    public interface IDgvEventHandler<T>
    {
        void HandleDoubleClick(object sender, DataGridViewCellEventArgs e);
        void HandleAddItem(object sender, EventArgs e);
        void HandleRemoveItem(object sender, EventArgs e);
        void RefreshDgv();
        void FillDgv(List<T> datasource);

    }
}
