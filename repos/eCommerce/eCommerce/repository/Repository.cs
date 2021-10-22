using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Linq;

namespace eCommerce.repository
{
    public interface IRepository<tbl_Entity>where tbl_Entity:class
    {
        IEnumerable<tbl_Entity> Getproduct();
      
        IEnumerable<tbl_Entity> Gettbl_Entitys();
        IQueryable<tbl_Entity> GetAllRecodsIQuryable();
        int GetAllRecodeCount();
        void Add(tbl_Entity DB);
        void Update(tbl_Entity DB);
        void UpdateByWhereClause(Expression<Func<tbl_Entity, bool>> wherePredict, Action<tbl_Entity> ForEachPredict);
        tbl_Entity GetFirstOrDeafault(int recodeId);
        void Remove(tbl_Entity DB);
        void RemoveByWhereClause(Expression<Func<tbl_Entity, bool>> wherePredict);
        void RemoveRangByWhereClause(Expression<Func<tbl_Entity, bool>> wherePredict);
        void InactiveAndDeleteMarkByWhereClause(Expression<Func<tbl_Entity, bool>> wherePredict, Action<tbl_Entity> ForEachPredict);
        tbl_Entity GetFirstOrDeafaultByParameter(Expression<Func<tbl_Entity, bool>> wherePredict);
        IEnumerable<tbl_Entity>GetListParameter(Expression<Func<tbl_Entity, bool>> wherePredict);
        IEnumerable<tbl_Entity> GetResultBySqlprocedure(string query, params object[] parameters);
        IEnumerable<tbl_Entity> GetRrcodToShow(int PageNo, int PageSize, int currentPage, Expression<Func<tbl_Entity, bool>> wherePredict, Expression<Func<tbl_Entity, bool>> orderByPredict);
    }
}