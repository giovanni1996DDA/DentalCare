﻿using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Helpers;

namespace UI.NonProfessional.EventHandlers.Pacientes
{
    internal class PacientesTabCtrlEventHandler
    {
        private TabControl _tabControl;

        public PacientesTabCtrlEventHandler(TabControl tabControl)
        {
            _tabControl = tabControl;
        }
        public void HandleOnTabChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = _tabControl.SelectedTab;

            // Limpiar los controles actuales en la pestaña
            selectedTab.Controls.Clear();

            FormHelpers.LoadFormInTab(selectedTab);
        }
    }
}
