using Microsoft.Extensions.DependencyInjection;

namespace SistemaGestionLibreria.Windows
{
    public partial class frmPrincipal : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public frmPrincipal(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTemas_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmTemas>())
            {
                frm.Text = "Lista de Temas";
                frm.ShowDialog();
            }
        }

        private void btnAutores_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmAutorAe>())
            {
                frm.Text = "Lista de Autores";
                frm.ShowDialog();
            }
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmLibro>())
            {
                frm.Text = "Listado de Libros";
                frm.ShowDialog();
            }
        }

        private void btnPacks_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmPack>())
            {
                frm.Text = "Listado de Packs";
                frm.ShowDialog();
            }
        }

        private void btnEditoriales_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmEditoriales>())
            {
                frm.Text = "Lista de Editoriales";
                frm.ShowDialog();
            }
        }
    }
}
