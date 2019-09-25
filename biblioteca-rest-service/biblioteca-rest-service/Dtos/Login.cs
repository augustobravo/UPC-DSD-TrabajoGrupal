using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace biblioteca_rest_service.Dtos
{
    public class Login
    {
        public string email {get; set; }
        public string contrasena { get; set; }
    }
}