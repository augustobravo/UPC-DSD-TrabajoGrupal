using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biblioteca_rest_service.Models;
using System.Linq.Expressions;

namespace biblioteca_rest_service.Dal
{
    interface ILectorRepository
    {
        IQueryable<t_lector> GetAll();
        t_lector GetSingle(int id);
        IQueryable<t_lector> FindBy(Expression<Func<t_lector, bool>> predicate);
        void Add(t_lector entity);
        void Delete(t_lector entity);
        void Edit(t_lector entity);
        void Save();
    }
}
