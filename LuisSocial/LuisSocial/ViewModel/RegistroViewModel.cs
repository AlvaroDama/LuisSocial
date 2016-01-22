using System;
using System.Windows.Input;
using ContactoModel.Model;
using LuisSocial.Service;
using MvvmLibrary.Factorias;
using Xamarin.Forms;

namespace LuisSocial.ViewModel
{
    public class RegistroViewModel:GeneralViewModel
    {
        private UsuarioModel _usuario;
        public UsuarioModel Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario , value); }
        }

        public ICommand CmdAlta { get; set; }

        public RegistroViewModel(INavigator navigator, IServicioMovil servicio) : base(navigator, servicio)
        {
            _usuario = new UsuarioModel();
            CmdAlta = new Command(RunAlta);
        }

        private async void RunAlta()
        {
            try
            {
                IsBusy = true;
                if (await _servicio.IsUsuarioNuevo(Usuario.Login))
                {
                    var res = await _servicio.AddUsuario(Usuario);

                    if (res != null)
                        await _navigator.PushAsync<ContactosViewModel>
                            (viewModel => { Titulo = "Mis contactos"; });
                    else
                        await new Page().DisplayAlert("Error", "No se puedo dar de alta", "OK");
                    
                }

            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}