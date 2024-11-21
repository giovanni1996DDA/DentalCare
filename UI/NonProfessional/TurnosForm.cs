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
using UI.Enums;
using UI.EventHandlers.Pacientes;
using UI.EventHandlers.Turnos;
using UI.Generic.EventHandlers;

namespace UI.NonProfessional
{
    public partial class TurnosForm : Form
    {
        GestionTurnosEventHandler _turnosFormEventHandler;
        private TabCtrlEventHandler _tabEventHandler;

        public TurnosForm()
        {
            InitializeComponent();

            _turnosFormEventHandler = new GestionTurnosEventHandler(this);
            _tabEventHandler = new TabCtrlEventHandler(tbcTurnos);

            PopulateTabControl();

            InitializeHanlders();
        }

        public void InitializeHanlders()
        {
            this.Load += _turnosFormEventHandler.HandleOnLoad;
            tbcTurnos.SelectedIndexChanged += _tabEventHandler.HandleOnTabChanged;
        }
        public void PopulateTabControl()
        {
            User loggedUser = SessionManagerFacade.GetLoggedUser();

            foreach (Permiso permiso in UserFacade.GetPermisos(loggedUser.Accesos))
            {
                if (permiso.Modulo != (int)SystemModulesEnum.Turnos)
                    continue;

                Services.Domain.Screen protoScreen = new Services.Domain.Screen()
                {
                    Acceso = permiso.Id,
                };

                List<Services.Domain.Screen> screens = ScreenFacade.Get(protoScreen);

                foreach (var scr in screens)
                {
                    if (scr.ScreenName != null)
                        tbcTurnos.TabPages.Add(new TabPage()
                        {
                            Name = scr.ScreenName,
                            Text = scr.OptionName
                        });
                }
            }
        }
    }
}
