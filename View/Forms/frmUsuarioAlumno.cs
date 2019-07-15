using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Forms
{
    public partial class frmUsuarioAlumno : Form
    {
        private UsuarioAlumno usuarioAlumno { get; set; }

        public frmUsuarioAlumno()
        {
            InitializeComponent();
        }

        public frmUsuarioAlumno(UsuarioAlumno usuarioAlumno)
        {
            InitializeComponent();
            this.usuarioAlumno = usuarioAlumno;
        }

        private void frmUsuarioAlumno_Load(object sender, EventArgs e)
        {

        }
    }
}
