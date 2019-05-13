using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using Services.Services;

namespace View
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            moveSidePanel(btnAlumnos);
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

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnAlumnos);
            Alumno a = new Alumno
            {
                Id = 3,
                Apellido = "Gomez",
                Nombre = "José",
                FechaNac = DateTime.Now.Date.AddYears(-20)
            };
            AlumnoService s = new AlumnoService();
            s.UpdateAlumno(a);
        }

        private void btnProfesores_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnProfesores);
            ProfesorService s = new ProfesorService();
            frmAltaProfesor ventana = new frmAltaProfesor(s.GetById(1));
            ventana.Show();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnMaterias);
            //MateriaService s = new MateriaService();
            //Materia m = new Materia();
            //m.Nombre = "Mi Materia";
            //m.Carrera = new Carrera();
            //m.Carrera.Id = 1;
            //m.Profesor = new Profesor();
            //m.Profesor.Id = 1;
            //m.Año = 
        }

        private void btnCarreras_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnCarreras);
        }
    }
}
