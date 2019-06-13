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
            moverPanelSelec(btnInicio);
        }

        private void moverPanelSelec(Control btn)
        {
            pnlSelec.Top = btn.Top;
            pnlSelec.Height = btn.Height;
        }
        private void llenarPanelCont(Control uc)
        {
            uc.Dock = DockStyle.Fill;
            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(uc);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            moverPanelSelec(btnInicio);
            pnlContenido.Controls.Clear();
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            try
            {
                moverPanelSelec(btnAlumnos);
                ucGrillaAlumnos uc = new ucGrillaAlumnos();
                llenarPanelCont(uc);
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
                moverPanelSelec(btnProfesores);
                ucGrillaProfesores uc = new ucGrillaProfesores();
                llenarPanelCont(uc);
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
                moverPanelSelec(btnMaterias);
                ucGrillaMaterias uc = new ucGrillaMaterias();
                llenarPanelCont(uc);
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
                moverPanelSelec(btnCarreras);
                ucGrillaCarreras uc = new ucGrillaCarreras();
                llenarPanelCont(uc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHorarios_Click(object sender, EventArgs e)
        {
            try
            {
                moverPanelSelec(btnHorarios);
                ucGrillaHorarios uc = new ucGrillaHorarios();
                llenarPanelCont(uc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
