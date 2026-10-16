namespace SistemaGestionLibreria.Windows
{
    partial class frmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnLogOut = new Button();
            label1 = new Label();
            panel2 = new Panel();
            btnEditoriales = new Button();
            btnAutores = new Button();
            btnPacks = new Button();
            btnLibros = new Button();
            btnTemas = new Button();
            panel3 = new Panel();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnLogOut);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(994, 69);
            panel1.TabIndex = 0;
            // 
            // btnLogOut
            // 
            btnLogOut.Location = new Point(778, 10);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(74, 38);
            btnLogOut.TabIndex = 1;
            btnLogOut.Text = "LogOut";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(11, 7);
            label1.Name = "label1";
            label1.Size = new Size(310, 32);
            label1.TabIndex = 0;
            label1.Text = "SISTEMA GESTIÓN LIBRERIA";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnEditoriales);
            panel2.Controls.Add(btnAutores);
            panel2.Controls.Add(btnPacks);
            panel2.Controls.Add(btnLibros);
            panel2.Controls.Add(btnTemas);
            panel2.Location = new Point(1, 77);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 432);
            panel2.TabIndex = 1;
            // 
            // btnEditoriales
            // 
            btnEditoriales.Location = new Point(39, 257);
            btnEditoriales.Name = "btnEditoriales";
            btnEditoriales.Size = new Size(121, 53);
            btnEditoriales.TabIndex = 4;
            btnEditoriales.Text = "EDITORIALES";
            btnEditoriales.UseVisualStyleBackColor = true;
            btnEditoriales.Click += btnEditoriales_Click;
            // 
            // btnAutores
            // 
            btnAutores.Location = new Point(39, 197);
            btnAutores.Name = "btnAutores";
            btnAutores.Size = new Size(121, 53);
            btnAutores.TabIndex = 3;
            btnAutores.Text = "AUTORES";
            btnAutores.UseVisualStyleBackColor = true;
            btnAutores.Click += btnAutores_Click;
            // 
            // btnPacks
            // 
            btnPacks.Location = new Point(39, 138);
            btnPacks.Name = "btnPacks";
            btnPacks.Size = new Size(121, 53);
            btnPacks.TabIndex = 2;
            btnPacks.Text = "PACKS";
            btnPacks.UseVisualStyleBackColor = true;
            btnPacks.Click += btnPacks_Click;
            // 
            // btnLibros
            // 
            btnLibros.Location = new Point(39, 79);
            btnLibros.Name = "btnLibros";
            btnLibros.Size = new Size(121, 53);
            btnLibros.TabIndex = 1;
            btnLibros.Text = "LIBROS";
            btnLibros.UseVisualStyleBackColor = true;
            btnLibros.Click += btnLibros_Click;
            // 
            // btnTemas
            // 
            btnTemas.Location = new Point(39, 20);
            btnTemas.Name = "btnTemas";
            btnTemas.Size = new Size(121, 53);
            btnTemas.TabIndex = 0;
            btnTemas.Text = "TEMAS";
            btnTemas.UseVisualStyleBackColor = true;
            btnTemas.Click += btnTemas_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(207, 77);
            panel3.Name = "panel3";
            panel3.Size = new Size(788, 432);
            panel3.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Location = new Point(276, 161);
            label3.Name = "label3";
            label3.Size = new Size(141, 30);
            label3.TabIndex = 1;
            label3.Text = "Elija un menú";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(158, 36);
            label2.Name = "label2";
            label2.Size = new Size(388, 37);
            label2.TabIndex = 0;
            label2.Text = "Sistema de Gestión de Librerias";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(995, 509);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmPrincipal";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnLogOut;
        private Label label1;
        private Panel panel2;
        private Button btnTemas;
        private Panel panel3;
        private Button btnEditoriales;
        private Button btnAutores;
        private Button btnPacks;
        private Button btnLibros;
        private Label label3;
        private Label label2;
    }
}
