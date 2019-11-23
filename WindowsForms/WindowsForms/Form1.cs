using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnExibir_Click(object sender, EventArgs e)
        {
            picUsuario.Image = Image.FromFile("C:\\Users\\k27287\\source\\repos\\Aula\\WindowsForms\\WindowsForms\\Foto\\Menino.jpg");
            picUsuario.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void BtnArquivo_Click(object sender, EventArgs e)
        {
            var files = ofdUsuario.ShowDialog();

            if (files == DialogResult.OK)
            {
                var jpegs = new DirectoryInfo(@"C:\\Users\\k27287\\source\\repos\\Aula\\WindowsForms\\WindowsForms\\Foto\\").GetFiles("*.jpg").Select(a => a.Name);
                var quantidadeJpegs = jpegs.Count();

                string nomefile = "0"+(quantidadeJpegs+1).ToString();
                string arquivo = ofdUsuario.FileName;
                picUsuario.Image = Image.FromFile(arquivo);
                picUsuario.Image.Save($"C:\\Users\\k27287\\source\\repos\\Aula\\WindowsForms\\WindowsForms\\Foto\\{nomefile}.jpg", ImageFormat.Jpeg);
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtCandidato.Text.Length > 1)
            {
                try
                {
                    picUsuario.Image = Image.FromFile($"C:\\Users\\k27287\\source\\repos\\Aula\\WindowsForms\\WindowsForms\\Foto\\{txtCandidato.Text}.jpg");
                }
                catch
                {
                    picUsuario.Image = null;
                }
            }
            
        }
    }
}
