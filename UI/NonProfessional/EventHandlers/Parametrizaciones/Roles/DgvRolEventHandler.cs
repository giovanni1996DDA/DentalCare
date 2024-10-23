using MaterialSkin.Controls;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Helpers;

namespace UI.NonProfessional.EventHandlers.Parametrizaciones.Roles
{
    public class DgvRolEventHandler : DgvEventHandler
    {
        public DgvRolEventHandler(Form form) 
        { 
            _form = form;
        }
        public override void HandleDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verificar que el clic no sea en el encabezado
            {
                DataGridView dgv = sender as DataGridView;
                Rol selectedRol = dgv?.Rows[e.RowIndex].DataBoundItem as Rol;

                if (selectedRol != null)
                {
                    MaterialTextBox txtRol = (MaterialTextBox)FormHelpers.FindControl(_form, "txtRol");
                    MaterialButton btnSearch = (MaterialButton)FormHelpers.FindControl(_form, "btnSearch");

                    txtRol.Text = selectedRol.Nombre;

                    btnSearch.PerformClick();
                }
            }
        }
    }
}
