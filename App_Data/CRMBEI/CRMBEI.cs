using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMBEI
{
    public class CRMBEI
    {
        public enum TipoArchivo
        {
            Todos = 1,
            Imagen = 2,
            Fotografia = 6
        }

        public enum TipoRelacionArchivo
        {
            ClienteLogo = 1,
            ClienteDocumento = 2,
            Convenios = 3,
            Servicios = 4,
            ServiviosDocumentosAdjunto = 5,
            ServicionCotizacion = 6,
            Curriculums = 8,
            Tallas = 9,
            Persona = 10
        }

        
    }
}