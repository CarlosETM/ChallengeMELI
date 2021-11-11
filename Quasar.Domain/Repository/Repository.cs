using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Quasar.Domain.Aggregation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Quasar.Domain.Repository
{
    public class Repository<TContext> : IRepository where TContext : DbContext
    {
        protected TContext dbContext;

        private readonly string connectionString;

        public readonly IUnitOfWork unitOfWork;

        public Repository(TContext context)
        {
            this.dbContext = context;
            this.unitOfWork = new UnitOfWork(context);
            this.connectionString = @"Data Source=LAPTOP-IANS0V88\SQLEXPRESS; Initial Catalog=ChallengeMELI ;Integrated Security=True";
        }

        public async virtual Task<List<T>> GetTable<T>() where T : class
        {
            return await this.dbContext.Set<T>().ToListAsync();
        }

        public async virtual Task<List<T>> Filter<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await this.dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async virtual Task<List<T>> Filter<T>(Expression<Func<T, bool>> predicate, string navigations = "") where T : class
        {
            if (!string.IsNullOrEmpty(navigations))
            {
                return await this.dbContext.Set<T>().Where(predicate).Include(navigations).ToListAsync();
            }
            else
            {
                return await this.dbContext.Set<T>().Where(predicate).ToListAsync();
            }
        }

        public async virtual Task<List<T>> Filter<T>(Expression<Func<T, bool>> predicate, string[] navigations) where T : class
        {
            IQueryable<T> query = null;
            if (navigations.Length > 0)
            {

                query = this.dbContext.Set<T>().Where(predicate);
                for (int i = 0; i < navigations.Length; i++)
                {
                    query = query.Include(navigations[i]);


                }

                return await query.ToListAsync();
            }
            else
            {
                return await this.dbContext.Set<T>().Where(predicate).ToListAsync();
            }
        }

        public async virtual Task<T> GetByID<T>(params object[] id) where T : class
        {
            return await this.dbContext.Set<T>().FindAsync(id);
        }

        public async virtual Task Delete<T>(T entity) where T : class
        {
            try
            {
                var dbSet = this.dbContext.Set<T>();
                if (this.dbContext.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
                await this.unitOfWork.Commit();
            }
            catch
            {
                this.unitOfWork.Dispose();
            }
        }

        public async virtual Task<T> Create<T>(T entity) where T : class
        {
            var result = entity;
            try
            {
                var eEntry = await this.dbContext.Set<T>().AddAsync(entity);
                result = eEntry.Entity;
                await this.unitOfWork.Commit();
            }
            catch (Exception e)
            {
                this.unitOfWork.Dispose();
            }
            return result;
        }

        public async virtual Task<bool> Update<T>(T entity) where T : class
        {
            var response = false;

            try
            {
                var dbSet = this.dbContext.Set<T>();
                if (this.dbContext.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                this.dbContext.Entry(entity).State = EntityState.Modified;
                return response = await this.unitOfWork.Commit() > 0;
            }
            catch (Exception ex)
            {
                this.unitOfWork.Dispose();
            }

            return response;
        }

        public async virtual Task<T> Update<T>(T oldEntity, T newEntity) where T : class
        {
            try
            {
                this.dbContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
                await this.unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                this.unitOfWork.Dispose();
            }
            return newEntity;
        }

        public Task<List<T>> FromSql<T>(string sql, params object[] parameters) where T : class
        {
            throw new NotImplementedException();
        }
    }


}
