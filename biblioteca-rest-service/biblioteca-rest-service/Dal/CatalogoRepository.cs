using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using biblioteca_rest_service.Models;

namespace biblioteca_rest_service.Dal
{
    public class CatalogoRepository : GenericRepository<BibliotecaEntities, t_catalogo>, ICatalogoRepository
    {
        public t_catalogo GetSingle(int id)
        {
            return GetAll().FirstOrDefault(x => x.id_articulo == id);
        }
    }
}