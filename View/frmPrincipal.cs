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

        //private void atsmAlumno_Click(object sender, EventArgs e)
        //{
        //    foreach (Form form in Application.OpenForms)
        //    {
        //        if (form.GetType() == typeof(frmAltaAlumno))
        //        {
        //            if (form.WindowState == FormWindowState.Minimized)
        //                form.WindowState = FormWindowState.Normal;
        //            form.Activate();
        //            return;
        //        }
        //    }

        //    frmAltaAlumno ventana = new frmAltaAlumno
        //    {
        //        MdiParent = this
        //    };

        //    ventana.Show();
        //}

        //private void mtsmAlumno_Click(object sender, EventArgs e)
        //{
        //    foreach (Form form in Application.OpenForms)
        //    {
        //        if (form.GetType() == typeof(frmAltaAlumno))
        //        {
        //            if (form.WindowState == FormWindowState.Minimized)
        //                form.WindowState = FormWindowState.Normal;
        //            form.Activate();
        //            return;
        //        }
        //    }

        //    AlumnoService s = new AlumnoService();
        //    List<Alumno> alumnos = s.GetAll();
        //    Random random = new Random(DateTime.Now.Millisecond);

        //    frmAltaAlumno ventana = new frmAltaAlumno(alumnos[random.Next(alumnos.Count)])
        //    {
        //        MdiParent = this
        //    };

        //    ventana.Show();
        //}

        //private void atsmProfesor_Click(object sender, EventArgs e)
        //{
        //    foreach (Form form in Application.OpenForms)
        //    {
        //        if (form.GetType() == typeof(frmAltaProfesor))
        //        {
        //            if (form.WindowState == FormWindowState.Minimized)
        //                form.WindowState = FormWindowState.Normal;
        //            form.Activate();
        //            return;
        //        }
        //    }

        //    frmAltaProfesor ventana = new frmAltaProfesor
        //    {
        //        MdiParent = this
        //    };
        //    ventana.Show();
        //}

        //private void mtsmProfesor_Click(object sender, EventArgs e)
        //{
        //    foreach (Form form in Application.OpenForms)
        //    {
        //        if (form.GetType() == typeof(frmAltaProfesor))
        //        {
        //            if (form.WindowState == FormWindowState.Minimized)
        //                form.WindowState = FormWindowState.Normal;
        //            form.Activate();
        //            return;
        //        }
        //    }

        //    ProfesorService s = new ProfesorService();
        //    List<Profesor> profes = s.GetAll();
        //    Random random = new Random(DateTime.Now.Millisecond);

        //    frmAltaProfesor ventana = new frmAltaProfesor(profes[random.Next(profes.Count)])
        //    {
        //        MdiParent = this
        //    };
        //    ventana.Show();
        //}

        private void moveSidePanel(Control btn)
        {
            pnlSelec.Top = btn.Top;
            pnlSelec.Height = btn.Height;
        }
        private void fillMainDock(Control frm)
        {
            frm.Dock = DockStyle.Fill;
            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(frm);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnInicio);
            pnlContenido.Controls.Clear();
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnAlumnos);
            ucGrillaAlumnos uc = new ucGrillaAlumnos();
            fillMainDock(uc);
        }

        private void btnProfesores_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnProfesores);
            ucGrillaProfesores uc = new ucGrillaProfesores();
            fillMainDock(uc);
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnMaterias);
            ucGrillaMaterias uc = new ucGrillaMaterias();
            fillMainDock(uc);
        }

        private void btnCarreras_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnCarreras);
            ucGrillaCarreras uc = new ucGrillaCarreras();
            fillMainDock(uc);
        }
    }
}
