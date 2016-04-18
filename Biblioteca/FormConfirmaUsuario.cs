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
    public partial class FormUsuarioReserva : Form
    {
        UsuarioController usuarioController;
        EmprestimoController emprestimoController;
        LivroController livroController;

        public FormUsuarioReserva(UsuarioController usuarioController, 
            EmprestimoController emprestimoController, LivroController livroController)
        {
            InitializeComponent();
            this.usuarioController = usuarioController;
            this.emprestimoController = emprestimoController;
            this.livroController = livroController;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = usuarioController.PorMatricula(txtMatricula.Text);

                if (usuario.Senha == txtSenha.Text)
                {
                    new FormEmprestimo(emprestimoController, usuario,
                        livroController).ShowDialog();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Usuário: " + usuario.Nome + "\nsenha Inválida tente novamente");
                    txtSenha.Focus();
                }
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show(txtMatricula.Text + " Não encontrado");
            }
            
        }
    }
}
