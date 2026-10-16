namespace SistemaGestionLibreria.Windows
{
    partial class frmTemas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTemas));
            toolStrip1 = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbBorrar = new ToolStripButton();
            tsbEditar = new ToolStripButton();
            tsbFiltrar = new ToolStripDropDownButton();
            activosToolStripMenuItem = new ToolStripMenuItem();
            noActivosToolStripMenuItem = new ToolStripMenuItem();
            toolStripLabel1 = new ToolStripLabel();
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
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbBorrar, tsbEditar, tsbFiltrar, toolStripLabel1, txtBuscar, tsbBuscar, tsbActualizar, tsbCerrar });
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
            // tsbFiltrar
            // 
            tsbFiltrar.DropDownItems.AddRange(new ToolStripItem[] { activosToolStripMenuItem, noActivosToolStripMenuItem });
            tsbFiltrar.Image = (Image)resources.GetObject("tsbFiltrar.Image");
            tsbFiltrar.ImageTransparentColor = Color.Magenta;
            tsbFiltrar.Name = "tsbFiltrar";
            tsbFiltrar.Size = new Size(63, 35);
            tsbFiltrar.Text = "FILTRAR";
            tsbFiltrar.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // activosToolStripMenuItem
            // 
            activosToolStripMenuItem.Name = "activosToolStripMenuItem";
            activosToolStripMenuItem.Size = new Size(130, 22);
            activosToolStripMenuItem.Text = "Activos";
            activosToolStripMenuItem.Click += activosToolStripMenuItem_Click;
            // 
            // noActivosToolStripMenuItem
            // 
            noActivosToolStripMenuItem.Name = "noActivosToolStripMenuItem";
            noActivosToolStripMenuItem.Size = new Size(130, 22);
            noActivosToolStripMenuItem.Text = "No activos";
            noActivosToolStripMenuItem.Click += noActivosToolStripMenuItem_Click;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(42, 35);
            toolStripLabel1.Text = "Buscar";
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
            dgvDatos.Size = new Size(800, 336);
            dgvDatos.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 406);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 2;
            label1.Text = "Cantidad de Registros";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(140, 406);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(13, 15);
            lblCantidad.TabIndex = 3;
            lblCantidad.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(256, 406);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 4;
            label2.Text = "Cantidad de Páginas";
            // 
            // lblPaginas
            // 
            lblPaginas.AutoSize = true;
            lblPaginas.Location = new Point(377, 406);
            lblPaginas.Name = "lblPaginas";
            lblPaginas.Size = new Size(13, 15);
            lblPaginas.TabIndex = 5;
            lblPaginas.Text = "0";
            // 
            // btnPrimero
            // 
            btnPrimero.Location = new Point(482, 390);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(56, 47);
            btnPrimero.TabIndex = 6;
            btnPrimero.Text = "<<";
            btnPrimero.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(544, 391);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(56, 47);
            btnAnterior.TabIndex = 6;
            btnAnterior.Text = "<";
            btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Location = new Point(606, 391);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(56, 47);
            btnSiguiente.TabIndex = 6;
            btnSiguiente.Text = ">";
            btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnUltimo
            // 
            btnUltimo.Location = new Point(668, 391);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(56, 47);
            btnUltimo.TabIndex = 6;
            btnUltimo.Text = ">>";
            btnUltimo.UseVisualStyleBackColor = true;
            // 
            // frmTemas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Name = "frmTemas";
            Text = "frmTemas";
            Load += frmTemas_Load;
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
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox txtBuscar;
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
        private ToolStripDropDownButton tsbFiltrar;
        private ToolStripMenuItem activosToolStripMenuItem;
        private ToolStripMenuItem noActivosToolStripMenuItem;
    }
}