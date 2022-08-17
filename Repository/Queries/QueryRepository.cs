using System.Data.SqlClient;
using Dapper;
using Repository.Connections;

namespace Repository.Queries
{
    public class QueryRepository : IQueryRepository
    {
        public async Task<IEnumerable<TType>> QueryMany<TType>(string sql, object value) where TType : class
        {
            var connection = new SqlConnection(ConnectionStrings.FinancialManagmentConnection());
            return await connection.QueryAsync<TType>(sql, value);
        }

        public async Task<bool> QueryExist<TType>(string sql, object value) where TType : class
        {
            var connection = new SqlConnection(ConnectionStrings.FinancialManagmentConnection());
            var result = await connection.QueryFirstOrDefaultAsync<TType>(sql, value);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<TType> QuerySingle<TType>(string sql, object value) where TType : class
        {
            var connection = new SqlConnection(ConnectionStrings.FinancialManagmentConnection());
            return await connection.QuerySingleOrDefaultAsync<TType>(sql, value);
        }
    }
}

// This is Generic Class for Quering to Database with Dapper
//First Argument is Query and Second is the Data
//that impeliment Interface