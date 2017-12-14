using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClienteEnlaza
{
    class ServicioDeDatoscs
    {
        static HttpClient client = new HttpClient();

        public async static Task<Usuario> GetUsuarioAsync(string nombre, string pass)
        {
            var response = await client.GetStringAsync("http://192.168.202.66:8084/API-HM2/webresources/usuario/logeado/"+nombre+"/"+pass);
            var usuario = JsonConvert.DeserializeObject<Usuario>(response);
            return usuario;
        }
    }
}
