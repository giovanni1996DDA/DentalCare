using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.NonProfessional.EventHandlers.Pacientes
{
    internal class PacientesTabCtrlEventHandler
    {
        private TabControl _tabControl;

        public PacientesTabCtrlEventHandler(TabControl tabControl)
        {
            _tabControl = tabControl;
        }

        // Este es el método que se suscribirá al evento SelectedIndexChanged
        public void OnTabChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = _tabControl.SelectedTab;

            // Limpiar los controles actuales en la pestaña
            selectedTab.Controls.Clear();

            // Lógica para cargar el formulario adecuado, en este caso puedes usar reflection
            LoadFormInTab(selectedTab);
        }



        public void LoadFormInTab(TabPage tabPage)
        {
            Form formToLoad = null;

            try
            {
                // Construir el nombre del formulario a partir del nombre de la pestaña
                string formName = $"UI.NonProfessional.FormsPacientes.{tabPage.Name}PacienteForm";
                Type formType = Type.GetType($"{formName}");

                if (formType != null)
                {
                    formToLoad = (Form)Activator.CreateInstance(formType);
                    formToLoad.TopLevel = false;
                    formToLoad.FormBorderStyle = FormBorderStyle.None;
                    formToLoad.Dock = DockStyle.Fill;
                    tabPage.Controls.Add(formToLoad);
                    formToLoad.Show();
                }
                else
                {
                    MessageBox.Show($"Formulario {formName} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}");
            }
        }
    }
}
