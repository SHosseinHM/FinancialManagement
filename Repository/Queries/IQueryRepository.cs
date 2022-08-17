using Infrastructure.Entities;

namespace Repository.Queries
{
    public interface IQueryRepository
    {
        public Task<IEnumerable<TType>> QueryMany<TType>(string sql, object value)  where TType : class;
        public Task<bool> QueryExist<TType>(string sql, object value) where TType : class;
        public Task<TType> QuerySingle<TType>(string sql , object value) where TType : class;

    }
}


// This is Generic Interface for Quering to Database with Dapper
//First Argument is Query and Second is the Data