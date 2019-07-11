using Entities.Helpers;
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
            try
            {
                pnlSelec.Top = btn.Top;
                pnlSelec.Height = btn.Height;
            }
            catch (Exception ex)
            {
                CommonHelper.ShowError(ex.Message);
            }
        }
        private void llenarPanelCont(Control uc)
        {
            try
            {
                uc.Dock = DockStyle.Fill;
                pnlContenido.Controls.Clear();
                pnlContenido.Controls.Add(uc);
            }
            catch (Exception ex)
            {
                CommonHelper.ShowError(ex.Message);
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            moverPanelSelec(btnInicio);
            pnlContenido.Controls.Clear();
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            moverPanelSelec(btnAlumnos);
            ucGrillaAlumnos uc = new ucGrillaAlumnos();
            llenarPanelCont(uc);
        }

        private void btnProfesores_Click(object sender, EventArgs e)
        {
            moverPanelSelec(btnProfesores);
            ucGrillaProfesores uc = new ucGrillaProfesores();
            llenarPanelCont(uc);
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            moverPanelSelec(btnMaterias);
            ucGrillaMaterias uc = new ucGrillaMaterias();
            llenarPanelCont(uc);
        }

        private void btnCarreras_Click(object sender, EventArgs e)
        {
            moverPanelSelec(btnCarreras);
            ucGrillaCarreras uc = new ucGrillaCarreras();
            llenarPanelCont(uc);
        }

        private void btnHorarios_Click(object sender, EventArgs e)
        {
            moverPanelSelec(btnHorarios);
            ucGrillaHorarios uc = new ucGrillaHorarios();
            llenarPanelCont(uc);
        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            moverPanelSelec(btnComisiones);
            ucGrillaComisiones uc = new ucGrillaComisiones();
            llenarPanelCont(uc);
        }

        private void btnInscripciones_Click(object sender, EventArgs e)
        {
            moverPanelSelec(btnInscripciones);
            ucGrillaInscripciones uc = new ucGrillaInscripciones();
            llenarPanelCont(uc);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            moverPanelSelec(btnUsuarios);
            ucGrillaUsuarios uc = new ucGrillaUsuarios();
            llenarPanelCont(uc);
        }
    }
}
