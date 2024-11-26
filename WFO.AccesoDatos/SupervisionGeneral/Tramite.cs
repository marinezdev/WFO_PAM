﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO.Propiedades.Procesos.SupervisionGeneral;
using f = WFO.Funciones;

namespace WFO.AccesoDatos.SupervisionGeneral
{
    public class Tramite
    {
        ManejoDatos b = new ManejoDatos();

        public List<prop.Tramite> Seleccionar(int IdUsuario)
        {
            b.ExecuteCommandSP("Tramite_Seleccionar");
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            List<prop.Tramite> resultado = new List<prop.Tramite>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Tramite item = new prop.Tramite()
                {
                    Id              = int.Parse(reader["Id"].ToString()),
                    Folio           = reader["Folio"].ToString(),
                    IdTipoTramite   = int.Parse(reader["IdTipoTramite"].ToString()),
                    TipoTramite     = reader["TipoTramite"].ToString(),
                    FechaRegistro   = DateTime.Parse(reader["FechaRegistro"].ToString()),
                    FechaTermino    = DateTime.Parse(reader["FechaTermino"].ToString()),
                    FechaSolicitud  = DateTime.Parse(reader["FechaSolicitud"].ToString()),
                    IdPromotoria    = int.Parse(reader["IdPromotoria"].ToString()),
                    Promotoria      = reader["Promotoria"].ToString(),
                    ClavePromotoria = reader["ClavePromotoria"].ToString(),
                    IdStatus        = int.Parse(reader["IdStatus"].ToString()),
                    Status          = reader["Status"].ToString(),
                    IdUsuario       = int.Parse(reader["IdUsuario"].ToString()),
                    NumeroOrden     = reader["NumeroOrden"].ToString(),
                    IdPrioridad     = int.Parse(reader["IdPrioridad"].ToString()),
                    Prioridad       = reader["Prioridad"].ToString(),
                    IdSisLegados    = reader["IdSisLegados"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public prop.Tramite SeleccionarPorId(string id)
        {
            b.ExecuteCommandSP("Tramite_Seleccionar_PorId ");
            b.AddParameter("@id", id, SqlDbType.Int);
            prop.Tramite resultado = new prop.Tramite();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["Id"].ToString());
                resultado.Folio = reader["Folio"].ToString();
                resultado.IdTipoTramite = int.Parse(reader["IdTipoTramite"].ToString());
                resultado.TipoTramite = reader["TipoTramite"].ToString();
                resultado.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                resultado.FechaTermino = DateTime.Parse(reader["FechaTermino"].ToString());
                resultado.FechaSolicitud = DateTime.Parse(reader["FechaSolicitud"].ToString());
                resultado.IdPromotoria = int.Parse(reader["IdPromotoria"].ToString());
                resultado.Promotoria = reader["Promotoria"].ToString();
                resultado.ClavePromotoria = reader["ClavePromotoria"].ToString();
                resultado.IdStatus = int.Parse(reader["IdStatus"].ToString());
                resultado.Status = reader["Status"].ToString();
                resultado.IdUsuario = int.Parse(reader["IdUsuario"].ToString());
                resultado.NumeroOrden = reader["NumeroOrden"].ToString();
                resultado.IdPrioridad = int.Parse(reader["IdPrioridad"].ToString());
                resultado.Prioridad = reader["Prioridad"].ToString();
                resultado.IdSisLegados = reader["IdSisLegados"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.Tramite> Buscar(string foliocompuesto, string fecharegistrodel, string fecharegistroal, string fechasolicituddel, string fechasolicitudal, string idpromotoria, string estado, int IdUsuario)
        {
            string folio = "%" + foliocompuesto + "%";
            b.ExecuteCommandSP("Tramite_Seleccionar_Buscar");
            b.AddParameter("@foliocompuesto", folio == "%%" ? DBNull.Value : (Object)folio, SqlDbType.VarChar, 20);
            b.AddParameter("@fecharegistrodel",  fecharegistrodel == "" ? "" : Funciones.Fechas.PrepararFechaParaBusqueda(fecharegistrodel), SqlDbType.VarChar);
            b.AddParameter("@fecharegistroal", fecharegistroal == "" ? "" : Funciones.Fechas.PrepararFechaParaBusqueda(fecharegistroal), SqlDbType.VarChar);
            b.AddParameter("@fechasolicituddel", fechasolicituddel == "" ? "" : Funciones.Fechas.PrepararFechaParaBusqueda(fechasolicituddel), SqlDbType.VarChar);
            b.AddParameter("@fechasolicitudal", fechasolicitudal == "" ? "" : Funciones.Fechas.PrepararFechaParaBusqueda(fechasolicitudal), SqlDbType.VarChar);
            b.AddParameter("@idpromotoria", idpromotoria == "0" ? DBNull.Value : (Object)idpromotoria, SqlDbType.Int);
            b.AddParameter("@estado", estado == "0" ? DBNull.Value : (Object)estado, SqlDbType.Int);
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);

            List <prop.Tramite> resultado = new List<prop.Tramite>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Tramite item = new prop.Tramite()
                {
                    Id              = int.Parse(reader["Id"].ToString()),
                    Folio           = reader["Folio"].ToString(),
                    IdTipoTramite   = int.Parse(reader["IdTipoTramite"].ToString()),
                    TipoTramite     = reader["TipoTramite"].ToString(),
                    FechaRegistro   = DateTime.Parse(reader["FechaRegistro"].ToString()),
                    FechaTermino    = DateTime.Parse(reader["FechaTermino"].ToString()),
                    FechaSolicitud  = DateTime.Parse(reader["FechaSolicitud"].ToString()),
                    IdPromotoria    = int.Parse(reader["IdPromotoria"].ToString()),
                    Promotoria      = reader["Promotoria"].ToString(),
                    ClavePromotoria = reader["ClavePromotoria"].ToString(),
                    IdStatus        = int.Parse(reader["IdStatus"].ToString()),
                    Status          = reader["Status"].ToString(),
                    IdUsuario       = int.Parse(reader["IdUsuario"].ToString()),
                    NumeroOrden     = reader["NumeroOrden"].ToString(),
                    IdPrioridad     = int.Parse(reader["IdPrioridad"].ToString()),
                    Prioridad       = reader["Prioridad"].ToString(),
                    IdSisLegados    = reader["IdSisLegados"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public DataTable SeleccionarTramitesPorMesa(int IdTipoTramite)
        {
            b.ExecuteCommandSP("Tramite_EstadosMesa");
            b.AddParameter("@IdTipoTramite", IdTipoTramite, SqlDbType.Int);
            return b.Select();
        }

        public DataTable ListadoTramitesOperacion()
        {
            b.ExecuteCommandSP("spListadoTramitesOperacionN1");
            return b.Select();
        }

        public DataTable ListadoTramitesOperacionN3()
        {
            b.ExecuteCommandSP("spListadoTramitesOperacionN3");
            return b.Select();
        }

        public DataTable SeleccionarTramiteConsultaX()
        {
            b.ExecuteCommandSP("Tramites_Seleccionar_ConsultaX");
            b.AddParameter("@Id", 4, SqlDbType.Int);
            return b.Select();
        }

        public int ModificarPrioridad(string id)
        {
            b.ExecuteCommandSP("Tramite_Modificar_Prioridad");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }


        public List<prop.Tramite> TramiteSupervicionGeneralSelecionarFechas(int Id, DateTime Fecha_Inicio, DateTime Fecha_Termino, string Folio, string RFC, string Nombre, string ApPaterno, string ApMaterno)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("exec Tramite_SupervicionGeneral_Selecionar_PorIdUsuario_Fechas ");
            System.Diagnostics.Debug.WriteLine("@IdUsuario = " + Id.ToString() + "'");
            System.Diagnostics.Debug.WriteLine(", @Fecha_Inicio = '" + Fecha_Inicio.ToString("yyyy/MM/dd") + "'");
            System.Diagnostics.Debug.WriteLine(", @Fecha_Termino = '" + Fecha_Termino.ToString("yyyy/MM/dd") + "'");
            System.Diagnostics.Debug.WriteLine(", @Folio = '" + Folio + "'");
            System.Diagnostics.Debug.WriteLine(", @RFC = '" + RFC + "'");
            System.Diagnostics.Debug.WriteLine(", @Nombre = '" + Nombre + "'");
            System.Diagnostics.Debug.WriteLine(", @ApPaterno = '" + ApPaterno + "'");
            System.Diagnostics.Debug.WriteLine(", @ApMaterno = '" + ApMaterno + "'");
#endif

            b.ExecuteCommandSP("Tramite_SupervicionGeneral_Selecionar_PorIdUsuario_Fechas");
            b.AddParameter("@IdUsuario", Id, SqlDbType.Int);
            b.AddParameter("@Fecha_Inicio", Fecha_Inicio, SqlDbType.DateTime);
            b.AddParameter("@Fecha_Termino", Fecha_Termino, SqlDbType.DateTime);
            b.AddParameter("@Folio", Folio, SqlDbType.NVarChar);
            b.AddParameter("@RFC", RFC, SqlDbType.NVarChar);
            b.AddParameter("@Nombre", Nombre, SqlDbType.NVarChar);
            b.AddParameter("@ApPaterno", ApPaterno, SqlDbType.NVarChar);
            b.AddParameter("@ApMaterno", ApMaterno, SqlDbType.NVarChar);
            List<prop.Tramite> resultado = new List<prop.Tramite>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Tramite item = new prop.Tramite()
                {
                    Id = Funciones.Numeros.ConvertirTextoANumeroEntero(reader["Id"].ToString()),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                    Folio = reader["FolioCompuesto"].ToString(),
                    NumeroOrden = reader["NumeroOrden"].ToString(),
                    Operacion = reader["Operacion"].ToString(),
                    Contratante = reader["Contratante"].ToString(),
                    FechaSolicitud = Convert.ToDateTime(reader["FechaSolicitud"].ToString()),
                    Estatus = reader["Estatus"].ToString(),
                    IdSisLegados = reader["IdSisLegados"].ToString(),
                    kwik = reader["kwik"].ToString(),
                    Promotoria = reader["Promotoria"].ToString(),
                    PromotoriaZona = reader["PromotoriaZona"].ToString(),
                    TipoServicio = reader["TipoServicio"].ToString(),
                    PrimaTotal = reader["PrimaTotal"].ToString(),
                    PrimaExcedente = reader["PrimaExcedente"].ToString(),
                    PrimaDiferencia = reader["PrimaDiferencia"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.Tramite> TramiteSupervicionGeneralSelecionar(int Id, string Folio, string RFC, string Nombre, string ApPaterno, string ApMaterno)
        {
            b.ExecuteCommandSP("Tramite_SupervicionGeneral_Selecionar_PorIdUsuario");
            b.AddParameter("@IdUsuario", Id, SqlDbType.Int);
            b.AddParameter("@Folio", Folio, SqlDbType.NVarChar);
            b.AddParameter("@RFC", RFC, SqlDbType.NVarChar);
            b.AddParameter("@Nombre", Nombre, SqlDbType.NVarChar);
            b.AddParameter("@ApPaterno", ApPaterno, SqlDbType.NVarChar);
            b.AddParameter("@ApMaterno", ApMaterno, SqlDbType.NVarChar);
            List<prop.Tramite> resultado = new List<prop.Tramite>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Tramite item = new prop.Tramite()
                {
                    Id = Funciones.Numeros.ConvertirTextoANumeroEntero(reader["Id"].ToString()),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                    Folio = reader["FolioCompuesto"].ToString(),
                    NumeroOrden = reader["NumeroOrden"].ToString(),
                    Operacion = reader["Operacion"].ToString(),
                    Contratante = reader["Contratante"].ToString(),
                    FechaSolicitud = Convert.ToDateTime(reader["FechaSolicitud"].ToString()),
                    Estatus = reader["Estatus"].ToString(),
                    IdSisLegados = reader["IdSisLegados"].ToString(),
                    kwik = reader["kwik"].ToString(),
                    Promotoria = reader["Promotoria"].ToString(),
                    PromotoriaZona = reader["PromotoriaZona"].ToString(),
                    TipoServicio = reader["TipoServicio"].ToString(),
                    PrimaTotal = reader["PrimaTotal"].ToString(),
                    PrimaExcedente = reader["PrimaExcedente"].ToString(),
                    PrimaDiferencia = reader["PrimaDiferencia"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.TramitesIncompletos> TramitesIncompletos()
        {
            b.ExecuteCommandSP("Tramites_Seleccionar_ConsultaX_Incompletos");
            //b.AddParameter("@Fecha_Inicio", Fecha_Inicio, SqlDbType.DateTime);

            List<prop.TramitesIncompletos> resultado = new List<prop.TramitesIncompletos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramitesIncompletos item = new prop.TramitesIncompletos()
                {
                    Id = Convert.ToInt32(reader["Tramite"].ToString()),
                    Folio = reader["Número de Folio"].ToString(),
                    NumeroPoliza = reader["Número de póliza"].ToString(),
                    RFC = reader["RFC"].ToString(),
                    Contratante =  reader["Contratante"].ToString(),
                    Titular = reader["Titular"].ToString(),
                    Mesa = reader["Mesa"].ToString(),
                    EstatusMesa =  reader["Estatus mesa"].ToString(),
                    EstatusTramite = reader["Estatus trámite"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.TramiteMesa> tramiteMesas(int IdTramite)
        {
            b.ExecuteCommandSP("TramiteMesa_Seleccionar_Observaciones");
            b.AddParameter("@IdTramite", IdTramite, SqlDbType.Int);

            List<prop.TramiteMesa> resultado = new List<prop.TramiteMesa>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramiteMesa item = new prop.TramiteMesa()
                {
                    FolioCompuesto = reader["FolioCompuesto"].ToString(),
                    Mesa = reader["Mesa"].ToString(),
                    Stsatus = reader["status"].ToString(),
                    Nombre = reader["Nombre"].ToString(),
                    FechaInicio = reader["FechaInicio"].ToString(),
                    FechaFin = reader["FechaFin"].ToString(),
                    ObservacionPublica = reader["ObservacionPublica"].ToString(),
                    ObservacionPrivada = reader["ObservacionPrivada"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public int EnviarTramiteMesaAdmisionNumeroPoliza(int IdTramite, string NumeroPoliza)
        {
            b.ExecuteCommandSP("TramiteMesa_RegresarAdmision_ConNumPoliza");
            b.AddParameter("@IdTramite", IdTramite, SqlDbType.Int);
            b.AddParameter("@NumeroPoliza", NumeroPoliza, SqlDbType.NVarChar);
            return b.InsertUpdateDelete();
        }

        public List<prop.TramiteDetalle> Tramite_EstadosMesa_Detalle(int IdMesa, int IdEstatus)
        {
            b.ExecuteCommandSP("Tramite_EstadosMesa_Detalle");
            b.AddParameter("@IdMesa", IdMesa, SqlDbType.Int);
            b.AddParameter("@IdEstatus", IdEstatus, SqlDbType.Int);
            List<prop.TramiteDetalle> resultado = new List<prop.TramiteDetalle>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramiteDetalle item = new prop.TramiteDetalle()
                {
                    FechaRegistro = reader["FechaRegistro"].ToString(),
                    Folio = reader["FolioCompuesto"].ToString(),
                    NumeroOrden = reader["NumeroOrden"].ToString(),
                    Operacion = reader["Operacion"].ToString(),
                    Producto = reader["Producto"].ToString(),
                    Contratante = reader["Contratante"].ToString(),
                    //RFC = reader["RFC"].ToString(),
                    //Titular = reader["Titular"].ToString(),
                    FechaSolicitud = reader["FechaSolicitud"].ToString(),
                    IdSisLegados = reader["IdSisLegados"].ToString(),
                    //Kwik = reader["kwik"].ToString(),
                    //Institucion = reader["Institucion"].ToString(),

                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}