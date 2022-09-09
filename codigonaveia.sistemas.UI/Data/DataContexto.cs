using System.Data;
using System.Data.SqlClient;

namespace codigonaveia.sistemas.UI.Data
{
    public class DataContexto
    {

        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader Dr;

        public SqlConnection AbrirConexao()
        {
            string strConexao = string.Format(@"Data Source=localhost,1401;Initial Catalog=DbCursos;User ID=sa;Password=@Lab2022");
            con = new SqlConnection(strConexao);
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }



        public SqlConnection FecharConexao()
        {
             
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
            }

            return con;
        }
    }
}
