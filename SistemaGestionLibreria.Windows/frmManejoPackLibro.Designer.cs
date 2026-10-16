namespace SistemaGestionLibreria.Windows
{
    partial class frmManejoPackLibro
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            cboLibros = new ComboBox();
            btnOk = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            label2 = new Label();
            txtCantidad = new TextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 41);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "LIBRO";
            // 
            // cboLibros
            // 
            cboLibros.FormattingEnabled = true;
            cboLibros.Location = new Point(139, 33);
            cboLibros.Name = "cboLibros";
            cboLibros.Size = new Size(333, 23);
            cboLibros.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(65, 158);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 79);
            btnOk.TabIndex = 4;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(470, 158);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 79);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 83);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 5;
            label2.Text = "CANTIDAD";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(139, 75);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.ReadOnly = true;
            txtCantidad.Size = new Size(333, 23);
            txtCantidad.TabIndex = 6;
            txtCantidad.Text = "1";
            // 
            // frmManejoPackLibro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 280);
            Controls.Add(txtCantidad);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(cboLibros);
            Controls.Add(label1);
            Name = "frmManejoPackLibro";
            Text = "frmManejoPackLibro";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cboLibros;
        private Button btnOk;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
        private Label label2;
        private TextBox txtCantidad;
    }
}