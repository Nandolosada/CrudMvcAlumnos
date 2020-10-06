using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CRUDMvcAspAlumnos.Models
{
    public class AlumnModel
    {
        [Required]
        [Display(Name ="Ingrese Nombres")]
        public string Nombres { get; set; }
        [Required]
        [Display(Name = "Ingrese Apellidos")]
        public string Apellidos { get; set; }
        [Required]
        [Display(Name = "Edad del Alumno")]
        public int Edad { get; set; }
        [Required]
        [Display(Name = "Sexo del Alumno")]
        public string Sexo { get; set; }

        [Required]
        [Display(Name = "Ciudad")]
        public int CodCiudad { get; set; }

        public string NombreCiudad { get; set; }
        public string NombreCompleto { get { return Nombres + " " + Apellidos; } }
        public System.DateTime FechaRegistro { get; set; }

        public int Id { get; set; }


    }

    [MetadataType(typeof(AlumnModel))]
    public partial class alumno { 
        public string NombreCompleto { get { return Nombres + " " + Apellidos; } }

        public string NombreCiudad { get; set; }

    }
}