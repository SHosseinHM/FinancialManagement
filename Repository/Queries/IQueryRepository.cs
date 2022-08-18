using Infrastructure.Entities;

namespace Repository.Queries
{
    public interface IQueryRepository
    {
        /// <summary>
        /// Query for Get many Data as One Object and Returns IEnumrable<Object>
        /// </summary>
        public Task<IEnumerable<TType>> QueryMany<TType>(string sql, object value) where TType : class;
        /// <summary>
        /// Query , if Exist that Request , Returns True
        /// </summary>
        public Task<bool> QueryExist<TType>(string sql, object value) where TType : class;
        /// <summary>
        /// Query , if Request Exist , Return an Single Object
        /// </summary>
        public Task<TType> QuerySingle<TType>(string sql, object value) where TType : class;

    }
}


// This is Generic Interface for Quering to Database with Dapper
//First Argument is Query and Second is the Data