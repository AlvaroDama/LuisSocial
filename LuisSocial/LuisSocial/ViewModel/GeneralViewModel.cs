using LuisSocial.Service;
using MvvmLibrary.Factorias;
using MvvmLibrary.ViewModel.Base;

namespace LuisSocial.ViewModel
{
    public class GeneralViewModel:ViewModelBase
    {
        protected INavigator _navigator;
        protected IServicioMovil _servicio;

        public GeneralViewModel(INavigator navigator, IServicioMovil servicio)
        {
            _servicio = servicio;
            _navigator = navigator;
        }
    }
}
