using MaterialSkin.Controls;
using Services.Domain;
using Services.Facade;
using Services.Logic.Exceptions;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Helpers;
using UI.Generic.FormsParametrizaciones.FormsRoles;
using UI.Generic.FormsParametrizaciones.FormPermiso;
using UI.Generic.FormsParametrizaciones.FormPermisos;
using UI.EventHandlers;

namespace UI.EventHandlers.Parametrizaciones.Permisos
{
    public class DgvScreenEventHandler : DgvEventHandler<Services.Domain.Screen>, IObservable<object>
    {
        private DataGridView dgvScreens;

        private List<IObserver<object>> observers = new List<IObserver<object>>();
        public DgvScreenEventHandler(Form form)
        {
            _form = form;

            dgvScreens = (DataGridView)FormHelpers.FindControl(_form, "dgvScreens");
        }
        public override void HandleDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleAddItem(object sender, EventArgs e)
        {
            AddScreenPopup addScreenPopup = new AddScreenPopup();
            addScreenPopup.ShowDialog();

            if (addScreenPopup.Canceled)
                return;

            try
            {
                ScreenFacade.AgregarPermisoAScreen((_form as GestionPermisosForm).previewingPermiso, addScreenPopup.selectedScreen);

                RefreshDgv();

                if (observers.Count > 0)
                    observers.ForEach(obs => obs.OnNext(null));
            }
            catch (RecursiveRoleAdditionException ex)
            {
                MessageBox.Show(ex.Message,
                    "Error en la adición de screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (RoleAlreadyExistInFatherException ex)
            {
                MessageBox.Show(ex.Message,
                    "Error en la adición de screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.",
                                        "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void HandleRemoveItem(object sender, EventArgs e)
        {
            if (dgvScreens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar la screen a eliminar.",
                                "Error en la eliminación de screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = dgvScreens.SelectedRows[0];

            Services.Domain.Screen screenSeleccionada = selectedRow.DataBoundItem as Services.Domain.Screen;

            try
            {
                ScreenFacade.RemoveScreenFromPermiso((_form as GestionPermisosForm).previewingPermiso, screenSeleccionada);
                RefreshDgv();

                if (observers.Count > 0)
                    observers.ForEach(obs => obs.OnNext(null));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. Revisar logs.",
                                        "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void RefreshDgv()
        {
            List<Services.Domain.Screen> childrenScreens = null;

            if ((_form as GestionPermisosForm).previewingPermiso == null)
            {
                FillDgv(null);
                return;
            }

            if ((_form as GestionPermisosForm).previewingPermiso.Screens != null)
            {
                childrenScreens = new List<Services.Domain.Screen>();

                (_form as GestionPermisosForm).previewingPermiso.Screens.ForEach(scr => childrenScreens.Add(scr));

                FillDgv(childrenScreens);
            }
        }
        public override void FillDgv(List<Services.Domain.Screen>? datasource)
        {
            dgvScreens.DataSource = datasource;
        }


        // Implementación de Subscribe
        public IDisposable Subscribe(IObserver<object> observer)
        {
            // Agregar el observador a la lista si no está ya registrado
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }

            // Devolver una instancia de Unsubscriber para permitir la cancelación
            return new Unsubscriber(observers, observer);
        }
    }
}
