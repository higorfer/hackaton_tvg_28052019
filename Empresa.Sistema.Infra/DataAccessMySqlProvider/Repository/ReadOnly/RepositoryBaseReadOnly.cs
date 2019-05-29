using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace Empresa.Sistema.Infra.DataAccessMySqlProvider.Repository.ReadOnly
{
    public class RepositoryBaseReadOnly
    {
        private IConfiguration _configuracoes;

        public RepositoryBaseReadOnly(IConfiguration config)
        {
            _configuracoes = config;
        }

        public IDbConnection Connection
        {
          get
            {
                return new MySqlConnection(_configuracoes.GetConnectionString("MySqlConnectionString"));
            }
        }
    }
}
