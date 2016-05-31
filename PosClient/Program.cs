using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PosClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            WebRequestHandler handler = new WebRequestHandler();
            X509Certificate2 certificate = GetCertificate();
            handler.ClientCertificates.Add(certificate);
            HttpClient client = new HttpClient(handler);

            var response = client.GetStringAsync("https://payments.cl.coop.dk/test1").Result;

        }

        private static X509Certificate2 GetCertificate()
        {
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            var certCollection = store.Certificates.Find(
                X509FindType.FindByThumbprint,
                "EBE1A8650F6745A18BC7DE8876AD83994E7C08F5",
                false);
            store.Close();

            return certCollection[0];
        }
    }
}
