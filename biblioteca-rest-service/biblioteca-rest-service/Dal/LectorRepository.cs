using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using biblioteca_rest_service.Models;

namespace biblioteca_rest_service.Dal
{
    public class LectorRepository : GenericRepository<BibliotecaEntities, t_lector>, ILectorRepository
    {
        public t_lector GetSingle(int id)
        {
            return GetAll().FirstOrDefault(x => x.id_lector == id);
        }
    }
}