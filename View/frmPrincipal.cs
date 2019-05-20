using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.UserControls;

namespace View
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            moveSidePanel(btnInicio);
        }

        private void moveSidePanel(Control btn)
        {
            pnlSelec.Top = btn.Top;
            pnlSelec.Height = btn.Height;
        }
        private void fillMainDock(Control uc)
        {
            uc.Dock = DockStyle.Fill;
            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(uc);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnInicio);
            pnlContenido.Controls.Clear();
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            try
            {
                moveSidePanel(btnAlumnos);
                ucGrillaAlumnos uc = new ucGrillaAlumnos();
                fillMainDock(uc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProfesores_Click(object sender, EventArgs e)
        {
            try
            {
                moveSidePanel(btnProfesores);
                ucGrillaProfesores uc = new ucGrillaProfesores();
                fillMainDock(uc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            try
            {
                moveSidePanel(btnMaterias);
                ucGrillaMaterias uc = new ucGrillaMaterias();
                fillMainDock(uc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCarreras_Click(object sender, EventArgs e)
        {
            try
            {
                moveSidePanel(btnCarreras);
                ucGrillaCarreras uc = new ucGrillaCarreras();
                fillMainDock(uc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
