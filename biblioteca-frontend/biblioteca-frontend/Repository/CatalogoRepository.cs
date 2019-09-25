using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using biblioteca_frontend.Models;
using RestSharp;

namespace biblioteca_frontend.Repository
{
    public class CatalogoRepository : ICatalogoRepository
    {
        private static string baseEndPoint = System.Configuration.ConfigurationManager.AppSettings["baseEndPoint"];//captura url del servicio
        private RestClient client = new RestClient(baseEndPoint);

        public IEnumerable<Catalogo> GetAll()
        {
            RestRequest request = new RestRequest("catalogos", Method.GET);
            IRestResponse<List<Catalogo>> response = client.Execute<List<Catalogo>>(request);
            return response.Data;
        }

        public Catalogo GetSigle(int id)
        {
            RestRequest request = new RestRequest($"catalogos/{id}", Method.GET);
            IRestResponse<Catalogo> response = client.Execute<Catalogo>(request);
            return response.Data;
        }

        public IEnumerable<Catalogo> Search(string name)
        {
            RestRequest request = new RestRequest($"catalogos?name={name}", Method.GET);
            IRestResponse<List<Catalogo>> response = client.Execute<List<Catalogo>>(request);
            return response.Data;
        }
    }
}