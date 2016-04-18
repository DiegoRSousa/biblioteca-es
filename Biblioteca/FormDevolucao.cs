using Biblioteca.Controller;
using Biblioteca.Model;
using Biblioteca.Service;
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
    public partial class FormDevolucao : Form
    {
        private DevolucaoController devolucaoController;
        private Emprestimo emprestimo;
        private Devolucao devolucao;
        private EmprestimoController emprestimoController; 

        public FormDevolucao(Emprestimo emprestimo, DevolucaoController controller,
            EmprestimoController emprestimoController)
        {
            InitializeComponent();
            this.emprestimo = emprestimo;
            this.devolucaoController = controller;
            this.emprestimoController = emprestimoController;
            AtualizaForm();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            devolucao = new Devolucao()
            {
                Id = Guid.NewGuid(),
                Emprestimo = emprestimo,
                DiasAtrasado = Calculadora.DiasAtrasado(emprestimo.DataPrevista),
                Data = DateTime.Now,
                Multa = Calculadora.Multa(emprestimo.DataPrevista)
            };
            this.devolucaoController.Inserir(devolucao);
            AtualizaDataGridView();
            emprestimo.Finalizado = true;
            emprestimoController.Atualizar(emprestimo);
            MessageBox.Show("Devolucao realizada com sucesso");
            this.Close();
        }

        private void FormDevolucao_Load(object sender, EventArgs e)
        {
            AtualizaDataGridView();
        }

        private void AtualizaDataGridView()
        {
            dgvDevolucoes.DataSource = null;
            dgvDevolucoes.DataSource = devolucaoController.Todos();
        }
        private void AtualizaForm() {
            txtUsuario.Text = emprestimo.Usuario.Nome;
            txtMatricula.Text = emprestimo.Usuario.Matricula;
            txtLivro.Text = emprestimo.Livro.Titulo;
            dtpDataPrevista.Value = emprestimo.DataPrevista;
            dtpData.Value = DateTime.Now;
            txtDiasAtrasado.Text = Convert.ToString(Calculadora.DiasAtrasado(emprestimo.DataPrevista));
            txtValorMulta.Text = Convert.ToString(Calculadora.Multa(emprestimo.DataPrevista));
        }
        
    }
}
