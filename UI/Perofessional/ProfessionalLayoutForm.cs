using Dao;
using MaterialSkin.Controls;
using Services.Domain;
using Services.Facade;
using UI.EventHandlers;
using UI.Exceptions;
using UI.Interfaces;

namespace UI.Perofessional
{
    public partial class ProfessionalLayoutForm : MaterialForm, IcstObserver
    {
        private MainTabCtrlEventHandler _tabEventHandler;

        Paciente pacienteAtendido;

        public ProfessionalLayoutForm()
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

        public void Notify(object obj)
        {
            pacienteAtendido = obj as Paciente;
            this.Text = $"Atendiendo al paciente: {pacienteAtendido.Apellido}, {pacienteAtendido.Nombre}";
        }
    }
}
