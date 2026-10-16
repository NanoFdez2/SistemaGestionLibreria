namespace SistemaGestionLibreria.Windows
{
    partial class frmAutorAe
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
            ToolStripButton tsbCerrar;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutorAe));
            toolStrip1 = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbBorrar = new ToolStripButton();
            tsbEditar = new ToolStripButton();
            tsbDetalles = new ToolStripButton();
            tsbFiltrar = new ToolStripDropDownButton();
            activoToolStripMenuItem = new ToolStripMenuItem();
            noActivoToolStripMenuItem = new ToolStripMenuItem();
            toolStripLabel1 = new ToolStripLabel();
            txtBuscar = new ToolStripTextBox();
            tsbBuscar = new ToolStripButton();
            tsbActualizar = new ToolStripButton();
            dgvDatos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colFechaNac = new DataGridViewTextBoxColumn();
            colNacionalidad = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            btnUltimo = new Button();
            btnSiguiente = new Button();
            btnAnterior = new Button();
            btnPrimero = new Button();
            lblPaginas = new Label();
            label2 = new Label();
            lblCantidad = new Label();
            label1 = new Label();
            tsbCerrar = new ToolStripButton();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
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
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbBorrar, tsbEditar, tsbDetalles, tsbFiltrar, toolStripLabel1, txtBuscar, tsbBuscar, tsbActualizar, tsbCerrar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 38);
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
            // 
            // tsbFiltrar
            // 
            tsbFiltrar.DropDownItems.AddRange(new ToolStripItem[] { activoToolStripMenuItem, noActivoToolStripMenuItem });
            tsbFiltrar.Image = (Image)resources.GetObject("tsbFiltrar.Image");
            tsbFiltrar.ImageTransparentColor = Color.Magenta;
            tsbFiltrar.Name = "tsbFiltrar";
            tsbFiltrar.RightToLeftAutoMirrorImage = true;
            tsbFiltrar.Size = new Size(63, 35);
            tsbFiltrar.Text = "FILTRAR";
            tsbFiltrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbFiltrar.Click += tsbFiltrar_Click;
            // 
            // activoToolStripMenuItem
            // 
            activoToolStripMenuItem.Name = "activoToolStripMenuItem";
            activoToolStripMenuItem.Size = new Size(127, 22);
            activoToolStripMenuItem.Text = "Activo";
            // 
            // noActivoToolStripMenuItem
            // 
            noActivoToolStripMenuItem.Name = "noActivoToolStripMenuItem";
            noActivoToolStripMenuItem.Size = new Size(127, 22);
            noActivoToolStripMenuItem.Text = "No Activo";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(45, 35);
            toolStripLabel1.Text = "Buscar:";
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
            // dgvDatos
            // 
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre, colApellido, colFechaNac, colNacionalidad });
            dgvDatos.Location = new Point(0, 41);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(800, 351);
            dgvDatos.TabIndex = 1;
            // 
            // colId
            // 
            colId.DataPropertyName = "AutorId";
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colNombre
            // 
            colNombre.DataPropertyName = "Nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colApellido
            // 
            colApellido.DataPropertyName = "Apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.Name = "colApellido";
            colApellido.ReadOnly = true;
            // 
            // colFechaNac
            // 
            colFechaNac.DataPropertyName = "FechaDeNacimiento";
            colFechaNac.HeaderText = "Fecha Nacimiento";
            colFechaNac.Name = "colFechaNac";
            colFechaNac.ReadOnly = true;
            // 
            // colNacionalidad
            // 
            colNacionalidad.DataPropertyName = "Nacionalidad";
            colNacionalidad.HeaderText = "Nacionalidad";
            colNacionalidad.Name = "colNacionalidad";
            colNacionalidad.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnUltimo);
            panel1.Controls.Add(btnSiguiente);
            panel1.Controls.Add(btnAnterior);
            panel1.Controls.Add(btnPrimero);
            panel1.Controls.Add(lblPaginas);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblCantidad);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 398);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 100);
            panel1.TabIndex = 2;
            // 
            // btnUltimo
            // 
            btnUltimo.Location = new Point(659, 4);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(52, 39);
            btnUltimo.TabIndex = 4;
            btnUltimo.Text = ">>";
            btnUltimo.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Location = new Point(601, 4);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(52, 39);
            btnSiguiente.TabIndex = 4;
            btnSiguiente.Text = ">";
            btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(543, 4);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(52, 39);
            btnAnterior.TabIndex = 4;
            btnAnterior.Text = "<";
            btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnPrimero
            // 
            btnPrimero.Location = new Point(485, 4);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(52, 39);
            btnPrimero.TabIndex = 4;
            btnPrimero.Text = "<<";
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // lblPaginas
            // 
            lblPaginas.AutoSize = true;
            lblPaginas.Location = new Point(377, 16);
            lblPaginas.Name = "lblPaginas";
            lblPaginas.Size = new Size(13, 15);
            lblPaginas.TabIndex = 3;
            lblPaginas.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(256, 16);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 2;
            label2.Text = "Cantidad de páginas";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(131, 16);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(13, 15);
            lblCantidad.TabIndex = 1;
            lblCantidad.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 16);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 0;
            label1.Text = "Cantidad de Registros";
            // 
            // frmAutorAe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(dgvDatos);
            Controls.Add(toolStrip1);
            Name = "frmAutorAe";
            Text = "frmAutorAe";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbBorrar;
        private ToolStripButton tsbEditar;
        private ToolStripButton tsbDetalles;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox txtBuscar;
        private ToolStripButton tsbBuscar;
        private ToolStripButton tsbActualizar;
        private ToolStripButton tsbCerrar;
        private DataGridView dgvDatos;
        private Panel panel1;
        private Button btnUltimo;
        private Button btnSiguiente;
        private Button btnAnterior;
        private Button btnPrimero;
        private Label lblPaginas;
        private Label label2;
        private Label lblCantidad;
        private Label label1;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colFechaNac;
        private DataGridViewTextBoxColumn colNacionalidad;
        private ToolStripDropDownButton tsbFiltrar;
        private ToolStripMenuItem activoToolStripMenuItem;
        private ToolStripMenuItem noActivoToolStripMenuItem;
    }
}