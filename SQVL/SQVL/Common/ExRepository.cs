using Microsoft.EntityFrameworkCore;
using SQVL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQVL.Common
{
    public class ExRepository<T> : IRepository<T> where T : class
    {
        private DbSet<T> _entities;
        private readonly QlsvContext _context;

        public ExRepository()
        {
            _context = new QlsvContext();
        }

        public IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        public IQueryable<T> TableUntracked
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }

        public ICollection<T> Local
        {
            get
            {
                return this.Entities.Local;
            }
        }


        public async Task AddAsync(T entity)
        {
            await this.Entities.AddAsync(entity);

            if (this.AutoCommitEnabledInternal)
            {
                await _context.SaveChangesAsync();
            }
            this.Entities.Attach(entity).State = EntityState.Detached;
        }

        public T Attach(T entity)
        {
            return Entities.Attach(entity).Entity;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }

                return _entities as DbSet<T>;
            }
        }

        public DbSet<T> DbSet()
        {
            return Entities;
        }


        public T GetById(int id)
        {
            return this.Entities.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.Entities.FindAsync(id);
        }

        private int GetIdFromEntity(T entity)
        {
           
            throw new NotImplementedException("You need to implement GetIdFromEntity method.");
        }
        public IQueryable<T> GetByIds(ICollection<int> ids)
        {
            return Entities.Where(x => ids.Contains(GetIdFromEntity(x)));
        }

        public async Task UpdateAsync(T entity)
        {
            ChangeStateToModifiedIfApplicable(entity);

            if (this.AutoCommitEnabledInternal)
            {
                await _context.SaveChangesAsync();
            }
        }

        private void ChangeStateToModifiedIfApplicable(T entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {

                entry.State = EntityState.Modified;
            }
        }

        public bool? AutoCommitEnabled { get; set; }

        private bool AutoCommitEnabledInternal
        {
            get
            {
                return this.AutoCommitEnabled ?? true;
            }
        }
    }
}
