using Biblioteca.Controller;
using Biblioteca.Model;
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
    public partial class FormUsuarioDevolucao : Form
    {
        private UsuarioController usuarioController;
        private EmprestimoController emprestimoController;
        private Emprestimo emprestimo;
        private string id;
        private DevolucaoController devolucaoController;

        public FormUsuarioDevolucao(UsuarioController usuarioController, 
            EmprestimoController emprestimoController, 
            DevolucaoController devolucaoController)
        {
            InitializeComponent();
            this.usuarioController = usuarioController;
            this.emprestimoController = emprestimoController;
            this.devolucaoController = devolucaoController;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = usuarioController.PorMatricula(txtMatricula.Text);
                if (usuario.Senha == txtSenha.Text)
                {
                    var emprestimos = new List<Emprestimo>();
                    foreach (var emprestimo in emprestimoController.Todos())
                    {
                        if((emprestimo.Usuario.Matricula == usuario.Matricula) && (!emprestimo.Finalizado))
                            emprestimos.Add(emprestimo);
                    }
                    dgvEmprestimos.DataSource = null;
                    dgvEmprestimos.DataSource = emprestimos;
                }
                else
                {
                    MessageBox.Show("Usuário: " + usuario.Nome + "\nsenha Inválida tente novamente");
                    txtMatricula.Focus();
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(txtMatricula.Text + " Não encontrada");
            }
        }

        private void dgvEmprestimos_SelectionChanged(object sender, EventArgs e)
        {
            id = dgvEmprestimos.CurrentRow.Cells[0].Value.ToString();
            emprestimo = emprestimoController.PorId(id.ToString());
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            new FormDevolucao(emprestimo, devolucaoController, emprestimoController).ShowDialog();
            this.Close();
        }

    }
}
