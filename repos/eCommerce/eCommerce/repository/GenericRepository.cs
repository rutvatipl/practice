using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace eCommerce.repository
{
    public class GenericRepository<tbl_Entity> : IRepository<tbl_Entity> where tbl_Entity : class
    {
        DbSet<tbl_Entity> _dbset;
        private DBmodel _dbentity;
        public GenericRepository(DBmodel dbentity)
        {
            _dbentity = dbentity;
            _dbset = _dbentity.Set<tbl_Entity>();
        }
        public void Add(tbl_Entity DB)
        {
            _dbset.Add(DB);
            _dbentity.SaveChanges();
        }

        public int GetAllRecodeCount()
        {
            return _dbset.Count();
        }

        public IQueryable<tbl_Entity> GetAllRecodsIQuryable()
        {
            return _dbset;
        }

        //public IEnumerable<tbl_Entity> GetDBmodels()
        //{
        //    throw new NotImplementedException();
        //}

        public tbl_Entity GetFirstOrDeafault(int recodeId)
        {
            return _dbset.Find(recodeId);
        }

        public tbl_Entity GetFirstOrDeafaultByParameter(Expression<Func<tbl_Entity, bool>> wherePredict)
        {
            return _dbset.Where(wherePredict).FirstOrDefault();
        }

        public IEnumerable<tbl_Entity> GetListParameter(Expression<Func<tbl_Entity, bool>> wherePredict)
        {
            return _dbset.Where(wherePredict).ToList();
        }

        public IEnumerable<tbl_Entity> Getproduct()
        {
            return _dbset.ToList();
        }



        public IEnumerable<tbl_Entity> GetResultBySqlprocedure(string query, params object[] parameters)
        {
            if(parameters != null)
            {
                return _dbentity.Database.SqlQuery<tbl_Entity>(query, parameters).ToList();
            }
            else
                return _dbentity.Database.SqlQuery<tbl_Entity>(query).ToList();
        }

        public IEnumerable<tbl_Entity> GetRrcodToShow(int PageNo, int PageSize, int currentPage, Expression<Func<tbl_Entity, bool>> wherePredict, Expression<Func<tbl_Entity, bool>> orderByPredict)
        {
            if(wherePredict != null)
            {
                return _dbset.OrderBy(orderByPredict).Where(wherePredict).ToList();
            }
            else
                return _dbset.OrderBy(orderByPredict).ToList();
        }

        public IEnumerable<tbl_Entity> Gettbl_Entitys()
        {
            return _dbset.ToList();
        }

        public void InactiveAndDeleteMarkByWhereClause(Expression<Func<tbl_Entity, bool>> wherePredict, Action<tbl_Entity> ForEachPredict)
        {
            _dbset.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }

        public void Remove(tbl_Entity DB)
        {
            if(_dbentity.Entry(DB).State == EntityState.Detached)
            {
                _dbset.Attach(DB);
                _dbset.Remove(DB);
            }
        }

        public void RemoveByWhereClause(Expression<Func<tbl_Entity, bool>> wherePredict)
        {
            tbl_Entity DB = _dbset.Where(wherePredict).FirstOrDefault();
            Remove(DB);
        }

        public void RemoveRangByWhereClause(Expression<Func<tbl_Entity, bool>> wherePredict)
        {
            List<tbl_Entity> DB = _dbset.Where(wherePredict).ToList();
            foreach(var ent in DB)
            {
                Remove(ent);
            }
        }

        public void Update(tbl_Entity DB)
        {
            _dbset.Attach(DB);
            _dbentity.Entry(DB).State = EntityState.Modified;
            _dbentity.SaveChanges();
        }

        public void UpdateByWhereClause(Expression<Func<tbl_Entity, bool>> wherePredict, Action<tbl_Entity> ForEachPredict)
        {
            _dbset.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }
    }
}