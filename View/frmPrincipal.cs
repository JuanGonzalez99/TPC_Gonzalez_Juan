using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnProfesor_Click(object sender, EventArgs e)
        {
        }

        private void tsmAlumno_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmAlumno))
                {
                    form.Activate();
                    return;
                }
            }

            frmAlumno frmAlumno = new frmAlumno
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized,
                ControlBox = false
            };
            frmAlumno.Show();
        }

        private void tsmProfesor_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmProfesor))
                {
                    form.Activate();
                    return;
                }
            }

            frmProfesor frmProfesor = new frmProfesor
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized,
                ControlBox = false
            };
            frmProfesor.Show();
        }
    }
}
