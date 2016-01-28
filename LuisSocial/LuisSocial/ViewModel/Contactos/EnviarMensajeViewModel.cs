using System;
using System.Windows.Input;
using ContactosModel.Model;
using LuisSocial.Service;
using MvvmLibrary.Factorias;
using Xamarin.Forms;

namespace LuisSocial.ViewModel.Contactos
{
    public class EnviarMensajeViewModel : GeneralViewModel
    {
        private ContactoModel _contacto;
        private MensajeModel _mensaje;
        public ContactoModel Contacto
        {
            get { return _contacto; }
            set
            {
                SetProperty(ref _contacto, value);
            }
        }

        public MensajeModel Mensaje
        {
            get { return _mensaje; }
            set
            {
                SetProperty(ref _mensaje, value);
            }
        }

        public ICommand CmdEnviar { get; set; }

        public EnviarMensajeViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
            CmdEnviar = new Command(RunEnviarMensaje);
        }

        private async void RunEnviarMensaje()
        {
            try
            {
                IsBusy = true;
                Mensaje.IdOrigen = Contacto.IdOrigen;
                Mensaje.Fecha = DateTime.Now;
                Mensaje.IdDestino = Contacto.IdDestino;
                Mensaje.Leido = false;
                var r = await _servicio.AddMensaje(Mensaje);
                if (r != null)
                {
                    //TODO: Meter el dialogo
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}