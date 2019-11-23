namespace WindowsForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picUsuario = new System.Windows.Forms.PictureBox();
            this.btnExibir = new System.Windows.Forms.Button();
            this.ofdUsuario = new System.Windows.Forms.OpenFileDialog();
            this.btnArquivo = new System.Windows.Forms.Button();
            this.btnVotar = new System.Windows.Forms.Button();
            this.txtCandidato = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // picUsuario
            // 
            this.picUsuario.Location = new System.Drawing.Point(95, 28);
            this.picUsuario.Name = "picUsuario";
            this.picUsuario.Size = new System.Drawing.Size(261, 241);
            this.picUsuario.TabIndex = 0;
            this.picUsuario.TabStop = false;
            // 
            // btnExibir
            // 
            this.btnExibir.Location = new System.Drawing.Point(95, 275);
            this.btnExibir.Name = "btnExibir";
            this.btnExibir.Size = new System.Drawing.Size(75, 23);
            this.btnExibir.TabIndex = 1;
            this.btnExibir.Text = "Exibir";
            this.btnExibir.UseVisualStyleBackColor = true;
            this.btnExibir.Click += new System.EventHandler(this.BtnExibir_Click);
            // 
            // ofdUsuario
            // 
            this.ofdUsuario.FileName = "openFileDialog1";
            // 
            // btnArquivo
            // 
            this.btnArquivo.Location = new System.Drawing.Point(257, 275);
            this.btnArquivo.Name = "btnArquivo";
            this.btnArquivo.Size = new System.Drawing.Size(103, 23);
            this.btnArquivo.TabIndex = 2;
            this.btnArquivo.Text = "Escolher Imagem";
            this.btnArquivo.UseVisualStyleBackColor = true;
            this.btnArquivo.Click += new System.EventHandler(this.BtnArquivo_Click);
            // 
            // btnVotar
            // 
            this.btnVotar.Location = new System.Drawing.Point(479, 246);
            this.btnVotar.Name = "btnVotar";
            this.btnVotar.Size = new System.Drawing.Size(75, 23);
            this.btnVotar.TabIndex = 3;
            this.btnVotar.Text = "Votar";
            this.btnVotar.UseVisualStyleBackColor = true;
            // 
            // txtCandidato
            // 
            this.txtCandidato.Location = new System.Drawing.Point(373, 246);
            this.txtCandidato.Name = "txtCandidato";
            this.txtCandidato.Size = new System.Drawing.Size(100, 20);
            this.txtCandidato.TabIndex = 4;
            this.txtCandidato.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Informe o Numero do seu Candidato";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCandidato);
            this.Controls.Add(this.btnVotar);
            this.Controls.Add(this.btnArquivo);
            this.Controls.Add(this.btnExibir);
            this.Controls.Add(this.picUsuario);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picUsuario;
        private System.Windows.Forms.Button btnExibir;
        private System.Windows.Forms.OpenFileDialog ofdUsuario;
        private System.Windows.Forms.Button btnArquivo;
        private System.Windows.Forms.Button btnVotar;
        private System.Windows.Forms.TextBox txtCandidato;
        private System.Windows.Forms.Label label1;
    }
}

