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

        public static async Task<List<Vuelo>> getVuelosAsync(string Origen, string Destino) {
            var response = await client.GetStringAsync("http://192.168.202.66:8084/API-HM2/webresources/buscar/listar/"+Origen+"/"+Destino);
            var vuelos = JsonConvert.DeserializeObject<List<Vuelo>>(response);
            return vuelos;
        }

        public static async Task Reservar(Vuelo vuelo)
        {
            Usuario user = (Usuario)App.usuarioLogeado;
            var content = new StringContent("{ \"vuelo\": { \"id\":\"" + vuelo.Id + "\",\"precio\":\"" + vuelo.Precio + "\"}, \"usuario\": {\"id\":\"" + user.Id+"\"}}", Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://192.168.202.66:8084/API-HM2/webresources/reservar/reserva/", content);
        }

        public static async Task BorrarUsuario()
        {
            Usuario User = (Usuario) App.usuarioLogeado;
            var uri = new Uri("http://192.168.202.66:8084/API-HM2/webresources/usuario/borrar/" + User.Id);

            var response = await client.DeleteAsync(uri);

        }

        public static async Task cambiarContrasena(string pass)
        {
            Usuario user = (Usuario)App.usuarioLogeado;
            var uri = new Uri("http://192.168.202.66:8084/API-HM2/webresources/usuario/modificar/");
            var content = new StringContent("{\"id\":\""+user.Id+"\",\"nombre\":\""+user.Nombre+"\",\"FNacimiento\":\""+user.FNacimiento + "\",\"contrasena\":\"" + pass+"\"}", Encoding.UTF8, "application/json");
            var response = await client.PutAsync(uri, content);

        }
    }
}
