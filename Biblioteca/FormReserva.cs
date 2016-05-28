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
    public partial class FormReserva : Form
    {
        ReservaController reservaController;
        Usuario usuario;
        Livro livro;
        LivroController livroController;


        public FormReserva(ReservaController reservaController, 
            Usuario usuario, LivroController livroController)
        {
            InitializeComponent();
            this.reservaController = reservaController;
            this.usuario = usuario;
            this.livroController = livroController;
            InicializaComboBox();

            txtUsuario.Text = this.usuario.Nome;
            txtMatricula.Text = this.usuario.Matricula;
            dtpData.Value = DateTime.Now;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cbxLivro.Text != string.Empty)
            {
                var reserva = new Reserva()
                {
                    Id = Guid.NewGuid(),
                    Usuario = usuario,
                    Livro = (Livro)cbxLivro.SelectedItem,
                    Data = dtpData.Value
                };

                this.reservaController.Inserir(reserva);
                livro = reserva.Livro;
                livro.Reservado = true;
                livroController.Atualizar(livro);

                AtualizaDataGridView();
                MessageBox.Show("Reserva realizada com sucesso!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios!");
                cbxLivro.Focus();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            
        }

        private void AtualizaDataGridView()
        {
            dgvReservas.DataSource = null;
            dgvReservas.DataSource = reservaController.Todos();
        }

        private void InicializaComboBox()
        {
            cbxLivro.Items.Clear();

            foreach (var livro in this.livroController.Todos())
            {
                cbxLivro.Items.Add(livro);
            }
        }

        private void FormReserva_Load(object sender, EventArgs e)
        {
            AtualizaDataGridView();
        }
    }
}
