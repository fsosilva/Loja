using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Loja.BLL;
using Loja.DAL;
using Loja.Modelos;

namespace Loja.UIWindows
{
    public partial class ProdutosEmFaltaForm : Form
    {
        private DataGridView produtosEmFaltaDataGridView;
        private Label produtosEmFaltaLabel;

        public ProdutosEmFaltaForm()
        {
            InitializeComponent();
        }

        private void ProdutosEmFaltaForm_Load(object sender, EventArgs e)
        {
            ProdutosBLL produto = new ProdutosBLL();
            produtosEmFaltaDataGridView.DataSource = produto.ProdutosEmFalta();
        }

        private void InitializeComponent()
        {
            this.produtosEmFaltaLabel = new System.Windows.Forms.Label();
            this.produtosEmFaltaDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.produtosEmFaltaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // produtosEmFaltaLabel
            // 
            this.produtosEmFaltaLabel.AutoSize = true;
            this.produtosEmFaltaLabel.Location = new System.Drawing.Point(9, 21);
            this.produtosEmFaltaLabel.Name = "produtosEmFaltaLabel";
            this.produtosEmFaltaLabel.Size = new System.Drawing.Size(147, 13);
            this.produtosEmFaltaLabel.TabIndex = 0;
            this.produtosEmFaltaLabel.Text = "Relatório de Produto em Falta";
            // 
            // produtosEmFaltaDataGridView
            // 
            this.produtosEmFaltaDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.produtosEmFaltaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.produtosEmFaltaDataGridView.Location = new System.Drawing.Point(12, 55);
            this.produtosEmFaltaDataGridView.Name = "produtosEmFaltaDataGridView";
            this.produtosEmFaltaDataGridView.Size = new System.Drawing.Size(474, 206);
            this.produtosEmFaltaDataGridView.TabIndex = 1;
            // 
            // ProdutosEmFaltaForm
            // 
            this.ClientSize = new System.Drawing.Size(497, 272);
            this.Controls.Add(this.produtosEmFaltaDataGridView);
            this.Controls.Add(this.produtosEmFaltaLabel);
            this.Name = "ProdutosEmFaltaForm";
            ((System.ComponentModel.ISupportInitialize)(this.produtosEmFaltaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}