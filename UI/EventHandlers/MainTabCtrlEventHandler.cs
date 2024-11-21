using MaterialSkin.Controls;
using Services.Domain;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.EventHandlers.Turnos;
using UI.Helpers;
using UI.Perofessional;

namespace UI.EventHandlers
{
    public class MainTabCtrlEventHandler
    {
        private MaterialForm _form;
        private MaterialTabControl TabCtrlMain;

        public MainTabCtrlEventHandler(MaterialForm form)
        {
            _form = form;
            TabCtrlMain = (MaterialTabControl)FormHelpers.FindControl(_form, "TabCtrlMain");
        }
        public void HandleOnLoad(object sender, EventArgs e)
        {
            TabCtrlMain.SelectedIndex = 0;

            FormHelpers.LoadFormInTab(TabCtrlMain.SelectedTab);

            if (_form is ProfessionalLayoutForm)
            {
                AtenderTurnoEventHandler.Suscribe(_form as ProfessionalLayoutForm);
            }

            User currentUser = SessionManagerFacade.GetLoggedUser();
            TabCtrlMain.Text += $"Bienvenido {currentUser.Nombre}";

        }

        public void HandleOnTabChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = TabCtrlMain.SelectedTab;

            selectedTab.Controls.Clear();

            FormHelpers.LoadFormInTab(selectedTab);
        }
    }
}
