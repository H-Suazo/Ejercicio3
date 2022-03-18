using Datos.Acceso;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Datos.Entidad;

namespace Ejercicio3
{
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        Usuario user = new Usuario();
        UsuarioDA usuarioDA = new UsuarioDA();
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            user.Codigo = txtCodigo.Text;
            user.Nombre = txtNombre.Text;
            user.Edad = Convert.ToInt32(txtEdad.Text);
            user.Clave = txtClave.Text;
            user.EstaActivo = chBoxEstaActivo.Checked;


            bool agregar = usuarioDA.AgregarUsuario(user);

            if (agregar)
            {
                MessageBox.Show("Usuario creado");
                Login login = new Login();
                login.Show();
            }
            else
            {
                MessageBox.Show("Usuario no creado");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
