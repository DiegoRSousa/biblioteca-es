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
    public partial class FormPrincipal : Form
    {
        private LivroController livroController = new LivroController();
        private UsuarioController usuarioController = new UsuarioController();
        private EmprestimoController emprestimoController = new EmprestimoController();
        private DevolucaoController devolucaoController = new DevolucaoController();
        private ReservaController reservaController = new ReservaController();

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormLivro(livroController).ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormUsuario(usuarioController).ShowDialog();
        }

        private void buscarLivrossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormUsuarioReserva(usuarioController, emprestimoController, livroController).ShowDialog();
        }

        private void buscarLivrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormBusca(livroController).ShowDialog();
        }

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormConfirmaUsuarioReserva(usuarioController, reservaController, livroController).ShowDialog();
        }

        private void devolucaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormUsuarioDevolucao(usuarioController, emprestimoController,
                devolucaoController).ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
