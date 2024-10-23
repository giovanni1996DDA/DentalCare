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
        void HandleSaveChanges(object sender, EventArgs e);
        void HandleOnKeyDown(object sender, KeyEventArgs e);
        void HandleOnTabChanged(object sender, EventArgs e);
        void HandleVisualize(object sender, EventArgs e);
        void HandleOnLogin(object sender, EventArgs e);
        void HandleShowPassword(object sender, EventArgs e);
        void HandleExit(object sender, EventArgs e);
    }
}
