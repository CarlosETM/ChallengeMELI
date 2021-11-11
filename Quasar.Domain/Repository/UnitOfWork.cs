using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quasar.Domain.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            this._context = context;
        }

        public async Task<int> Commit()
        {
            return await this._context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (this._context != null)
            {
                this._context.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }


}
