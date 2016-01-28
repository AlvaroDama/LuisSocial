using System.Collections.Generic;
using System.Threading.Tasks;
using ContactosModel.Model;

namespace LuisSocial.Service
{
    public interface IServicioMovil
    {
        #region Usuario

        Task<UsuarioModel> ValidarUsuario(UsuarioModel user);
        Task<bool> IsUsuarioNuevo(string login);
        Task<UsuarioModel> AddUsuario(UsuarioModel user);

        #endregion


        #region Contacto

        Task<List<ContactoModel>> GetContactos(bool actuales, int id);
        Task<ContactoModel> AddContacto(ContactoModel contacto);
        Task DeleteContacto(ContactoModel contacto);

        #endregion


        #region Mensaje

        Task<List<MensajeModel>> GetMensajes(int id);
        Task<MensajeModel> AddMensaje(MensajeModel mensaje);
        Task UpdateMensaje(MensajeModel mensaje);

        #endregion

    }
}