using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biblioteca_rest_service.Models;
using System.Linq.Expressions;

namespace biblioteca_rest_service.Dal
{
    interface ICatalogoRepository
    {
        IQueryable<t_catalogo> GetAll();
        t_catalogo GetSingle(int id);
        IQueryable<t_catalogo> FindBy(Expression<Func<t_catalogo, bool>> predicate);
        void Add(t_catalogo entity);
        void Delete(t_catalogo entity);
        void Edit(t_catalogo entity);
        void Save();
    }
}
