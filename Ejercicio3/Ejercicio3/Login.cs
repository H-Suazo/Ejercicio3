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
using Datos.Acceso;
using Datos.Entidad;

namespace Ejercicio3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        UsuarioDA usuarioDA = new UsuarioDA();

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario = usuarioDA.Login(txtUsuario.Text, txtClave.Text);

            if (usuario == null)
            {
                MessageBox.Show("Datos ingresados erróneos");
                return;
            }
            else
            {
                MessageBox.Show("Bienvenido(a) "+ usuario.Nombre);
            }
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            mostrarUsuario();
        }

        private void mostrarUsuario()
        {
            dGVUsuarios.DataSource = usuarioDA.MostrarUsuarios();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
