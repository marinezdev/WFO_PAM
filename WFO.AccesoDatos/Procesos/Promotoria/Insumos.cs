using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO.AccesoDatos.Procesos.Promotoria
{
    public class Insumos
    {
        ManejoDatos b = new ManejoDatos();

        public int Agregar(int TipoTramite, int Id_Tramite, int Id_Archivo, string NmArchivo, string NmOriginal, int Activo, string Descripcion)
        {
            b.ExecuteCommandSP("Insumo_Agregar");
            b.AddParameter("@TipoTramite", TipoTramite, SqlDbType.Int);
            b.AddParameter("@Id_Tramite", Id_Tramite, SqlDbType.Int);
            b.AddParameter("@Id_Archivo", Id_Archivo, SqlDbType.Int);
            b.AddParameter("@NmArchivo", NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", NmOriginal, SqlDbType.NVarChar);
            b.AddParameter("@Activo", Activo, SqlDbType.Int);
            b.AddParameter("@Descripcion", Descripcion, SqlDbType.NVarChar);
            return b.InsertUpdateDeleteWithTransaction();
        }
    }
}
