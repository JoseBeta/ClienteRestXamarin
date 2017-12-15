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

        public async static Task<Usuario> GetUsuarioAsync(string Nombre, string Pass)
        {
            var response = await client.GetStringAsync("http://192.168.202.66:8084/API-HM2/webresources/usuario/logeado/"+Nombre+"/"+Pass);
            var usuario = JsonConvert.DeserializeObject<Usuario>(response);
            return usuario;
        }

        public async static Task<string> GetAuthAsync(string Nombre, string Pass)
        {
            var response = await client.GetStringAsync("http://192.168.202.66:8084/API-HM2/webresources/usuario/login/" + Nombre + "/" + Pass);
            return response;
        }

        public static async Task Registro(string Nombre, string Contrasena, string Fecha)
        {
            var content = new StringContent("{ \"nombre\": \""+Nombre+"\", \"contrasena\": \""+Contrasena+"\", \"FNacimiento\": \""+Fecha+"\"}", Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://192.168.202.66:8084/API-HM2/webresources/usuario/registro/", content);
        }
    }
}
