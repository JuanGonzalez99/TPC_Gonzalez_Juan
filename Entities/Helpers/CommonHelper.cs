using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entities.Helpers
{
    public static class CommonHelper
    {
        public static bool Confirma(string texto = "¿Está seguro que desea eliminar el registro seleccionado?",
                                    string titulo = "Atención")
        {
            return MessageBox.Show(texto, titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK;
        }

        public static bool SeleccionoRegistro(DataGridView dgv, string textoError = "Debe seleccionar un registro")
        {
            if (dgv.CurrentRow == null)
            {
                MessageBox.Show(textoError, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void ShowInfo(string message)
        {
            MessageBox.Show(message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
