using System.Collections.ObjectModel;
using ContactosModel.Model;
using LuisSocial.Service;
using MvvmLibrary.Factorias;

namespace LuisSocial.ViewModel.Mensajes
{
    public class MisMensajesViewModel:GeneralViewModel
    {


        private MensajeModel _mensajeSeleccionado;
        public MensajeModel MensajeSeleccionado
        {
            get { return _mensajeSeleccionado; }
            set
            {
                SetProperty(ref _mensajeSeleccionado, value);

                if (value!=null)
                    VerDetallesMensaje();
                
            }
        }

        public ObservableCollection<MensajeModel> Mensajes { get; set; }

        public MisMensajesViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
        }

        private async void VerDetallesMensaje()
        {
            if (!_mensajeSeleccionado.Leido)
            {
                _mensajeSeleccionado.Leido = true;
                await _servicio.UpdateMensaje(_mensajeSeleccionado);
            }

            await _navigator.PushAsync<DetalleMensajeViewModel>(viewModel =>
            {
                viewModel.Mensaje = _mensajeSeleccionado;
                viewModel.Titulo = _mensajeSeleccionado.Asunto;
            });

            MensajeSeleccionado = null;
        }
    }
}