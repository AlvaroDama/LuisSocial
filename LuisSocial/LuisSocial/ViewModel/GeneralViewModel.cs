using LuisSocial.Service;
using MvvmLibrary.Factorias;
using MvvmLibrary.ViewModel.Base;

namespace LuisSocial.ViewModel
{
    public class GeneralViewModel:ViewModelBase
    {
        protected INavigator _navigator;
        protected IServicioMovil _servicio;
        protected IPage _page;

        public GeneralViewModel(INavigator navigator, IServicioMovil servicio, IPage page)
        {
            _servicio = servicio;
            _navigator = navigator;
            _page = page;
        }
    }
}
