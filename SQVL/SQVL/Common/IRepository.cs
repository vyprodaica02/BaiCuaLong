using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQVL.Common
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> DbSet();
        IQueryable<T> Table { get; }
        IQueryable<T> TableUntracked { get; }
        ICollection<T> Local { get; }
        T Attach(T entity);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetByIds(ICollection<int> ids);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        bool? AutoCommitEnabled { get; set; }
        void Commit();
        public Task CommitAsync();
    }
}
