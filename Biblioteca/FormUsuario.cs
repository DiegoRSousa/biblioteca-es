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
    public partial class FormUsuario : Form
    {
        private UsuarioController usuarioController;

        public FormUsuario(UsuarioController controller)
        {
            InitializeComponent();
            this.usuarioController = controller;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text != string.Empty && txtMatricula.Text != string.Empty && txtNome.Text != string.Empty &&
                txtSenha.Text != string.Empty && txtTelefone.Text != string.Empty) 
            {
                var usuario = new Usuario()
                {
                    Id = (txtId.Text == string.Empty ? Guid.NewGuid() :
                        new Guid(txtId.Text)),
                    Matricula = txtMatricula.Text,
                    Nome = txtNome.Text,
                    Senha = txtSenha.Text,
                    Telefone = txtTelefone.Text,
                    Email = txtEmail.Text
                };

                if (txtId.Text == string.Empty)
                    this.usuarioController.Inserir(usuario);
                else
                    this.usuarioController.Atualizar(usuario);

                AtualizaDataGridView();
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios!");
                txtNome.Focus();
            }
            
        }

        private void LimparControles()
        {
            dgvUsuario.ClearSelection();
            txtId.Text = string.Empty;
            txtMatricula.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtSenha.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void dgvUsuario_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtId.Text = dgvUsuario.CurrentRow.Cells[0].Value.ToString();
                txtMatricula.Text = dgvUsuario.CurrentRow.Cells[1].Value.ToString();
                txtNome.Text = dgvUsuario.CurrentRow.Cells[2].Value.ToString();
                txtSenha.Text = dgvUsuario.CurrentRow.Cells[3].Value.ToString();
                txtTelefone.Text = dgvUsuario.CurrentRow.Cells[4].Value.ToString();
                txtEmail.Text = dgvUsuario.CurrentRow.Cells[5].Value.ToString();
            }
            catch (NullReferenceException ex)
            {
                dgvUsuario.ClearSelection();
            }
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text == string.Empty)
            {
                MessageBox.Show("Selecione o Usuario a ser removido!");
            }
            else
            {
                this.usuarioController.Remover(
                    new Usuario()
                    {
                        Id = new Guid(txtId.Text)
                    }
                );

                AtualizaDataGridView();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparControles();
        }

        private void AtualizaDataGridView()
        {
            dgvUsuario.DataSource = null;
            dgvUsuario.DataSource = this.usuarioController.Todos();
            LimparControles();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            AtualizaDataGridView();
        }

        
    }
}
