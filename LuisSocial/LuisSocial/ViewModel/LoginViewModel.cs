using System;
using System.Windows.Input;
using ContactoModel.Model;
using LuisSocial.Service;
using MvvmLibrary.Factorias;
using Xamarin.Forms;

namespace LuisSocial.ViewModel
{
    public class LoginViewModel:GeneralViewModel
    {

        private UsuarioModel _usuario;

        public ICommand CmdLogin { get; set; }
        public ICommand CmdAlta { get; set; }

        public UsuarioModel Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        public LoginViewModel(INavigator navigator, IServicioMovil servicio) : base(navigator, servicio)
        {
            _usuario = new UsuarioModel();
            CmdLogin = new Command(RunLogin);
            CmdAlta = new Command(RunRegistro);
        }

        private async void RunLogin()
        {
            try
            {
                IsBusy = true;
                var us = await _servicio.ValidarUsuario(Usuario);

                if (us != null)
                    await _navigator.PushAsync<ContactosViewModel>(viewModel => { Titulo = "Mis contactos"; });
                else
                {
                    var page = new Page();
                    await page.DisplayAlert("Error", "No se puede acceder", "Aceptar");
                }
                
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("Error", e.Message, "OK");
            }
            finally
            {
                
                IsBusy = false;
            }
        }

        private async void RunRegistro()
        {
            await _navigator.PushAsync<RegistroViewModel>(viewModel => { Titulo = "Alta usuario"; });
        }
        
    }
}