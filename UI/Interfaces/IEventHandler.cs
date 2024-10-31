using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Interfaces
{
    public interface IEventHandler
    {
        void HandleOnLoad(object sender, EventArgs e);
        void HandleOnCreate(object sender, EventArgs e);
        void HandleOnSaveChanges(object sender, EventArgs e);
        void HandleOnKeyDown(object sender, KeyEventArgs e);
        void HandleOnTabChanged(object sender, EventArgs e);
        void HandleOnVisualize(object sender, EventArgs e);
        void HandleOnLogin(object sender, EventArgs e);
        void HandleOnShowPassword(object sender, EventArgs e);
        void HandleOnExit(object sender, EventArgs e);
        void HandleOnDelete(object sender, EventArgs e);
    }
}
