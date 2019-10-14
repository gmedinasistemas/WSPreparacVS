using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WSDistPinky
/// </summary>
[WebService(Namespace = "http://repuestospinky.com.ar/webs/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WSDistPinky : System.Web.Services.WebService
{

    public WSDistPinky()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionvsp"].ConnectionString);
    [WebMethod]
    public DataSet ListArticulosPinky()//genero el metodo para mostrar todos los pedidos
    {
        SqlDataAdapter da = new SqlDataAdapter("SELECT ARTERC,ARCUAR,ARDESC,ARMODE,ARMARC,AROO,ARTT,ARUBIC1,AROBSE,ARRUB2,ARFLIA,ARPROV,ARPP" +
                                               " FROM VW_TRAER_ARTICULOS WITH(NOLOCK)", cnn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    [WebMethod]
    public DataSet ListFamiliasPinky()//genero el metodo para mostrar todos los pedidos
    {
        SqlDataAdapter da = new SqlDataAdapter("SELECT FACODI,FADESC,FARAZO,FAPROV FROM VW_TRAER_FAMILIAS with(nolock)", cnn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    [WebMethod]
    public DataSet ListProveedoresPinky()//genero el metodo para mostrar todos los pedidos
    {
        SqlDataAdapter da = new SqlDataAdapter("SELECT PRCODI,PRRAZO,PRCRUB,PRDES3 FROM VW_TRAER_PROVEEDORES with(nolock)", cnn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    [WebMethod]
    public DataSet ListRubrosPinky()//genero el metodo para mostrar todos los pedidos
    {
        SqlDataAdapter da = new SqlDataAdapter("SELECT RBCODI,RBDESC FROM VW_TRAER_RUBROS with(nolock)", cnn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
}
