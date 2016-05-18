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
    public partial class FormLivro : Form
    {
        private LivroController livroController;

        public FormLivro(LivroController controller)
        {
            InitializeComponent();
            this.livroController = controller;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(txtAutor.Text != string.Empty && txtCodigo.Text != string.Empty &&
                txtEdicao.Text != string.Empty && txtTitulo.Text != string.Empty)
            {
                var livro = new Livro()
                {
                    Id = (txtId.Text == string.Empty ? Guid.NewGuid() :
                        new Guid(txtId.Text)),
                    Codigo = txtCodigo.Text,
                    Titulo = txtTitulo.Text,
                    Edicao = txtEdicao.Text,
                    Autor = txtAutor.Text,
                    Reservado = false

                };
                if (txtId.Text == string.Empty)
                    this.livroController.Inserir(livro);
                else
                    this.livroController.Atualizar(livro);


                AtualizaDataGridView();
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios!");
            }
        }

        private void LimparControles()
        {
            dgvLivros.ClearSelection();
            txtId.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtTitulo.Text = string.Empty;
            txtEdicao.Text = string.Empty;
            txtAutor.Text = string.Empty;
            txtCodigo.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparControles();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text == string.Empty)
            {
                MessageBox.Show("Selecione um LIVRO a ser removido no GRID");
            }
            else
            {
                this.livroController.Remover(
                    new Livro() 
                    {
                        Id = new Guid(txtId.Text)
                    }
                );

                AtualizaDataGridView();
            }
        }

        private void dgvLivros_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtId.Text = dgvLivros.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text = dgvLivros.CurrentRow.Cells[1].Value.ToString();
                txtTitulo.Text = dgvLivros.CurrentRow.Cells[2].Value.ToString();
                txtAutor.Text = dgvLivros.CurrentRow.Cells[3].Value.ToString();
                txtEdicao.Text = dgvLivros.CurrentRow.Cells[4].Value.ToString();
            }
            catch(NullReferenceException ex)
            {
                dgvLivros.ClearSelection();
            }
        }

        private void AtualizaDataGridView()
        {
            dgvLivros.DataSource = null;
            dgvLivros.DataSource = this.livroController.Todos();
            LimparControles();
        }

        private void FormLivro_Load(object sender, EventArgs e)
        {
            AtualizaDataGridView();
        }
        
    }
}
