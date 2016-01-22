using System.Threading.Tasks;
using ContactoModel.Model;

namespace LuisSocial.Service
{
    public interface IServicioMovil
    {
        Task<UsuarioModel> ValidarUsuario(UsuarioModel user);
        Task<bool> IsUsuarioNuevo(string login);
        Task<UsuarioModel> AddUsuario(UsuarioModel user);
    }
}