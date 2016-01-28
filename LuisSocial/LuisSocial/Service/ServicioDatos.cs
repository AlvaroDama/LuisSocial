using System.Collections.Generic;
using System.Threading.Tasks;
using ContactosModel.Model;
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

        #region Usuario

        public async Task<UsuarioModel> ValidarUsuario(UsuarioModel user)
        {
            var request = new RestRequest {Resource = "Usuario", Method = Method.GET};

            request.AddQueryParameter("Login", user.Login);
            request.AddQueryParameter("Password", user.Password);

            var response = await _client.Execute<UsuarioModel>(request);

            return response.IsSuccess ? response.Data : null;
        }

        public async Task<bool> IsUsuarioNuevo(string login)
        {
            var request = new RestRequest {Resource = "Usuario", Method = Method.GET};

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

        #endregion


        #region Contactos

        public async Task<List<ContactoModel>> GetContactos(bool actuales, int id)
        {
            var request = new RestRequest {Resource = "Contactos", Method = Method.GET};

            request.AddQueryParameter("Id", id);
            request.AddQueryParameter("Amigos", actuales);

            var response = await _client.Execute<List<ContactoModel>>(request);

            return response.IsSuccess ? response.Data : null;
        }

        public async Task<ContactoModel> AddContacto(ContactoModel contacto)
        {
            var request = new RestRequest {Resource = "Contacto", Method = Method.POST};

            request.AddJsonBody(contacto);

            var res = await _client.Execute<ContactoModel>(request);

            return res.IsSuccess ? res.Data : null;
        }

        public async Task DeleteContacto(ContactoModel contacto)
        {
            var request = new RestRequest {Resource = "Contacto", Method = Method.DELETE};

            request.AddJsonBody(contacto);

            await _client.Execute(request);
        }

        #endregion


        #region Mensajes

        public async Task<List<MensajeModel>> GetMensajes(int id)
        {
            var request = new RestRequest {Resource = "Mensaje", Method = Method.GET};

            request.AddQueryParameter("Id", id);

            var response = await _client.Execute<List<MensajeModel>>(request);

            return response.IsSuccess ? response.Data : null;
        }

        public async Task<MensajeModel> AddMensaje(MensajeModel mensaje)
        {
            var request = new RestRequest {Resource = "Mensaje", Method = Method.POST};

            request.AddJsonBody(mensaje);

            var res = await _client.Execute<MensajeModel>(request);

            return res.IsSuccess ? res.Data : null;
        }

        public async Task UpdateMensaje(MensajeModel mensaje)
        {
            var request = new RestRequest {Resource = "Mensaje", Method = Method.PUT};

            request.AddJsonBody(mensaje);

            await _client.Execute(request);
        }

        #endregion
        
    }
}