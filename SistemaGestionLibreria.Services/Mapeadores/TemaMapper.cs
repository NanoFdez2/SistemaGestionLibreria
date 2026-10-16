using SistemaGestionLibreria.Entities;
using SistemaGestionLibreria.Services.DTO.Tema;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.Mapeadores
{
    public static class TemaMapper
    {
        public static TemaListDto ToListDto(Tema tema)
        {
            return new TemaListDto
            {
                TemaId = tema.TemaId,
                Nombre = tema.Nombre,
                Descripcion = tema.Descripcion,
                Activo = tema.Activo
            };
        }
        public static Tema ToEntidad(TemaCreateDto temaDto)
        {
            return new Tema
            {
                Nombre = temaDto.Nombre,
                Descripcion = temaDto.Descripcion,
                Activo = temaDto.Activo
            };
        }
        public static Tema ToEntidad(TemaUpdateDto temaDto)
        {
            return new Tema
            {
                TemaId = temaDto.TemaId,
                Nombre = temaDto.Nombre,
                Descripcion = temaDto.Descripcion,
                Activo = temaDto.Activo,
                RowVersion = temaDto.RowVersion
            };
        }

        public static TemaUpdateDto ToUpdateDto(Tema tema)
        {
            return new TemaUpdateDto
            {
                TemaId = tema.TemaId,
                Nombre = tema.Nombre,
                Descripcion = tema.Descripcion,
                Activo = tema.Activo,
                RowVersion = tema.RowVersion
            };
        }

        public static TemaDeleteDto ToDeleteDto(Tema tema)
        {
            return new TemaDeleteDto
            {
                TemaId = tema.TemaId,
                RowVersion = tema.RowVersion,

            };
        }
    }
}
