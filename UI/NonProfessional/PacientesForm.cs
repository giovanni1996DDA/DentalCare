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
using UI.NonProfessional.EventHandlers.Pacientes;

namespace UI.NonProfessional
{
    public partial class PacientesForm : Form
    {
        private TabCtrlEventHandler _tabEventHandler;
        private PacientesFormEventHandler _PacientesFormEventHandler;
        public PacientesForm()
        {
            InitializeComponent();

            PopulateTabControl();

            _PacientesFormEventHandler = new PacientesFormEventHandler(this);
            _tabEventHandler = new TabCtrlEventHandler(TabCtrlPacientes);

            InitializeHandlers();

            TabCtrlPacientes.SelectedIndex = 0;
        }

        private void InitializeHandlers()
        {
            this.Load += _PacientesFormEventHandler.HandleOnLoad;
            TabCtrlPacientes.SelectedIndexChanged += _tabEventHandler.HandleOnTabChanged;
        }

        private void PopulateTabControl()
        {
            User loggedUser = SessionManagerFacade.GetLoggedUser();

            foreach (Permiso permiso in UserFacade.GetPermisos(loggedUser.Accesos))
            {

                if (permiso.Modulo != (int)SystemModulesEnum.Pacientes)
                    continue;

                Services.Domain.Screen protoScreen = new Services.Domain.Screen()
                {
                    Acceso = permiso.Id,
                };

                List<Services.Domain.Screen> screens = ScreenFacade.Get(protoScreen);

                foreach (var scr in screens)
                {
                    if (scr.ScreenName != null)
                        TabCtrlPacientes.TabPages.Add(new TabPage()
                        {
                            Name = scr.ScreenName,
                            Text = scr.OptionName
                        });
                }
            }
        }
    }
}
