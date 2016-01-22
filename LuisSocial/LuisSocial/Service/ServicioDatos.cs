using System.Threading.Tasks;
using ContactoModel.Model;
using LuisSocial.Util;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace LuisSocial.Service
{
    public class ServicioDatos : IServicioMovil
    {
        private RestClient _client;

        public ServicioDatos()
        {
            _client = new RestClient(Cadenas.Url);
        }

        public async Task<UsuarioModel> ValidarUsuario(UsuarioModel user)
        {
            var request = new RestRequest { Resource = "Usuario", Method = Method.GET };

            request.AddQueryParameter("Login", user.Login);
            request.AddQueryParameter("Password", user.Password);

            var response = await _client.Execute<UsuarioModel>(request);

            return response.IsSuccess ? response.Data : null;
        }

        public async Task<bool> IsUsuarioNuevo(string login)
        {
            var request = new RestRequest { Resource = "Usuario", Method = Method.GET };

            request.AddQueryParameter("Login", login);

            var response = await _client.Execute<bool>(request);

            return response.IsSuccess && response.Data;
        }

        public async Task<UsuarioModel> AddUsuario(UsuarioModel user)
        {
            var request = new RestRequest {Resource = "Usuario", Method = Method.POST};

            request.AddJsonBody(user);

            var res = await _client.Execute<UsuarioModel>(request);

            return res.IsSuccess ? res.Data : null;
        }
    }
}