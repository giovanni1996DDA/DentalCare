using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Generic.EventHandlers;

namespace UI.Generic.FormsParametrizaciones.FormsIdiomas
{
    public partial class IdiomasForm : Form
    {
        private IdiomasEventHandler _eventHandler;
        public IdiomasForm()
        {
            InitializeComponent();

            _eventHandler = new IdiomasEventHandler(this);

            InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            this.Load += _eventHandler.HandleOnLoad;
            btnSave.Click += _eventHandler.HandleOnSaveChanges;
        }
    }
}
