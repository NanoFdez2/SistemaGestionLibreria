namespace SistemaGestionLibreria.Windows
{
    partial class frmPack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPack));
            toolStrip1 = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbBorrar = new ToolStripButton();
            tsbEditar = new ToolStripButton();
            tsbDetalles = new ToolStripButton();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            activoToolStripMenuItem = new ToolStripMenuItem();
            noActivoToolStripMenuItem = new ToolStripMenuItem();
            toolStripLabel1 = new ToolStripLabel();
            tsCboTemas = new ToolStripComboBox();
            toolStripLabel2 = new ToolStripLabel();
            txtBuscar = new ToolStripTextBox();
            tsbBuscar = new ToolStripButton();
            tsbActualizar = new ToolStripButton();
            tsbCerrar = new ToolStripButton();
            dgvDatos = new DataGridView();
            label1 = new Label();
            lblCantidad = new Label();
            label2 = new Label();
            lblPaginas = new Label();
            btnPrimero = new Button();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            btnUltimo = new Button();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbBorrar, tsbEditar, tsbDetalles, toolStripDropDownButton1, toolStripLabel1, tsCboTemas, toolStripLabel2, txtBuscar, tsbBuscar, tsbActualizar, tsbCerrar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(925, 38);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbNuevo
            // 
            tsbNuevo.Image = (Image)resources.GetObject("tsbNuevo.Image");
            tsbNuevo.ImageTransparentColor = Color.Magenta;
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(50, 35);
            tsbNuevo.Text = "NUEVO";
            tsbNuevo.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // tsbBorrar
            // 
            tsbBorrar.Image = (Image)resources.GetObject("tsbBorrar.Image");
            tsbBorrar.ImageTransparentColor = Color.Magenta;
            tsbBorrar.Name = "tsbBorrar";
            tsbBorrar.Size = new Size(56, 35);
            tsbBorrar.Text = "BORRAR";
            tsbBorrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbBorrar.Click += tsbBorrar_Click;
            // 
            // tsbEditar
            // 
            tsbEditar.Image = (Image)resources.GetObject("tsbEditar.Image");
            tsbEditar.ImageTransparentColor = Color.Magenta;
            tsbEditar.Name = "tsbEditar";
            tsbEditar.Size = new Size(49, 35);
            tsbEditar.Text = "EDITAR";
            tsbEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbEditar.Click += tsbEditar_Click;
            // 
            // tsbDetalles
            // 
            tsbDetalles.Image = (Image)resources.GetObject("tsbDetalles.Image");
            tsbDetalles.ImageTransparentColor = Color.Magenta;
            tsbDetalles.Name = "tsbDetalles";
            tsbDetalles.Size = new Size(63, 35);
            tsbDetalles.Text = "DETALLES";
            tsbDetalles.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbDetalles.Click += tsbDetalles_Click;
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { activoToolStripMenuItem, noActivoToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(105, 35);
            toolStripDropDownButton1.Text = "FILTRAR POR";
            // 
            // activoToolStripMenuItem
            // 
            activoToolStripMenuItem.Name = "activoToolStripMenuItem";
            activoToolStripMenuItem.Size = new Size(127, 22);
            activoToolStripMenuItem.Text = "Activo";
            activoToolStripMenuItem.Click += activoToolStripMenuItem_Click;
            // 
            // noActivoToolStripMenuItem
            // 
            noActivoToolStripMenuItem.Name = "noActivoToolStripMenuItem";
            noActivoToolStripMenuItem.Size = new Size(127, 22);
            noActivoToolStripMenuItem.Text = "No Activo";
            noActivoToolStripMenuItem.Click += noActivoToolStripMenuItem_Click;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(39, 35);
            toolStripLabel1.Text = "TEMA";
            // 
            // tsCboTemas
            // 
            tsCboTemas.Name = "tsCboTemas";
            tsCboTemas.Size = new Size(75, 38);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(51, 35);
            toolStripLabel2.Text = "BUSCAR";
            // 
            // txtBuscar
            // 
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(100, 38);
            // 
            // tsbBuscar
            // 
            tsbBuscar.Image = (Image)resources.GetObject("tsbBuscar.Image");
            tsbBuscar.ImageTransparentColor = Color.Magenta;
            tsbBuscar.Name = "tsbBuscar";
            tsbBuscar.Size = new Size(55, 35);
            tsbBuscar.Text = "BUSCAR";
            tsbBuscar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbBuscar.Click += tsbBuscar_Click;
            // 
            // tsbActualizar
            // 
            tsbActualizar.Image = (Image)resources.GetObject("tsbActualizar.Image");
            tsbActualizar.ImageTransparentColor = Color.Magenta;
            tsbActualizar.Name = "tsbActualizar";
            tsbActualizar.Size = new Size(81, 35);
            tsbActualizar.Text = "ACTUALIZAR";
            tsbActualizar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbActualizar.Click += tsbActualizar_Click;
            // 
            // tsbCerrar
            // 
            tsbCerrar.Image = (Image)resources.GetObject("tsbCerrar.Image");
            tsbCerrar.ImageTransparentColor = Color.Magenta;
            tsbCerrar.Name = "tsbCerrar";
            tsbCerrar.Size = new Size(54, 35);
            tsbCerrar.Text = "CERRAR";
            tsbCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbCerrar.Click += tsbCerrar_Click;
            // 
            // dgvDatos
            // 
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Location = new Point(0, 41);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(827, 329);
            dgvDatos.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 391);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 2;
            label1.Text = "Cantidad de Registros";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(140, 391);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(13, 15);
            lblCantidad.TabIndex = 3;
            lblCantidad.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(259, 391);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 4;
            label2.Text = "Cantidad de Páginas";
            // 
            // lblPaginas
            // 
            lblPaginas.AutoSize = true;
            lblPaginas.Location = new Point(380, 391);
            lblPaginas.Name = "lblPaginas";
            lblPaginas.Size = new Size(13, 15);
            lblPaginas.TabIndex = 5;
            lblPaginas.Text = "0";
            // 
            // btnPrimero
            // 
            btnPrimero.Location = new Point(523, 379);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(52, 39);
            btnPrimero.TabIndex = 6;
            btnPrimero.Text = "<<";
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(581, 379);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(52, 39);
            btnAnterior.TabIndex = 6;
            btnAnterior.Text = "<";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Location = new Point(639, 379);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(52, 39);
            btnSiguiente.TabIndex = 6;
            btnSiguiente.Text = ">";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnUltimo
            // 
            btnUltimo.Location = new Point(697, 379);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(52, 39);
            btnUltimo.TabIndex = 6;
            btnUltimo.Text = ">>";
            btnUltimo.UseVisualStyleBackColor = true;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // frmPack
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 427);
            Controls.Add(btnUltimo);
            Controls.Add(btnSiguiente);
            Controls.Add(btnAnterior);
            Controls.Add(btnPrimero);
            Controls.Add(lblPaginas);
            Controls.Add(label2);
            Controls.Add(lblCantidad);
            Controls.Add(label1);
            Controls.Add(dgvDatos);
            Controls.Add(toolStrip1);
            Name = "frmPack";
            Text = "frmPack";
            Load += frmPack_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbBorrar;
        private ToolStripButton tsbEditar;
        private ToolStripButton tsbDetalles;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem activoToolStripMenuItem;
        private ToolStripMenuItem noActivoToolStripMenuItem;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripButton tsbBuscar;
        private ToolStripButton tsbActualizar;
        private ToolStripButton tsbCerrar;
        private DataGridView dgvDatos;
        private Label label1;
        private Label lblCantidad;
        private Label label2;
        private Label lblPaginas;
        private Button btnPrimero;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Button btnUltimo;
        private ToolStripComboBox tsCboTemas;
        private ToolStripTextBox txtBuscar;
    }
}