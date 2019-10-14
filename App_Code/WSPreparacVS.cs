using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WSPreparacVS
/// </summary>
/// [WebService(Namespace = "http://tempuri.org/")]
[WebService(Namespace = "http://repuestospinky.com.ar/webs/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WSPreparacVS : System.Web.Services.WebService
{

    public WSPreparacVS()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionvs"].ConnectionString);
    [WebMethod]
    public DataSet ListPreparacTodosAyro()//genero el metodo para mostrar todos los pedidos
    {
        SqlDataAdapter da = new SqlDataAdapter("SELECT SELECCIONAR,PPANUME,PPACLIE,PPAVEND,PREP_EST_DESCRIP,PPARAZO,PPACIVA,PPAFAPL,PPAHORA,PPACANT,PPADESC"+
            ", CAT_DESCRIP, PPAESTA, PPABARR, PPACOD1, PPACOD2, PPACOD3, PPACOD4, PPAFECH, PPATPRE, PPAPREC, PPASITI, PPAAUTN" +
            ", PPAQOT, PPAPPA, PPADESK, PPAORIG, PPACODI, PPATARJ, PPACUOT, PPAFLIA, PPAIMPO, PPAPROV, PPAAUTO, PPAARFF, PPAOBSE" +
            ", PPACOMP, PPAMARC, PPABULT, PPAKILO, PPASEGU, PPAREMF, PPAREMN, PPAPIEZ, PPAFIVA, PPAUSER, PPAPOR1, PPAPOR2, PPABASE" +
            ", PPACONT, PPAFORI, PPAUNID, PPADEPO, PPADIRE, PPACPAG " + 
        " FROM VW_TRAER_PEDIDOS_AYRO WITH(NOLOCK) " + 
        " ORDER BY PPAFECH,PPANUME", cnn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    [WebMethod]
    public DataSet ListPreparacPendientesAyro()
    {
        SqlDataAdapter da = new SqlDataAdapter("SELECT SELECCIONAR,PPANUME,PPACLIE,PPAVEND,PREP_EST_DESCRIP,PPARAZO,PPACIVA,PPAFAPL,PPAHORA,PPACANT,PPADESC" +
                                               ", CAT_DESCRIP, PPAESTA, PPABARR, PPACOD1, PPACOD2, PPACOD3, PPACOD4, PPAFECH, PPATPRE, PPAPREC, PPASITI, PPAAUTN" +
                                               ", PPAQOT, PPAPPA, PPADESK, PPAORIG, PPACODI, PPATARJ, PPACUOT, PPAFLIA, PPAIMPO, PPAPROV, PPAAUTO, PPAARFF, PPAOBSE" +
                                               ", PPACOMP, PPAMARC, PPABULT, PPAKILO, PPASEGU, PPAREMF, PPAREMN, PPAPIEZ, PPAFIVA, PPAUSER, PPAPOR1, PPAPOR2, PPABASE" +
                                               ", PPACONT, PPAFORI, PPAUNID, PPADEPO, PPADIRE, PPACPAG " +
        "  FROM VW_TRAER_PEDIDOS_AYRO_PENDIENTES WITH(NOLOCK) " +
        " ORDER BY PPAFECH, PPANUME", cnn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    [WebMethod]
    public DataSet ListPreparacPreparandoAyro()
    {
        SqlDataAdapter da = new SqlDataAdapter("SELECT SELECCIONAR,PPANUME,PPACLIE,PPAVEND,PREP_EST_DESCRIP,PPARAZO,PPACIVA,PPAFAPL,PPAHORA,PPACANT,PPADESC" +
                                               ", CAT_DESCRIP, PPAESTA, PPABARR, PPACOD1, PPACOD2, PPACOD3, PPACOD4, PPAFECH, PPATPRE, PPAPREC, PPASITI, PPAAUTN" +
                                               ", PPAQOT, PPAPPA, PPADESK, PPAORIG, PPACODI, PPATARJ, PPACUOT, PPAFLIA, PPAIMPO, PPAPROV, PPAAUTO, PPAARFF, PPAOBSE" +
                                               ", PPACOMP, PPAMARC, PPABULT, PPAKILO, PPASEGU, PPAREMF, PPAREMN, PPAPIEZ, PPAFIVA, PPAUSER, PPAPOR1, PPAPOR2, PPABASE" +
                                               ", PPACONT, PPAFORI, PPAUNID, PPADEPO, PPADIRE, PPACPAG " +
        "  FROM VW_TRAER_PEDIDOS_AYRO_PREPARANDO WITH(NOLOCK) " +
        " ORDER BY PPAFECH, PPANUME", cnn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    [WebMethod]
    public DataSet BuscarPreparacxFechasAyro(Double Catalogo, String FechaDesde, String FechaHasta)//genero el metodo para mostrar todos los pedidos
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            SqlConnection cnn_ = new SqlConnection(cnn.ConnectionString);
            cnn_.Open();
            string query = "[SP_TRAER_PEDIDOS_AYRO_X_FECHAS]";
            SqlCommand cm = new SqlCommand(query, cnn_);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.Add("@PPACATA", SqlDbType.Float).Value = Catalogo;//OK
            cm.Parameters.Add("@FECHAD", SqlDbType.VarChar, 10).Value = Convert.ToString(FechaDesde);//OK
            cm.Parameters.Add("@FECHAH", SqlDbType.VarChar, 10).Value = Convert.ToString(FechaHasta);//OK

            da.SelectCommand = cm;

            da.Fill(ds);
            cnn_.Close();
            return ds;
        }
        catch (Exception)
        {
            return ds;
        }
    }
    [WebMethod]
    public DataSet BuscarPreparacxFechasClienteAyro(Double Catalogo, Double Cliente, String FechaDesde, String FechaHasta )//genero el metodo para mostrar todos los pedidos
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            SqlConnection cnn_ = new SqlConnection(cnn.ConnectionString);
            cnn_.Open();
            string query = "[SP_TRAER_PEDIDOS_AYRO_X_FECHAS_CLIENTE]";
            SqlCommand cm = new SqlCommand(query, cnn_);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.Add("@PPACATA", SqlDbType.Float).Value = Catalogo;//OK
            cm.Parameters.Add("@PPACLIE", SqlDbType.Float).Value = Cliente;//OK
            cm.Parameters.Add("@FECHAD", SqlDbType.VarChar, 10).Value = Convert.ToString(FechaDesde);//OK
            cm.Parameters.Add("@FECHAH", SqlDbType.VarChar, 10).Value = Convert.ToString(FechaHasta);//OK

            da.SelectCommand = cm;

            da.Fill(ds);
            cnn_.Close();
            return ds;
        }
        catch (Exception)
        {
            return ds;
        }
    }
    [WebMethod]
    public Int32 InsertPreparacAyro(Double _PPANUME, Double _PPAESTA, Double _PPACLIE, Double _PPABARR, String _PPACOD1,
        String _PPACOD2, String _PPACOD3, String _PPACOD4, String _PPADESC, Double _PPACANT, DateTime _PPAFECH,
        String _PPATPRE, Double _PPAPREC, Double _PPACIVA, String _PPARAZO, Double _PPASITI, String _PPAQOT,
           Double _PPAPPA, Double _PPADESK, Double _PPAORIG, String _PPACODI, String _PPATARJ, Double _PPACUOT, Double _PPAVEND, Double _PPAFLIA, String _PPAIMPO,
           Double _PPAPROV, Int32 _PPAAUTO, String _PPAARFF, Double _PPAFIVA, String _PPAOBSE, Double _PPAUSER, String _PPACOMP, Double _PPABULT, Double _PPAKILO,
           Double _PPASEGU, Double _PPAREMF, Double _PPAREMN, Double _PPAPIEZ, String _PPAMARC, Double _PPAPOR1, Double _PPAPOR2, Double _PPABASE, Double _PPACONT, DateTime _PPAFAPL,
           DateTime _PPAFORI, Double _PPAUNID, Double _PPADEPO, Double _PPADIRE, Double _PPACPAG, String _PPAHORA, Decimal _PPACATA, Decimal _PPAESTADO)
    {
        Int32 Valor = 0;
        try
        {
            using (SqlConnection cnn_= new SqlConnection(cnn.ConnectionString))
            {
                using (SqlCommand cm= new SqlCommand("[SP_INSERT_PEDIDO_AYRO]", cnn_))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.Add("PPANUME", SqlDbType.Float).Value = _PPANUME; //OK
                    cm.Parameters.Add("PPAESTA", SqlDbType.Float).Value = _PPAESTA ;//OK
                    cm.Parameters.Add("PPACLIE", SqlDbType.Float).Value = _PPACLIE ;//OK
                    cm.Parameters.Add("PPABARR", SqlDbType.Float).Value = _PPABARR ;//OK
                    cm.Parameters.Add("PPACOD1", SqlDbType.VarChar, 3).Value = _PPACOD1 ;//OK
                    cm.Parameters.Add("PPACOD2", SqlDbType.VarChar, 4).Value = _PPACOD2 ;//OK
                    cm.Parameters.Add("PPACOD3", SqlDbType.VarChar, 3).Value = _PPACOD3 ;//OK
                    cm.Parameters.Add("PPACOD4", SqlDbType.VarChar, 4).Value = _PPACOD4 ;//OK
                    cm.Parameters.Add("PPADESC", SqlDbType.VarChar, 40).Value = _PPADESC ;//OK
                    cm.Parameters.Add("PPACANT", SqlDbType.Float).Value = _PPACANT ;//OK
                    cm.Parameters.Add("PPAFECH", SqlDbType.DateTime).Value = _PPAFECH.ToShortDateString();//OK
                    cm.Parameters.Add("PPATPRE", SqlDbType.VarChar, 1).Value = _PPATPRE ;//OK
                    cm.Parameters.Add("PPAPREC", SqlDbType.Float).Value = _PPAPREC ;//OK
                    cm.Parameters.Add("PPACIVA", SqlDbType.Float).Value = _PPACIVA ;//OK
                    cm.Parameters.Add("PPARAZO", SqlDbType.VarChar, 30).Value = _PPARAZO ;//OK
                    cm.Parameters.Add("PPASITI", SqlDbType.Float).Value = _PPASITI ;//OK
                    cm.Parameters.Add("PPAQOT", SqlDbType.VarChar, 1).Value = _PPAQOT ;//OK
                    cm.Parameters.Add("PPAPPA", SqlDbType.Float).Value = _PPAPPA ;//OK
                    cm.Parameters.Add("PPADESK", SqlDbType.Float).Value = _PPADESK ;//OK
                    cm.Parameters.Add("PPAORIG", SqlDbType.Float).Value = _PPAORIG ;//OK
                    cm.Parameters.Add("PPACODI", SqlDbType.VarChar, 25).Value = _PPACODI ;//OK
                    cm.Parameters.Add("PPATARJ", SqlDbType.VarChar, 25).Value = _PPATARJ ;//OK
                    cm.Parameters.Add("PPACUOT", SqlDbType.Float).Value = _PPACUOT ;//OK
                    cm.Parameters.Add("PPAVEND", SqlDbType.Float).Value = _PPAVEND ;//OK
                    cm.Parameters.Add("PPAFLIA", SqlDbType.Float).Value = _PPAFLIA ;//OK
                    cm.Parameters.Add("PPAIMPO", SqlDbType.VarChar, 1).Value = _PPAIMPO ;//OK
                    cm.Parameters.Add("PPAPROV", SqlDbType.Float).Value = _PPAPROV ;//OK
                    cm.Parameters.Add("PPAAUTO", SqlDbType.TinyInt).Value = _PPAAUTO ;//OK
                    cm.Parameters.Add("PPAARFF", SqlDbType.VarChar, 10).Value = _PPAARFF ;//OK
                    cm.Parameters.Add("PPAFIVA", SqlDbType.Float).Value = _PPAFIVA ;//OK
                    cm.Parameters.Add("PPAOBSE", SqlDbType.VarChar, 255).Value = _PPAOBSE ;//OK
                    cm.Parameters.Add("PPAUSER", SqlDbType.Float).Value = _PPAUSER ;//OK
                    cm.Parameters.Add("PPACOMP", SqlDbType.VarChar, 30).Value = _PPACOMP ;//OK
                    cm.Parameters.Add("PPABULT", SqlDbType.Float).Value = _PPABULT ;//OK
                    cm.Parameters.Add("PPAKILO", SqlDbType.Float).Value = _PPAKILO ;//OK
                    cm.Parameters.Add("PPASEGU", SqlDbType.Float).Value = _PPASEGU ;//OK
                    cm.Parameters.Add("PPAREMF", SqlDbType.Float).Value = _PPAREMF ;//OK
                    cm.Parameters.Add("PPAREMN", SqlDbType.Float).Value = _PPAREMN ;//OK
                    cm.Parameters.Add("PPAPIEZ", SqlDbType.Float).Value = _PPAPIEZ ;//OK
                    cm.Parameters.Add("PPAMARC", SqlDbType.VarChar, 15).Value = _PPAMARC ;//OK
                    cm.Parameters.Add("PPAPOR1", SqlDbType.Float).Value = _PPAPOR1 ;//OK
                    cm.Parameters.Add("PPAPOR2", SqlDbType.Float).Value = _PPAPOR2 ;//OK
                    cm.Parameters.Add("PPABASE", SqlDbType.Float).Value = _PPABASE ;//OK
                    cm.Parameters.Add("PPACONT", SqlDbType.Float).Value = _PPACONT ;//OK
                    cm.Parameters.Add("PPAFAPL", SqlDbType.DateTime).Value = _PPAFAPL.ToShortDateString() ;//OK
                    cm.Parameters.Add("PPAFORI", SqlDbType.DateTime).Value = _PPAFORI.ToShortDateString() ;//OK
                    cm.Parameters.Add("PPAUNID", SqlDbType.Float).Value = _PPAUNID ;//OK
                    cm.Parameters.Add("PPADEPO", SqlDbType.Float).Value = _PPADEPO ;//OK
                    cm.Parameters.Add("PPADIRE", SqlDbType.Float).Value = _PPADIRE ;//OK
                    cm.Parameters.Add("PPACPAG", SqlDbType.Float).Value = _PPACPAG ;//OK
                    // SE AGREGO EL 13/09/2019 : @PPAHORA,@PPACATA,@PPAESTADO)
                    cm.Parameters.Add("PPAHORA", SqlDbType.VarChar, 10).Value = _PPAHORA;//OK
                    cm.Parameters.Add("PPACATA", SqlDbType.Decimal).Value = _PPACATA;//OK
                    cm.Parameters.Add("PPAESTADO", SqlDbType.Decimal).Value = _PPAESTADO;//OK
                    if (cnn_.State != ConnectionState.Open) cnn_.Open();

                    Valor = cm.ExecuteNonQuery();
                }

            }
            return Valor;
        }
        catch (Exception)
        {
            return Valor;
        }
    }
    [WebMethod]
    public Int32 UpdateEstadoPreparacAyro(Double _PPACLIE, Double _PPANUME, String _PPACODI, Decimal _PPAESTADO)
    {
        Int32 Valor = 0;
        try
        {
            using (SqlConnection cnn_ = new SqlConnection(cnn.ConnectionString))
            {
                using (SqlCommand cm = new SqlCommand("[SP_UPDATE_ESTADO_PREPARAC_AYRO]", cnn_))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.Add("PPACLIE", SqlDbType.Float).Value = _PPACLIE;//OK
                    cm.Parameters.Add("PPANUME", SqlDbType.Float).Value = _PPANUME; //OK
                    cm.Parameters.Add("PPACODI", SqlDbType.VarChar, 25).Value = _PPACODI;//OK
                    cm.Parameters.Add("PPAESTADO", SqlDbType.Decimal).Value = _PPAESTADO;//OK
                    if (cnn_.State != ConnectionState.Open) cnn_.Open();
                    Valor = cm.ExecuteNonQuery();
                }
            }
            return Valor;
        }
        catch (Exception)
        {
            return Valor;
        }
    }
    [WebMethod]
    public Decimal TraerNPedidoAyro()
    {
        SqlDataReader dr;
        decimal valor = 0;
        try
        {
            using (SqlConnection cnn_ = new SqlConnection(cnn.ConnectionString))
            {
                using (SqlCommand cm = new SqlCommand("[SP_TRAER_NPEDIDO_AYRO]", cnn_))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    if (cnn_.State != ConnectionState.Open) cnn_.Open();

                    dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        valor = Convert.ToDecimal( dr[0].ToString());
                    }
                    else
                    {
                        valor = 0;
                    }
                    dr.Close();
                    if (valor!=0)
                    {
                        cm.CommandText = "[SP_UPDATE_NPEDIDO_AYRO]";
                        cm.ExecuteNonQuery();
                    }
                }

            }
            return valor;
        }
        catch (Exception)
        {
            return valor;
        }
    }


}
