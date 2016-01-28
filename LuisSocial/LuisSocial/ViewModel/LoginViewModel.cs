using System;
using System.Windows.Input;
using ContactosModel.Model;
using LuisSocial.Service;
using LuisSocial.Util;
using LuisSocial.ViewModel.Contactos;
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

        public LoginViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
            base.Titulo = "Red Social";
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
                {
                    Cadenas.Session["usuario"] = us;
                    await _navigator.PushAsync<PrincipalViewModel>(viewModel =>
                    {
                        viewModel.Titulo = "Inicio";
                    });
                }
                else
                {
                    await _page.MostrarAlerta("Error", "No se puede acceder", "Aceptar");
                }

            }
            catch (Exception e)
            {
                await _page.MostrarAlerta("Error", e.Message, "Aceptar");
            }
            finally
            {
                
                IsBusy = false;
            }
        }

        private async void RunRegistro()
        {
            await _navigator.PushAsync<RegistroViewModel>(viewModel => { viewModel.Titulo = "Alta usuario"; });
        }
        
    }
}