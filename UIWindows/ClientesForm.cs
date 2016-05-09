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
using System.Xml;
using System.Xml.Schema;

namespace Loja.UIWindows
{
    public partial class ClientesForm : Form
    {
        private Label codigoLabel;
        private Label nomeLabel;
        private Label emailLabel;
        private TextBox codigoTextBox;
        private TextBox nomeTextBox;
        private TextBox emailTextBox;
        private TextBox telefoneTextBox;
        private TextBox txtFiltro;
        private DataGridView clientesDataGridView;
        private Button limparButton;
        private Button incluirButton;
        private Button alterarButton;
        private Button excluirButton;
        private Button btFiltro;
        private Label telefoneLabel;

        public ClientesForm()
        {
            InitializeComponent();
        }

        public void AtualizaGrid()
        {
            // Comunicação com a Camada BLL
            ClientesBLL obj = new ClientesBLL();
            clientesDataGridView.DataSource = obj.Listagem(txtFiltro.Text);
    
            // Atualizando os objetos TextBox
            try
            {
                codigoTextBox.Text = clientesDataGridView[0, clientesDataGridView.CurrentRow.Index].Value.ToString();
                nomeTextBox.Text = clientesDataGridView[1, clientesDataGridView.CurrentRow.Index].Value.ToString();
                emailTextBox.Text = clientesDataGridView[2, clientesDataGridView.CurrentRow.Index].Value.ToString();
                telefoneTextBox.Text = clientesDataGridView[3, clientesDataGridView.CurrentRow.Index].Value.ToString();
            }
            catch
            {
                codigoTextBox.Text = "";
                nomeTextBox.Text = "";
                emailTextBox.Text = "";
                telefoneTextBox.Text = "";
            }
            
        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {            
            AtualizaGrid();
            nomeTextBox.Focus();
        }

        private void limparButton_Click(object sender, EventArgs e)
        {            
            codigoTextBox.Text = "";
            nomeTextBox.Text = "";
            emailTextBox.Text = "";
            telefoneTextBox.Text = "";
        }

        private void incluirButton_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteInformation cliente = new ClienteInformation();
                cliente.Nome = nomeTextBox.Text;
                cliente.Email = emailTextBox.Text;
                cliente.Telefone = telefoneTextBox.Text;
                

                ClientesBLL obj = new ClientesBLL();
                obj.Incluir(cliente);
                MessageBox.Show("O cliente foi incluído com sucesso!");
                codigoTextBox.Text = Convert.ToString(cliente.Codigo);
                AtualizaGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void alterarButton_Click(object sender, EventArgs e)
        {
            if (codigoTextBox.Text.Length == 0)
            {
                MessageBox.Show("Um cliente deve ser selecionado para alteração.");
            }
            else
                try
                {
                    ClienteInformation cliente = new ClienteInformation();
                    cliente.Codigo = int.Parse(codigoTextBox.Text);
                    cliente.Nome = nomeTextBox.Text;
                    cliente.Email = emailTextBox.Text;
                    cliente.Telefone = telefoneTextBox.Text;
                    

                    ClientesBLL obj = new ClientesBLL();
                    obj.Alterar(cliente);
                    MessageBox.Show("O cliente foi alterado com sucesso!");
                    AtualizaGrid();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
        }

        private void excluirButton_Click(object sender, EventArgs e)
        {
            if (codigoTextBox.Text.Length == 0)
            {
                MessageBox.Show("Um cliente deve ser selecionado antes da exclusão.");
            }
            else
                try
                {
                    int codigo = Convert.ToInt32(codigoTextBox.Text);
                    ClientesBLL obj = new ClientesBLL();
                    obj.Excluir(codigo);
                    MessageBox.Show("O cliente foi excluído com sucesso!");
                    AtualizaGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
        }
        

        private void clientesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            // Atualizando os objetos TextBox
            codigoTextBox.Text = clientesDataGridView[0, clientesDataGridView.CurrentRow.Index].Value.ToString();
            nomeTextBox.Text = clientesDataGridView[1, clientesDataGridView.CurrentRow.Index].Value.ToString();
            emailTextBox.Text = clientesDataGridView[2, clientesDataGridView.CurrentRow.Index].Value.ToString();
            telefoneTextBox.Text = clientesDataGridView[3, clientesDataGridView.CurrentRow.Index].Value.ToString();
            

        }

        private void btFiltro_Click(object sender, EventArgs e)
        {
            
            // Comunicação com a Camada BLL
            ClientesBLL obj = new ClientesBLL();
            clientesDataGridView.DataSource = obj.Listagem(txtFiltro.Text);
            
            // Atualizando os objetos TextBox
            try {
                codigoTextBox.Text =  clientesDataGridView[0, clientesDataGridView.CurrentRow.Index].Value.ToString();
                nomeTextBox.Text = clientesDataGridView[1, clientesDataGridView.CurrentRow.Index].Value.ToString(); ;
                emailTextBox.Text = clientesDataGridView[2, clientesDataGridView.CurrentRow.Index].Value.ToString(); ;
                telefoneTextBox.Text = clientesDataGridView[3, clientesDataGridView.CurrentRow.Index].Value.ToString(); ;            
            }
            catch {
                codigoTextBox.Text = "";
                nomeTextBox.Text = "";
                emailTextBox.Text = "";
                telefoneTextBox.Text = "";
            }

        }

        private void InitializeComponent()
        {
            this.codigoLabel = new System.Windows.Forms.Label();
            this.nomeLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.telefoneLabel = new System.Windows.Forms.Label();
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.telefoneTextBox = new System.Windows.Forms.TextBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.clientesDataGridView = new System.Windows.Forms.DataGridView();
            this.limparButton = new System.Windows.Forms.Button();
            this.incluirButton = new System.Windows.Forms.Button();
            this.alterarButton = new System.Windows.Forms.Button();
            this.excluirButton = new System.Windows.Forms.Button();
            this.btFiltro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.clientesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // codigoLabel
            // 
            this.codigoLabel.AutoSize = true;
            this.codigoLabel.Location = new System.Drawing.Point(16, 32);
            this.codigoLabel.Name = "codigoLabel";
            this.codigoLabel.Size = new System.Drawing.Size(40, 13);
            this.codigoLabel.TabIndex = 0;
            this.codigoLabel.Text = "Código";
            // 
            // nomeLabel
            // 
            this.nomeLabel.AutoSize = true;
            this.nomeLabel.Location = new System.Drawing.Point(16, 64);
            this.nomeLabel.Name = "nomeLabel";
            this.nomeLabel.Size = new System.Drawing.Size(35, 13);
            this.nomeLabel.TabIndex = 1;
            this.nomeLabel.Text = "Nome";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(16, 96);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(32, 13);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "Email";
            // 
            // telefoneLabel
            // 
            this.telefoneLabel.AutoSize = true;
            this.telefoneLabel.Location = new System.Drawing.Point(16, 128);
            this.telefoneLabel.Name = "telefoneLabel";
            this.telefoneLabel.Size = new System.Drawing.Size(49, 13);
            this.telefoneLabel.TabIndex = 3;
            this.telefoneLabel.Text = "Telefone";
            // 
            // codigoTextBox
            // 
            this.codigoTextBox.Location = new System.Drawing.Point(110, 29);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.Size = new System.Drawing.Size(100, 20);
            this.codigoTextBox.TabIndex = 5;
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.Location = new System.Drawing.Point(110, 61);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(100, 20);
            this.nomeTextBox.TabIndex = 6;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(110, 93);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(100, 20);
            this.emailTextBox.TabIndex = 7;
            // 
            // telefoneTextBox
            // 
            this.telefoneTextBox.Location = new System.Drawing.Point(110, 125);
            this.telefoneTextBox.Name = "telefoneTextBox";
            this.telefoneTextBox.Size = new System.Drawing.Size(100, 20);
            this.telefoneTextBox.TabIndex = 8;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(24, 448);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(161, 20);
            this.txtFiltro.TabIndex = 9;
            // 
            // clientesDataGridView
            // 
            this.clientesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientesDataGridView.Location = new System.Drawing.Point(24, 208);
            this.clientesDataGridView.Name = "clientesDataGridView";
            this.clientesDataGridView.Size = new System.Drawing.Size(400, 207);
            this.clientesDataGridView.TabIndex = 10;
            // 
            // limparButton
            // 
            this.limparButton.Location = new System.Drawing.Point(110, 159);
            this.limparButton.Name = "limparButton";
            this.limparButton.Size = new System.Drawing.Size(75, 23);
            this.limparButton.TabIndex = 11;
            this.limparButton.Text = "Limpar";
            this.limparButton.UseVisualStyleBackColor = true;
            // 
            // incluirButton
            // 
            this.incluirButton.Location = new System.Drawing.Point(191, 159);
            this.incluirButton.Name = "incluirButton";
            this.incluirButton.Size = new System.Drawing.Size(75, 23);
            this.incluirButton.TabIndex = 12;
            this.incluirButton.Text = "Incluir";
            this.incluirButton.UseVisualStyleBackColor = true;
            // 
            // alterarButton
            // 
            this.alterarButton.Location = new System.Drawing.Point(272, 159);
            this.alterarButton.Name = "alterarButton";
            this.alterarButton.Size = new System.Drawing.Size(75, 23);
            this.alterarButton.TabIndex = 13;
            this.alterarButton.Text = "Alterar";
            this.alterarButton.UseVisualStyleBackColor = true;
            // 
            // excluirButton
            // 
            this.excluirButton.Location = new System.Drawing.Point(353, 159);
            this.excluirButton.Name = "excluirButton";
            this.excluirButton.Size = new System.Drawing.Size(75, 23);
            this.excluirButton.TabIndex = 14;
            this.excluirButton.Text = "Excluir";
            this.excluirButton.UseVisualStyleBackColor = true;
            // 
            // btFiltro
            // 
            this.btFiltro.Location = new System.Drawing.Point(192, 447);
            this.btFiltro.Name = "btFiltro";
            this.btFiltro.Size = new System.Drawing.Size(75, 23);
            this.btFiltro.TabIndex = 15;
            this.btFiltro.Text = "Filtrar";
            this.btFiltro.UseVisualStyleBackColor = true;
            // 
            // ClientesForm
            // 
            this.ClientSize = new System.Drawing.Size(436, 526);
            this.Controls.Add(this.btFiltro);
            this.Controls.Add(this.excluirButton);
            this.Controls.Add(this.alterarButton);
            this.Controls.Add(this.incluirButton);
            this.Controls.Add(this.limparButton);
            this.Controls.Add(this.clientesDataGridView);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.telefoneTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.nomeTextBox);
            this.Controls.Add(this.codigoTextBox);
            this.Controls.Add(this.telefoneLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.nomeLabel);
            this.Controls.Add(this.codigoLabel);
            this.Name = "ClientesForm";
            ((System.ComponentModel.ISupportInitialize)(this.clientesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}