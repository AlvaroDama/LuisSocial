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
    public class RegistroViewModel:GeneralViewModel
    {
        private UsuarioModel _usuario;
        public UsuarioModel Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario , value); }
        }

        public ICommand CmdAlta { get; set; }

        public RegistroViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
            _usuario = new UsuarioModel();
            CmdAlta = new Command(RunAlta);
        }

        private async void RunAlta()
        {
            Usuario.Foto = "";
            try
            {
                IsBusy = true;
                if (await _servicio.IsUsuarioNuevo(Usuario.Login))
                {
                    var res = await _servicio.AddUsuario(Usuario);

                    if (res != null)
                    {
                        Cadenas.Session["usuario"] = res;
                        await _navigator.PushAsync<ContactosViewModel>
                            (viewModel => { viewModel.Titulo = "Mis contactos"; });
                    }
                    else
                        await _page.MostrarAlerta("Error", "No se puedo dar de alta", "OK");

                }

            }
            catch (Exception e)
            {
                await _page.MostrarAlerta("Error", e.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}