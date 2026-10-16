using SistemaGestionLibreria.Entities;
using SistemaGestionLibreria.Services.DTO.Autor;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.Mapeadores
{
    public static class AutorMapper
    {
        public static AutorDetailsDto ToDetailsDto(Autores autor)
        {
            return new AutorDetailsDto
            {
                AutorId = autor.AutorId,
                Nombre = autor.Nombre,
                Apellido = autor.Apellido,
                FechaNacimiento = autor.FechaDeNacimiento,
                Nacionalidad = autor.Nacionalidad
            };
        }

        public static AutorListDto ToListDto(Autores autor)
        {
            return new AutorListDto
            {
                AutorId = autor.AutorId,
                Nombre = autor.Nombre,
                Apellido = autor.Apellido,
                FechaDeNacimiento = autor.FechaDeNacimiento,
                Nacionalidad = autor.Nacionalidad

            };
        }
        public static Autores ToEntidad(AutorCreateDto autorDto)
        {
            return new Autores
            {
                AutorId = autorDto.AutorId,
                Nombre = autorDto.Nombre,
                Apellido = autorDto.Apellido,
                FechaDeNacimiento = autorDto.FechaDeNacimiento,
                Nacionalidad = autorDto.Nacionalidad


            };
        }
        public static Autores ToEntidad(AutorUpdateDto autorDto)
        {
            return new Autores
            {

                AutorId = autorDto.AutorId,
                Nombre = autorDto.Nombre,
                Apellido = autorDto.Apellido,
                FechaDeNacimiento = autorDto.FechaDeNacimiento,
                Nacionalidad = autorDto.Nacionalidad
            };
        }
    }
         
}

