using Logic.Exceptions;
using MaterialSkin.Controls;
using Services.Domain;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Exceptions;
using UI.NonProfessional.EventHandlers;
using UI.Perofessional;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI.NonProfessional
{
    public partial class NonProfessionalLayoutForm : MaterialForm
    {
        private MainTabCtrlEventHandler _tabEventHandler;

        public NonProfessionalLayoutForm()
        {
            InitializeComponent();

            PopulateTabControl();

            _tabEventHandler = new MainTabCtrlEventHandler(this);

            InitializeHandlers();
        }
        private void InitializeHandlers()
        {
            this.Load += _tabEventHandler.HandleOnLoad;
            TabCtrlMain.SelectedIndexChanged += _tabEventHandler.HandleOnTabChanged;
        }

        private void PopulateTabControl()
        {
            User loggedUser = SessionManagerFacade.GetLoggedUser();

            foreach (Rol rol in UserFacade.GetRoles(loggedUser.Accesos))
            {

                Services.Domain.Screen protoScreen = new Services.Domain.Screen()
                {
                    Acceso = rol.Id,
                };

                List<Services.Domain.Screen> screens = ScreenFacade.Get(protoScreen);

                foreach (var scr in screens)
                {
                    if (scr.ScreenName != null)
                        TabCtrlMain.TabPages.Add(new TabPage()
                        {
                            Name = scr.ScreenName,
                            Text = scr.OptionName
                        });
                }
            }

            if (TabCtrlMain.TabPages.Count == 0)
                throw new NoMenuOptionsAvailableException(loggedUser.UserName);
        }
    }
}
