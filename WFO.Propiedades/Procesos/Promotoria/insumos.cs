using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO.Propiedades.Procesos.Promotoria
{
    public class insumos
    {
        public int Id { get; set; }
        public int Id_Tramite { get; set; }
        public int Id_Archivo { get; set; }
        public string NmArchivo { get; set; }
        public string NmOriginal { get; set; }
        public int Activo { get; set; }
        public string Descripcion { get; set; }
        public string RutaTemporal { get; set; }
    }
}
