using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Entities.Interfaces
{
    public interface IConcurrencyEntity
    {
        public byte[] RowVersion { get; set; }

    }
}
