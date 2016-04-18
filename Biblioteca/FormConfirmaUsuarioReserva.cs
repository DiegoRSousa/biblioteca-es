using Biblioteca.Controller;
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
    public partial class FormConfirmaUsuarioReserva : Form
    {
        UsuarioController usuarioController;
        ReservaController reservaController;
        LivroController livroController;

        public FormConfirmaUsuarioReserva(UsuarioController usuarioController,
            ReservaController reservaController, LivroController livroController)
        {
            InitializeComponent();
            this.usuarioController = usuarioController;
            this.reservaController = reservaController;
            this.livroController = livroController;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = usuarioController.PorMatricula(txtMatricula.Text);

                if (usuario.Senha == txtSenha.Text)
                {
                    new FormReserva(reservaController, usuario,
                        livroController).ShowDialog();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Usuário: " + usuario.Nome + "\nsenha Inválida tente novamente");
                    txtSenha.Focus();
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(txtMatricula.Text + " Não encontrado");
            }
        }
    }
}
