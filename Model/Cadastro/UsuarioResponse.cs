using System;
using System.Collections.Generic;
using System.Text;

namespace GoRestExemplo.Model.Cadastro
{
    public class UsuarioResponse
    {
        public object meta { get; set; }
        public Data data { get; set; }

        public UsuarioResponse RetornarObjetoEsperado(UsuarioRequest request)
        {
            UsuarioResponse response = new UsuarioResponse
            {
                meta = null,
                data = new Data
                {
                    email = request.email,
                    name = request.name,
                    gender = request.gender,
                    status = request.status
                }
            };
            return response;
        }
    }

    public class Data
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string status { get; set; }
    }
    
}
