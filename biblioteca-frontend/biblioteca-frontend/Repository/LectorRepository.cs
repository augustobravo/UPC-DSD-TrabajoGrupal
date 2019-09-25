using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using biblioteca_frontend.Models;
using RestSharp;

namespace biblioteca_frontend.Repository
{
    public class LectorRepository : ILectorRepository
    {
        private static string baseEndPoint = System.Configuration.ConfigurationManager.AppSettings["baseEndPoint"];
        private RestClient client = new RestClient(baseEndPoint);

        public Lector Create(Lector lector)
        {
            RestRequest request = new RestRequest("/lectores", Method.POST);
            request.AddJsonBody(lector);
            IRestResponse<Lector> response = client.Execute<Lector>(request);
            return response.Data;
        }

        public Lector Login(Login user)
        {
            try
            {
                RestRequest request = new RestRequest("/authenticate", Method.POST);
                request.AddJsonBody(user);
                IRestResponse<Lector> response = client.Execute<Lector>(request);
                return response.Data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}