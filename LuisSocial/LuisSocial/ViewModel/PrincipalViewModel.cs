using System.Collections.ObjectModel;
using System.Windows.Input;
using ContactosModel.Model;
using LuisSocial.Service;
using LuisSocial.Util;
using LuisSocial.ViewModel.Contactos;
using LuisSocial.ViewModel.Mensajes;
using MvvmLibrary.Factorias;
using Xamarin.Forms;

namespace LuisSocial.ViewModel
{
    public class PrincipalViewModel : GeneralViewModel
    {
        public ICommand CmdContactos { get; set; }
        public ICommand CmdMensajes { get; set; }
        public PrincipalViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
            CmdContactos = new Command(RunContactos);
            CmdMensajes = new Command(RunMensajes);
        }

        private async void RunMensajes()
        {
            IsBusy = true;
            var yo = Cadenas.Session["usuario"] as UsuarioModel;

            var data = await _servicio.GetMensajes(yo.Id);
            await _navigator.PushAsync<MisMensajesViewModel>(viewModel =>
            {
                viewModel.Titulo = "Recibidos";
                viewModel.Mensajes = new ObservableCollection<MensajeModel>(data);
            });

        }

        private async void RunContactos()
        {
            IsBusy = true;
            var yo = Cadenas.Session["usuario"] as UsuarioModel;

            var amigos = await _servicio.GetContactos(true, yo.Id);
            var noamigos = await _servicio.GetContactos(false, yo.Id);
            await _navigator.PushAsync<ContactosViewModel>(viewModel =>
            {
                viewModel.Titulo = "Mis contactos";
                viewModel.Amigos = new ObservableCollection<ContactoModel>(amigos);
                viewModel.NoAmigos = new ObservableCollection<ContactoModel>(noamigos);
            });
        }
    }
}