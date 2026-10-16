using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Windows.Helpers
{
    public static class ErrorHelper
    {
        public static void MostrarErrores(List<string> listaErrores)
        {
            string errores = string.Join("\n", listaErrores);
            MessageBox.Show(errores, "Errores",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
