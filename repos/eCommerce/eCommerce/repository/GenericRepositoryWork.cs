using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eCommerce.Models;

namespace eCommerce.repository
{
    public class GenericRepositoryWork:IDisposable
    {
        private DBmodel db = new DBmodel();
        public IRepository<tbl_EntityType> GetRepositoryInstance<tbl_EntityType>()where tbl_EntityType : class
        {
            return new GenericRepository<tbl_EntityType>(db);
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
    }
}