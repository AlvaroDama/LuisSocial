using System.Collections.ObjectModel;
using System.Windows.Input;
using ContactosModel.Model;
using LuisSocial.Service;
using MvvmLibrary.Factorias;
using Xamarin.Forms;

namespace LuisSocial.ViewModel.Contactos
{
    public class AddContactoViewModel : GeneralViewModel
    {
        private ObservableCollection<ContactoModel> _amigos;
        public ObservableCollection<ContactoModel> Amigos
        {
            get { return _amigos; }
            set { SetProperty(ref _amigos, value); }
        }

        private ObservableCollection<ContactoModel> _noAmigos;
        public ObservableCollection<ContactoModel> NoAmigos
        {
            get { return _noAmigos; }
            set { SetProperty(ref _noAmigos, value); }
        }

        public ICommand CmdAdd { get; set; }

        public AddContactoViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
            CmdAdd = new Command(AddContacto);
        }

        private async void AddContacto()
        {
            //TODO
        }
    }
}