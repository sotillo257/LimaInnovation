using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LimaInnovation.Models
{
    public class cProducto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string Categoria { get; set; }
        public string Imagen { get; set; }
    }
}