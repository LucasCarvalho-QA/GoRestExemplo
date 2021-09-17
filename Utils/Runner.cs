using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoRestExemplo.Utils
{
    public class Runner
    {
        public static string bearerToken = "4c97e60b3df0585dec6c0c67b40167544635f7e6e796ddadea302f2ff3ea2c44";

        public static IRestResponse ExecuteRestCall(Method method, string path, object body = null, Dictionary<string, string> customHeader = null)
        {
            RestClient client = new RestClient("https://gorest.co.in/")
            {
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };
            RestRequest request = new RestRequest($"{path}", method);

            if (customHeader != null)
                request.AddHeaders(customHeader);
            else
                request.AddHeaders(GetDefaultHeader());

            if (body != null)
                request.AddJsonBody(body);

            if (bearerToken != null)
                client.Authenticator = new JwtAuthenticator(bearerToken);

            var response = client.Execute(request);

            return response;
        }

        public static Dictionary<string, string> GetDefaultHeader()
        {
            Dictionary<string, string> defaultHeader = new Dictionary<string, string>()
            {
                {"Content-Type","application/json;charset=UTF-8"},
                {"Accept","application/json;charset=UTF-8"},
                {"Authorization","Bearer"}
            };
            return defaultHeader;
        }
    }
}
