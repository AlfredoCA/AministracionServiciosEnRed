using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventarios.Models
{
    [MetadataType(typeof(PersonalsMetadata))]
    public partial class Personals
    {
    }

    [MetadataType(typeof(DepartamentosMetadata))]
    public partial class Departamentos
    {
    }

    [MetadataType(typeof(ArticulosMetadata))]
    public partial class Articulos
    {
        public double CostoActual
        {
            get
            {
                //
                // TODO: Calcular costo real a partir del de adquisicion
                //
                return CostoAdquisicion;
            }
        }

        public string VistaArticulo
        {
            get
            {
                return IdArticulo.ToString() + " - " + Modelos.Fabricante + " " +  Modelos.Modelo;
            }
        }
    }

    [MetadataType(typeof(ModelosMetadata))]
    public partial class Modelos
    {
        public string VistaModelo
        {
            get
            {
                return Fabricante + " - " + Modelo;
            }
        }
    }

    [MetadataType(typeof(TipoArticulosMetadata))]
    public partial class TipoArticulos
    {
        
    }

    [MetadataType(typeof(LocalizacionesMetadata))]
    public partial class Localizaciones
    {

    }

    [MetadataType(typeof(ContratosMetadata))]
    public partial class Contratos
    {

    }

    [MetadataType(typeof(TipoContratoMetadata))]
    public partial class TipoContrato
    {

    }

    [MetadataType(typeof(TipoCompaniaMetadata))]
    public partial class TipoCompania
    {

    }

    [MetadataType(typeof(TercerasPersonasMetadata))]
    public partial class TercerasPersonas
    {

    }

    [MetadataType(typeof(KnowledgeItemMetadata))]
    public partial class KnowledgeItem
    {
        public string KnowledgeItemFK
        {
            get
            {
                return this.Id + " - " + this.Titulo;
            }
        }
    }

}