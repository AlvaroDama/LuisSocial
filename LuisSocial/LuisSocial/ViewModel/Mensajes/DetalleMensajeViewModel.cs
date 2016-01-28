using ContactosModel.Model;
using LuisSocial.Service;
using MvvmLibrary.Factorias;

namespace LuisSocial.ViewModel.Mensajes
{
    public class DetalleMensajeViewModel:GeneralViewModel
    {
        private MensajeModel _mensaje;
        public MensajeModel Mensaje
        {
            get { return _mensaje; }
            set { SetProperty(ref _mensaje, value); }
        }

        public DetalleMensajeViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
        }

        
    }
}