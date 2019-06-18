using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entities.Helpers
{
    public class CommonHelper
    {
        public static bool Confirma(string texto = "¿Está seguro que desea eliminar el registro seleccionado?",
                                    string titulo = "Atención")
        {
            return MessageBox.Show(texto, titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK;
        }

        public static bool SeleccionoRegistro(DataGridView dgv)
        {
            if (dgv.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
