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
    public partial class FormBusca : Form
    {
        private LivroController livroController;

        public FormBusca(LivroController livroController)
        {
            InitializeComponent();
            this.livroController = livroController;

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dgvLivros.DataSource = null;
            dgvLivros.DataSource = livroController.PorTitulo(txtLivro.Text);
        }

    }
}
