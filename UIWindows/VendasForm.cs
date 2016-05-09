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
    public partial class VendasForm : Form
    {
        private Label clienteLabel;
        private Label produtoLabel;
        private ComboBox clienteComboBox;
        private ComboBox produtoComboBox;
        private TextBox quantidadeTextBox;
        private Button incluirVendaButton;
        private Label quantidadeLabel;

        public VendasForm()
        {
            InitializeComponent();
        }

        private void VendasForm_Load(object sender, EventArgs e)
        {
            VendasBLL obj = new VendasBLL();
            clienteComboBox.DataSource = obj.ListaDeClientes;
            produtoComboBox.DataSource = obj.ListaDeProdutos;
        }

        private void incluirVendaButton_Click(object sender, EventArgs e)
        {
            try
            {
                VendaInformation venda = new VendaInformation();
                venda.Quantidade = int.Parse(quantidadeTextBox.Text);
                venda.CodigoCliente = (int)clienteComboBox.SelectedValue;
                venda.CodigoProduto = (int)produtoComboBox.SelectedValue;
                venda.Data = DateTime.Now;
                venda.Faturado = false;

                VendasBLL obj = new VendasBLL();
                obj.Incluir(venda);
                MessageBox.Show("A venda foi realizada com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void InitializeComponent()
        {
            this.clienteLabel = new System.Windows.Forms.Label();
            this.produtoLabel = new System.Windows.Forms.Label();
            this.quantidadeLabel = new System.Windows.Forms.Label();
            this.clienteComboBox = new System.Windows.Forms.ComboBox();
            this.produtoComboBox = new System.Windows.Forms.ComboBox();
            this.quantidadeTextBox = new System.Windows.Forms.TextBox();
            this.incluirVendaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clienteLabel
            // 
            this.clienteLabel.AutoSize = true;
            this.clienteLabel.Location = new System.Drawing.Point(35, 37);
            this.clienteLabel.Name = "clienteLabel";
            this.clienteLabel.Size = new System.Drawing.Size(39, 13);
            this.clienteLabel.TabIndex = 0;
            this.clienteLabel.Text = "Cliente";
            // 
            // produtoLabel
            // 
            this.produtoLabel.AutoSize = true;
            this.produtoLabel.Location = new System.Drawing.Point(35, 64);
            this.produtoLabel.Name = "produtoLabel";
            this.produtoLabel.Size = new System.Drawing.Size(44, 13);
            this.produtoLabel.TabIndex = 1;
            this.produtoLabel.Text = "Produto";
            // 
            // quantidadeLabel
            // 
            this.quantidadeLabel.AutoSize = true;
            this.quantidadeLabel.Location = new System.Drawing.Point(35, 95);
            this.quantidadeLabel.Name = "quantidadeLabel";
            this.quantidadeLabel.Size = new System.Drawing.Size(62, 13);
            this.quantidadeLabel.TabIndex = 2;
            this.quantidadeLabel.Text = "Quantidade";
            // 
            // clienteComboBox
            // 
            this.clienteComboBox.DisplayMember = "Nome";
            this.clienteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clienteComboBox.FormattingEnabled = true;
            this.clienteComboBox.Location = new System.Drawing.Point(106, 34);
            this.clienteComboBox.Name = "clienteComboBox";
            this.clienteComboBox.Size = new System.Drawing.Size(300, 21);
            this.clienteComboBox.TabIndex = 3;
            this.clienteComboBox.ValueMember = "Codigo";
            // 
            // produtoComboBox
            // 
            this.produtoComboBox.DisplayMember = "Nome";
            this.produtoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.produtoComboBox.FormattingEnabled = true;
            this.produtoComboBox.Location = new System.Drawing.Point(106, 64);
            this.produtoComboBox.Name = "produtoComboBox";
            this.produtoComboBox.Size = new System.Drawing.Size(300, 21);
            this.produtoComboBox.TabIndex = 4;
            this.produtoComboBox.ValueMember = "Codigo";
            // 
            // quantidadeTextBox
            // 
            this.quantidadeTextBox.Location = new System.Drawing.Point(106, 95);
            this.quantidadeTextBox.Name = "quantidadeTextBox";
            this.quantidadeTextBox.Size = new System.Drawing.Size(66, 20);
            this.quantidadeTextBox.TabIndex = 5;
            this.quantidadeTextBox.Text = "1";
            // 
            // incluirVendaButton
            // 
            this.incluirVendaButton.Location = new System.Drawing.Point(106, 128);
            this.incluirVendaButton.Name = "incluirVendaButton";
            this.incluirVendaButton.Size = new System.Drawing.Size(171, 23);
            this.incluirVendaButton.TabIndex = 6;
            this.incluirVendaButton.Text = "Realizar  a Venda";
            this.incluirVendaButton.UseVisualStyleBackColor = true;
            // 
            // VendasForm
            // 
            this.ClientSize = new System.Drawing.Size(529, 453);
            this.Controls.Add(this.incluirVendaButton);
            this.Controls.Add(this.quantidadeTextBox);
            this.Controls.Add(this.produtoComboBox);
            this.Controls.Add(this.clienteComboBox);
            this.Controls.Add(this.quantidadeLabel);
            this.Controls.Add(this.produtoLabel);
            this.Controls.Add(this.clienteLabel);
            this.Name = "VendasForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}