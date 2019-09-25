using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biblioteca_frontend.Models;

namespace biblioteca_frontend.Repository
{
    interface ILectorRepository
    {
        //IEnumerable<Catalogo> GetAll();
        //IEnumerable<Catalogo> Search(string name);
        //Catalogo GetSigle(int id);
        Lector Create(Lector lector);
        Lector Login(Login user);
        //void Update(int id, Product product);
        //void Delete(int id);
    }
}
