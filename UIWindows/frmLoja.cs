using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Loja.UIWindows
{
    public partial class frmLoja : Form
    {
        public frmLoja()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientesForm obj = new ClientesForm();
            obj.MdiParent = this;
            obj.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProdutosForm obj = new ProdutosForm();
            obj.MdiParent = this;
            obj.Show();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VendasForm obj = new VendasForm();
            obj.MdiParent = this;
            obj.Show();
        }

        private void produtosEmFaltaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProdutosEmFaltaForm obj = new ProdutosEmFaltaForm();
            obj.MdiParent = this;
            obj.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
