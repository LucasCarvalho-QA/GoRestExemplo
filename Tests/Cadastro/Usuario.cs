using GoRestExemplo.Model.Cadastro;
using GoRestExemplo.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GoRestExemplo.Tests.Cadastro
{
    [TestFixture]
    public class Usuario : Setup
    {
        UsuarioRequest bodyRequest = new UsuarioRequest();
        UsuarioResponse response = new UsuarioResponse();

        string path = "/public/v1/users";
        string bearerToken = "4c97e60b3df0585dec6c0c67b40167544635f7e6e796ddadea302f2ff3ea2c44";


        [TestCase]
        public void CadastrarUsuario()
        {
            //Arrange
            var localBodyRequest = bodyRequest.ManterUsuario();

            //Act  
            RestClient client = new RestClient("https://gorest.co.in/");
            client.Authenticator = new JwtAuthenticator(bearerToken);

            RestRequest clientRequest = new RestRequest(path, Method.POST);
            clientRequest.AddJsonBody(localBodyRequest);
            clientRequest.AddHeader("Content-Type", "application/json;charset=UTF-8");
            clientRequest.AddHeader("Accept", "application/json");
            clientRequest.AddHeader("Authorization", "Bearer");

            var localResponse = client.Execute(clientRequest);

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, localResponse.StatusCode);
        }

        [TestCase]
        public void CadastrarUsuario_Runner()
        {
            //Arrange
            var localBodyRequest = bodyRequest.ManterUsuario();

            //Act
            var localResponse = Runner.ExecuteRestCall(Method.POST, path, localBodyRequest);

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, localResponse.StatusCode);
        }

        [TestCase]
        public void CadastrarUsuario_ValidandoDinamicamente()
        {
            //Arrange
            var localBodyRequest = bodyRequest.ManterUsuario();

            //Act
            var localResponse = Runner.ExecuteRestCall(Method.POST, path, localBodyRequest);
            var objetoRecebido = JsonConvert.DeserializeObject<UsuarioResponse>(localResponse.Content);

            //Assert
            var objetoEsperado = response.RetornarObjetoEsperado(localBodyRequest);
            objetoEsperado.data.id = objetoRecebido.data.id;
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(objetoEsperado.data.name, objetoRecebido.data.name);
                Assert.AreEqual(objetoEsperado.data.gender, objetoRecebido.data.gender);
                Assert.AreEqual(objetoEsperado.data.status, objetoRecebido.data.status);
                Assert.AreEqual(objetoEsperado.data.email, objetoRecebido.data.email);
            });
        }

        [TestCase]
        public void ConsultarUsuario()
        {
            //Arrange
            string userId = "2072";
            path = $"{path}/{userId}";

            //Act
            var localResponse = Runner.ExecuteRestCall(Method.GET, path);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, localResponse.StatusCode);                
            });
        }
    }
}
