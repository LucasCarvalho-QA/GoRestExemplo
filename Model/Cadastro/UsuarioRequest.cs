using System;
using System.Collections.Generic;
using System.Text;

namespace GoRestExemplo.Model.Cadastro
{
    public class UsuarioRequest
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string status { get; set; }

        public UsuarioRequest ManterUsuario()
        {
            Random rdn = new Random();

            UsuarioRequest request = new UsuarioRequest
            {
                name = "Joaozinho",
                gender = "male",
                email = $"joazinho{rdn.Next(20, 1000)}@gmail.com",
                status = "active"
            };

            return request;
        }
    }

}
