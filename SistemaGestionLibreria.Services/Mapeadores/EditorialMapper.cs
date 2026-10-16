using SistemaGestionLibreria.Entities;
using SistemaGestionLibreria.Services.DTO.Editorial;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.Mapeadores
{
    public static class EditorialMapper
    {
        public static EditorialListDto ToListDto(Editorial editorial)
        {
            return new EditorialListDto
            {
                EditorialId = editorial.EditorialId,
                Nombre = editorial.Nombre,
                PaisDeOrigen = editorial.PaisDeOrigen,
                Activo = editorial.Activo
            };
        }
        public static Editorial ToEntidad(EditorialCreateDto editorialDto)
        {
            return new Editorial
            {
                Nombre = editorialDto.Nombre,
                PaisDeOrigen = editorialDto.PaisDeOrigen,
                Activo = editorialDto.Activo
            };
        }
        public static Editorial ToEntidad(EditorialUpdateDto editorialDto)
        {
            return new Editorial
            {
                EditorialId = editorialDto.EditorialId,
                Nombre = editorialDto.Nombre,
                PaisDeOrigen = editorialDto.PaisDeOrigen,
                Activo = editorialDto.Activo ?? false
            };
        }

        public static EditorialUpdateDto ToUpdateDto(Editorial editorial)
        {
            return new EditorialUpdateDto
            {
                EditorialId = editorial.EditorialId,
                Nombre = editorial.Nombre,
                PaisDeOrigen = editorial.PaisDeOrigen,
                RowVersion = editorial.RowVersion,
                Activo = editorial.Activo
            };
        }

        public static EditorialDeleteDto ToDeleteDto(Editorial editorial)
        {
            return new EditorialDeleteDto
            {
                EditorialId = editorial.EditorialId,
                RowVersion = editorial.RowVersion

            };
        }
    }
}
