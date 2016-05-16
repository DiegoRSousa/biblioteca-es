using Biblioteca.Controller;
using Biblioteca.Model;
using Biblioteca.Service;
using System;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class FormEmprestimo : Form
    {
        private EmprestimoController emprestimoController;
        private Usuario usuario;
        private LivroController livroController;

        public FormEmprestimo(EmprestimoController emprestimoController,
            Usuario usuario, LivroController livroController)
        {
            InitializeComponent();
            this.emprestimoController = emprestimoController;
            this.usuario = usuario;
            this.livroController = livroController;
            InicializaComboBox();
            txtUsuario.Text = this.usuario.Nome;
            txtMatricula.Text = this.usuario.Matricula;
            dtpPrevista.Value = Calculadora.DataPrevista(dtpRetirada.Value);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cbxLivro.Text != string.Empty)
            {
                var emprestimo = new Emprestimo()
                {
                    Id = Guid.NewGuid(),
                    Usuario = usuario,
                    Livro = (Livro)cbxLivro.SelectedItem,
                    DataRetirada = dtpRetirada.Value,
                    DataPrevista = dtpPrevista.Value,
                    Finalizado = false
                };

                var livro = (Livro)cbxLivro.SelectedItem;
                if (livro.Reservado)
                {
                    if (MessageBox.Show("Livro reservado deseja continuar?", "Confirmar",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.emprestimoController.Inserir(emprestimo);
                        emprestimo.Livro.Reservado = false;
                        livroController.Atualizar(livro);

                        AtualizaDataGridView();

                        MessageBox.Show("Emprestimo realizado com sucesso! " +
                            "\nData Prevista para devolução: " + emprestimo.DataPrevista);
                        this.Close();
                    }

                }
                else
                {
                    this.emprestimoController.Inserir(emprestimo);

                    AtualizaDataGridView();

                    MessageBox.Show("Emprestimo realizado com sucesso! " +
                        "\nData Prevista para devolução: " + emprestimo.DataPrevista);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Por favor selecione um livro!");
            }
        }

        private void AtualizaDataGridView()
        {
            dgvEmprestimos.DataSource = null;
            dgvEmprestimos.DataSource = this.emprestimoController.Todos();
        }

        private void InicializaComboBox()
        {
            cbxLivro.Items.Clear();

            foreach (var livro in this.livroController.Todos())
            {
                cbxLivro.Items.Add(livro);
            }
        }
        private void FormEmprestimo_Load(object sender, EventArgs e)
        {
            AtualizaDataGridView();
        }
    }
}
