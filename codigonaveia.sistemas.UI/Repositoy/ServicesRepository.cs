using codigonaveia.sistemas.UI.Data;
using codigonaveia.sistemas.UI.Models;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Reflection;

namespace codigonaveia.sistemas.UI.Repositoy
{
    public class ServicesRepository:DataContexto
    {
        public IEnumerable<Estados> ObterEstados()
        {
			try
			{
				AbrirConexao();
				string strSelect = string.Format(@"SELECT Id, EstadoNome FROM Estados");
				List<Estados> lista = new List<Estados>();
				using (cmd = new SqlCommand(strSelect, con))
				{
					using(Dr = cmd.ExecuteReader())
					{
						Estados mod = null;
						while (Dr.Read())
						{
							mod = new Estados();
							mod.Id = Convert.ToInt32(Dr[0]);
							mod.EstadoNome = Convert.ToString(Dr[1]);
							lista.Add(mod);
						}
						return lista;
					}
				}

			}
			catch (Exception ex)
			{

				throw  new Exception(ex.Message);
			}
			finally
			{
				FecharConexao();
			}
        }

        public IEnumerable<Cidades> ObterCidadesPorId(int Id)
        {
            try
            {
                AbrirConexao();
                string strSelect = string.Format(@"SELECT Id, CidadeNome FROM Cidades WHERE EstadoId = @Id");
                List<Cidades> lista = new List<Cidades>();
                using (cmd = new SqlCommand(strSelect, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    using (Dr = cmd.ExecuteReader())
                    {
                        Cidades mod = null;
                        while (Dr.Read())
                        {
                            mod = new Cidades();
                            mod.Id = Convert.ToInt32(Dr[0]);
                            mod.CidadeNome = Convert.ToString(Dr[1]);
                            lista.Add(mod);
                        }
                        return lista;
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
