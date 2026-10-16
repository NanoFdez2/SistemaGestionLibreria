namespace SistemaGestionLibreria.Windows
{
    partial class frmLibroAe
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
            Label label6;
            label1 = new Label();
            txtNombreLibro = new TextBox();
            label2 = new Label();
            txtISBN = new TextBox();
            label3 = new Label();
            cboTemas = new ComboBox();
            label4 = new Label();
            dtpAñoPublicacion = new DateTimePicker();
            label5 = new Label();
            txtPrecio = new TextBox();
            chkActivo = new CheckBox();
            btnOk = new Button();
            btnCancelar = new Button();
            txtStock = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            label7 = new Label();
            cboEditorial = new ComboBox();
            label8 = new Label();
            txtDescripcion = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 231);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 12;
            label6.Text = "Stock";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre Libro";
            // 
            // txtNombreLibro
            // 
            txtNombreLibro.Location = new Point(124, 6);
            txtNombreLibro.Name = "txtNombreLibro";
            txtNombreLibro.Size = new Size(261, 23);
            txtNombreLibro.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 45);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 2;
            label2.Text = "ISBN";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(124, 37);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(261, 23);
            txtISBN.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 86);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 4;
            label3.Text = "Temas";
            // 
            // cboTemas
            // 
            cboTemas.FormattingEnabled = true;
            cboTemas.Location = new Point(124, 83);
            cboTemas.Name = "cboTemas";
            cboTemas.Size = new Size(261, 23);
            cboTemas.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 135);
            label4.Name = "label4";
            label4.Size = new Size(110, 15);
            label4.TabIndex = 6;
            label4.Text = "Año de publicación";
            // 
            // dtpAñoPublicacion
            // 
            dtpAñoPublicacion.Location = new Point(124, 129);
            dtpAñoPublicacion.Name = "dtpAñoPublicacion";
            dtpAñoPublicacion.Size = new Size(261, 23);
            dtpAñoPublicacion.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 192);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 8;
            label5.Text = "Precio";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(124, 189);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(261, 23);
            txtPrecio.TabIndex = 9;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(212, 272);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 10;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(42, 288);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(80, 70);
            btnOk.TabIndex = 11;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(383, 288);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(80, 70);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(124, 228);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(261, 23);
            txtStock.TabIndex = 13;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(425, 9);
            label7.Name = "label7";
            label7.Size = new Size(50, 15);
            label7.TabIndex = 14;
            label7.Text = "Editorial";
            // 
            // cboEditorial
            // 
            cboEditorial.FormattingEnabled = true;
            cboEditorial.Location = new Point(481, 6);
            cboEditorial.Name = "cboEditorial";
            cboEditorial.Size = new Size(284, 23);
            cboEditorial.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(592, 68);
            label8.Name = "label8";
            label8.Size = new Size(69, 15);
            label8.TabIndex = 16;
            label8.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(481, 86);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(284, 165);
            txtDescripcion.TabIndex = 17;
            // 
            // frmLibroAe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtDescripcion);
            Controls.Add(label8);
            Controls.Add(cboEditorial);
            Controls.Add(label7);
            Controls.Add(txtStock);
            Controls.Add(label6);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(chkActivo);
            Controls.Add(txtPrecio);
            Controls.Add(label5);
            Controls.Add(dtpAñoPublicacion);
            Controls.Add(label4);
            Controls.Add(cboTemas);
            Controls.Add(label3);
            Controls.Add(txtISBN);
            Controls.Add(label2);
            Controls.Add(txtNombreLibro);
            Controls.Add(label1);
            Name = "frmLibroAe";
            Text = "frmLibroAe";
            Load += frmLibroAe_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombreLibro;
        private Label label2;
        private TextBox txtISBN;
        private Label label3;
        private ComboBox cboTemas;
        private Label label4;
        private DateTimePicker dtpAñoPublicacion;
        private Label label5;
        private TextBox txtPrecio;
        private CheckBox chkActivo;
        private Button btnOk;
        private Button btnCancelar;
        private TextBox txtStock;
        private ErrorProvider errorProvider1;
        private ComboBox cboEditorial;
        private Label label7;
        private TextBox txtDescripcion;
        private Label label8;
    }
}