namespace SistemaGestionLibreria.Windows
{
    partial class frmPackAe
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
            txtNombrePack = new TextBox();
            label2 = new Label();
            nudStock = new NumericUpDown();
            chkActivo = new CheckBox();
            dgvDatos = new DataGridView();
            btnAgregarLibro = new Button();
            btnEliminarLibro = new Button();
            label3 = new Label();
            lblPrecio = new Label();
            label4 = new Label();
            lblCantidad = new Label();
            btnOk = new Button();
            btnCancelar = new Button();
            label5 = new Label();
            txtDescripcion = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 21);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre Pack";
            // 
            // txtNombrePack
            // 
            txtNombrePack.Location = new Point(122, 18);
            txtNombrePack.Name = "txtNombrePack";
            txtNombrePack.Size = new Size(272, 23);
            txtNombrePack.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(589, 18);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 2;
            label2.Text = "Stock";
            // 
            // nudStock
            // 
            nudStock.Location = new Point(631, 16);
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(120, 23);
            nudStock.TabIndex = 3;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(424, 22);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 4;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // dgvDatos
            // 
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Location = new Point(12, 177);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(613, 284);
            dgvDatos.TabIndex = 5;
            // 
            // btnAgregarLibro
            // 
            btnAgregarLibro.Location = new Point(676, 177);
            btnAgregarLibro.Name = "btnAgregarLibro";
            btnAgregarLibro.Size = new Size(75, 62);
            btnAgregarLibro.TabIndex = 6;
            btnAgregarLibro.Text = "AGREGAR LIBRO";
            btnAgregarLibro.UseVisualStyleBackColor = true;
            btnAgregarLibro.Click += btnAgregarLibro_Click;
            // 
            // btnEliminarLibro
            // 
            btnEliminarLibro.Location = new Point(676, 399);
            btnEliminarLibro.Name = "btnEliminarLibro";
            btnEliminarLibro.Size = new Size(75, 62);
            btnEliminarLibro.TabIndex = 6;
            btnEliminarLibro.Text = "ELIMINAR LIBRO";
            btnEliminarLibro.UseVisualStyleBackColor = true;
            btnEliminarLibro.Click += btnEliminarLibro_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 485);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 7;
            label3.Text = "PRECIO";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(124, 485);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(13, 15);
            lblPrecio.TabIndex = 8;
            lblPrecio.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 520);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 9;
            label4.Text = "Cantidad de Libros";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(124, 520);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(13, 15);
            lblCantidad.TabIndex = 10;
            lblCantidad.Text = "0";
            // 
            // btnOk
            // 
            btnOk.Location = new Point(219, 480);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 55);
            btnOk.TabIndex = 11;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(550, 480);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 55);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 75);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 13;
            label5.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(122, 67);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(272, 104);
            txtDescripcion.TabIndex = 14;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmPackAe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 544);
            Controls.Add(txtDescripcion);
            Controls.Add(label5);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(lblCantidad);
            Controls.Add(label4);
            Controls.Add(lblPrecio);
            Controls.Add(label3);
            Controls.Add(btnEliminarLibro);
            Controls.Add(btnAgregarLibro);
            Controls.Add(dgvDatos);
            Controls.Add(chkActivo);
            Controls.Add(nudStock);
            Controls.Add(label2);
            Controls.Add(txtNombrePack);
            Controls.Add(label1);
            Name = "frmPackAe";
            Text = "frmPackAe";
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombrePack;
        private Label label2;
        private NumericUpDown nudStock;
        private CheckBox chkActivo;
        private DataGridView dgvDatos;
        private Button btnAgregarLibro;
        private Button btnEliminarLibro;
        private Label label3;
        private Label lblPrecio;
        private Label label4;
        private Label lblCantidad;
        private Button btnOk;
        private Button btnCancelar;
        private Label label5;
        private TextBox txtDescripcion;
        private ErrorProvider errorProvider1;
    }
}