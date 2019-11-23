using FCA001A.Controller;
using System;
using System.Windows.Forms;

namespace FCA001A
{
    public partial class FCA001A : Form
    {
        public FCA001A()
        {
            InitializeComponent();
            btnAtualizar.Enabled = false;
            btnDeletar.Enabled = false;
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCdusu.Text) && !string.IsNullOrWhiteSpace(txtNmusu.Text))
            {
                new CA001Controller().InserirUsuario(1, txtCdusu.Text, txtNmusu.Text, 178);
                CarregarListaUsuarios();
                LimparCampos();
            }
            else
                MessageBox.Show("Verifique o Numero do Cracha ou Nome do Usuario Vazio");
        }

        private void BtnDeletar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCdusu.Text))
            {
                if (MessageBox.Show("Tem Certeza", "Deseja Excluir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnEnviar.Enabled = true;
                    new CA001Controller().ExcluirUsuario(1, txtCdusu.Text);
                    CarregarListaUsuarios();
                    LimparCampos();
                }
            }
            else
                MessageBox.Show("Informa o Numero do Cracha");
        }
        private void CarregarListaUsuarios()
        {
            dgvUsuarios.DataSource = new CA001Controller().SelecionarUsuarios();
        }

        private void DgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCdusu.Text = dgvUsuarios.Rows[e.RowIndex].Cells["CDUSU"].Value.ToString();
            txtNmusu.Text = dgvUsuarios.Rows[e.RowIndex].Cells["NMUSU"].Value.ToString();

            btnEnviar.Enabled = false;
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCdusu.Text) && !string.IsNullOrWhiteSpace(txtNmusu.Text))
            {
                if (MessageBox.Show("Tem Certeza", "Deseja Atualizar ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnEnviar.Enabled = true;
                    new CA001Controller().UpdateUsuario(1, txtCdusu.Text, txtNmusu.Text, 178);
                    CarregarListaUsuarios();
                    LimparCampos();
                }
            }
            else
                MessageBox.Show("Verifique o Numero do Cracha ou Nome do Usuario Vazio");
        }
        public void LimparCampos()
        {
            txtCdusu.Text = string.Empty;
            txtNmusu.Text = string.Empty;
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            CarregarListaUsuarios();
            btnAtualizar.Enabled = true;
            btnDeletar.Enabled = true;
            btnEnviar.Enabled = true;
        }
    }
}

