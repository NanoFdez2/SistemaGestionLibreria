namespace SistemaGestionLibreria.Windows
{
    partial class frmDetallePack
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
            label1 = new Label();
            txtDescripcion = new TextBox();
            btnCerrar = new Button();
            label2 = new Label();
            txtNombrePack = new TextBox();
            label3 = new Label();
            txtStock = new TextBox();
            dgvDatos = new DataGridView();
            colLibro = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            label4 = new Label();
            txtCantidadLibros = new TextBox();
            label5 = new Label();
            txtPrecio = new TextBox();
            chkActivo = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 53);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 0;
            label1.Text = "DESCRIPCIÓN";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(99, 50);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(522, 77);
            txtDescripcion.TabIndex = 1;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(713, 371);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 67);
            btnCerrar.TabIndex = 2;
            btnCerrar.Text = "CERRAR";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 3;
            label2.Text = "NOMBRE";
            // 
            // txtNombrePack
            // 
            txtNombrePack.Location = new Point(99, 6);
            txtNombrePack.Name = "txtNombrePack";
            txtNombrePack.Size = new Size(100, 23);
            txtNombrePack.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 160);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 5;
            label3.Text = "Stock";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(99, 157);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 6;
            // 
            // dgvDatos
            // 
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colLibro, colCantidad });
            dgvDatos.Location = new Point(6, 201);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(782, 150);
            dgvDatos.TabIndex = 7;
            // 
            // colLibro
            // 
            colLibro.DataPropertyName = "Titulo";
            colLibro.HeaderText = "Libros";
            colLibro.Name = "colLibro";
            colLibro.ReadOnly = true;
            // 
            // colCantidad
            // 
            colCantidad.DataPropertyName = "CantidadLibro";
            colCantidad.HeaderText = "Cantidad";
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 371);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 8;
            label4.Text = "Cantidad de Libros";
            // 
            // txtCantidadLibros
            // 
            txtCantidadLibros.Location = new Point(124, 368);
            txtCantidadLibros.Name = "txtCantidadLibros";
            txtCantidadLibros.Size = new Size(100, 23);
            txtCantidadLibros.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 407);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 10;
            label5.Text = "Precio";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(124, 404);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 11;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(614, 159);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 12;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // frmDetallePack
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(chkActivo);
            Controls.Add(txtPrecio);
            Controls.Add(label5);
            Controls.Add(txtCantidadLibros);
            Controls.Add(label4);
            Controls.Add(dgvDatos);
            Controls.Add(txtStock);
            Controls.Add(label3);
            Controls.Add(txtNombrePack);
            Controls.Add(label2);
            Controls.Add(btnCerrar);
            Controls.Add(txtDescripcion);
            Controls.Add(label1);
            Name = "frmDetallePack";
            Text = "frmDetalleCaja";
            Load += frmDetallePack_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtDescripcion;
        private Button btnCerrar;
        private Label label2;
        private TextBox txtNombrePack;
        private Label label3;
        private TextBox txtStock;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colLibro;
        private DataGridViewTextBoxColumn colCantidad;
        private Label label4;
        private TextBox txtCantidadLibros;
        private Label label5;
        private TextBox txtPrecio;
        private CheckBox chkActivo;
    }
}