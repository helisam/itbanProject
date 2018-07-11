using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IDataContext : IDisposable
    {
        IQueryable<TEntidade> Entity<TEntidade>() where TEntidade : class;
        IQueryable<TEntidade> Query<TEntidade>(Expression<Func<TEntidade, bool>> expressao) where TEntidade : class;
        void Add<TEntidade>(TEntidade entity) where TEntidade : class;
        void Delete<TEntidade>(TEntidade entity) where TEntidade : class;
        void Update<TEntidade>(TEntidade entity) where TEntidade : class;
        bool Any<TEntidade>(Expression<Func<TEntidade, bool>> expressao) where TEntidade : class;
        void Detach<TEntidade>(TEntidade entidade) where TEntidade : class;
        void CommitChanges();
        void AddWithSP<TEntidade>(TEntidade entity, string sp, SqlParameter[] param) where TEntidade : class;
    }
}