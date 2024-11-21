using Dao;
using Logic.Enums;
using Logic.Exceptions;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventHandler = UI.Generic.EventHandler;

namespace UI.EventHandlers.Turnos
{
    internal class DgvTurnosEventHandler : EventHandler
    {
        private DataGridView _dgv;

        private List<Especialidad> cachedEspecialidad = new List<Especialidad>();

        public DgvTurnosEventHandler(DataGridView dgv)
        {
            _dgv = dgv;
        }
        public void HandleOnDgvTurnosCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (_dgv.Columns[e.ColumnIndex].Name)
            {
                case "Estado":
                    FormatEstadoColumn(e);
                    break;

                case "Especialidad":
                    FormatEspecialidadColumn(e);
                    break;

                default:
                    break;
            }
        }

        private void FormatEstadoColumn(DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value is int estadoValue)
            {
                // Convertir el valor de Modulo a su nombre en el enum
                e.Value = Enum.GetName(typeof(EstadosTurnosEnum), estadoValue) ?? "Estado";
                e.FormattingApplied = true;
            }
        }
        private void FormatEspecialidadColumn(DataGridViewCellFormattingEventArgs e)
        {

            if (e.Value != null && e.Value is Guid EspecialidadId)
            {
                Especialidad? especialidad = cachedEspecialidad.FirstOrDefault(e => e.Id == EspecialidadId);

                if (especialidad == null)
                {
                    try
                    {
                        especialidad = EspecialidadService.Instance.GetById(new Especialidad { Id = EspecialidadId });

                        e.Value = especialidad.Nombre;
                    }
                    catch (NoEspecialidadFoundException ex)
                    {
                        MessageBox.Show($"{ex.Message}. Revisar Logs.",
                                        "Error de inconsistencia en BBDD.",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}. Revisar Logs.",
                                        "Ocurrió un error inesperado.",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
        }
        public override void HandleOnCreate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnDelete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnExit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnLoad(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnSaveChanges(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnShowPassword(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnTabChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void HandleOnVisualize(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
