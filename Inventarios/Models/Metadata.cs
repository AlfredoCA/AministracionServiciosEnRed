using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventarios.Models
{
    public class PersonalsMetadata    
    {

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nombre del empleado")]
        [MinLength(5, ErrorMessage = "El número de caracteres es muy corto")]        
        [MaxLength(50, ErrorMessage = "Excediste el tamaño definido del campo")]        
        public string Nombre;

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Teléfono")]
        [MinLength(3, ErrorMessage = "El teléfono es muy corto")]
        [MaxLength(20, ErrorMessage = "Excediste el tamaño definido del campo")]        
        [Phone(ErrorMessage = "Formato inválido")]        
        public string Telefono;

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Correo electrónico")]
        [StringLength(50, ErrorMessage = "Excediste el tamaño definido del campo")]
        [EmailAddress(ErrorMessage = "Formato inválido")]        
        public string Email;

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Puesto")]
        [MinLength(3, ErrorMessage = "El número de caracteres es muy corto")]
        [MaxLength(30, ErrorMessage = "Excediste el tamaño definido del campo")]        
        public string Puesto;

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Departamento")]        
        public int IdDepartamento;
    }

    public class DepartamentosMetadata
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Departamento")]
        [MinLength(3, ErrorMessage = "El número de caracteres es muy corto")]
        [MaxLength(30, ErrorMessage = "Excediste el tamaño definido del campo")] 
        public string Nombre;
    }

    public class ArticulosMetadata
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Identificador")]
        [Range(0,  2147483647, ErrorMessage = "Id invalido")]
        public int IdArticulo;

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Status")]
        [Range(1,5 , ErrorMessage = "Código Status no encontrado")]
        public int CodigoStatus;

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Fecha de adquisicion")]
        [DataType(DataType.DateTime)]
        public DateTime FechaAdquisicion;

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Fecha ultimo movimiento")]
        [DataType(DataType.DateTime)]
        public DateTime FechaUltimoMovimiento;
        
        [Display(Name = "Otros detalles")]
        [StringLength(500, ErrorMessage = "Excediste el tamaño definido del campo")]
        public string OtrosDetalles;

        [Display(Name = "Costo de adquisicion")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public double CostoAdquisicion;
    }

    public class ModelosMetadata
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Fabricante")]
        [MinLength(5, ErrorMessage = "El número de caracteres es muy corto")]
        [MaxLength(45, ErrorMessage = "Excediste el tamaño definido del campo")] 
        public string Fabricante;

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Modelo")]
        [MinLength(5, ErrorMessage = "El número de caracteres es muy corto")]
        [MaxLength(45, ErrorMessage = "Excediste el tamaño definido del campo")] 
        public string Modelo;
        
        [StringLength(500, ErrorMessage = "Excediste el tamaño definido del campo")]
        [Display(Name = "Especificaciones")]
        public string Especificaciones;
    }

    public class TipoArticulosMetadata
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Tipo de artículo")]
        [MinLength(3, ErrorMessage = "El número de caracteres es muy corto")]
        [MaxLength(30, ErrorMessage = "Excediste el tamaño definido del campo")] 
        public string Descripcion;
    }

    public class LocalizacionesMetadata
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Dirección")]
        [MinLength(5, ErrorMessage = "El número de caracteres es muy corto")]
        [MaxLength(45, ErrorMessage = "Excediste el tamaño definido del campo")] 
        public string Direccion;

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Descripción")]
        [MinLength(5, ErrorMessage = "El número de caracteres es muy corto")]
        [MaxLength(45, ErrorMessage = "Excediste el tamaño definido del campo")] 
        public string Descripcion;

        [Display(Name = "Detalles")]
        [StringLength(45, ErrorMessage = "Excediste el tamaño definido del campo")]
        public string Detalles;
    }

    public class ContratosMetadata
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Fecha de contrato")]
        [DataType(DataType.DateTime, ErrorMessage = "Fecha no válida")]
        [DisplayFormat(ApplyFormatInEditMode = true,
                            HtmlEncode = false,
                            NullDisplayText = "",
                            DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FechaContrato;

        [Display(Name = "Detalles")]
        [StringLength(500, ErrorMessage = "Excediste el tamaño definido del campo")]
        public string Detalles;
    }

    public class TipoContratoMetadata
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Descripción")]
        [StringLength(50, ErrorMessage = "Excediste el tamaño definido del campo")]
        public string Descripcion;
    }

    public class TipoCompaniaMetadata
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Descripción")]
        [MinLength(3, ErrorMessage = "El número de caracteres es muy corto")]
        [MaxLength(50, ErrorMessage = "Excediste el tamaño definido del campo")] 
        public string Descripcion;
    }

    public class TercerasPersonasMetadata
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nombre")]
        [MinLength(5, ErrorMessage = "El número de caracteres es muy corto")]
        [MaxLength(50, ErrorMessage = "Excediste el tamaño definido del campo")] 
        public string Nombre;

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Dirección")]
        [MinLength(5, ErrorMessage = "El número de caracteres es muy corto")]
        [MaxLength(100, ErrorMessage = "Excediste el tamaño definido del campo")] 
        public string Direccion;

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "RFC")]
        [StringLength(15, ErrorMessage = "Excediste el tamaño definido del campo")]
        public string Rfc;

        [Display(Name = "Detalles")]
        [MaxLength(500, ErrorMessage = "Excediste el tamaño definido del campo")] 
        public string Detalles;
    }    

    public class KnowledgeItemMetadata
    {
        [AllowHtml]
        public string Descripcion {get; set;}
    }
    
}