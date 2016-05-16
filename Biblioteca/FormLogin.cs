using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "admin" && txtSenha.Text == "123")
            {
                new FormPrincipal().ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Dados inválidos tente novamente!");
                txtUsuario.Clear();
                txtSenha.Clear();
                txtUsuario.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
