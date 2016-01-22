using LuisSocial.Service;
using MvvmLibrary.Factorias;
using MvvmLibrary.ViewModel.Base;

namespace LuisSocial.ViewModel
{
    public class ContactosViewModel:GeneralViewModel
    {
        public ContactosViewModel(INavigator navigator, IServicioMovil servicio) : base(navigator, servicio)
        {
        }
    }
}