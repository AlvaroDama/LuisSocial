using System.Collections.ObjectModel;
using System.Windows.Input;
using ContactosModel.Model;
using LuisSocial.Service;
using MvvmLibrary.Factorias;
using Xamarin.Forms;

namespace LuisSocial.ViewModel.Contactos
{
    public class ContactosViewModel : GeneralViewModel
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

        private ContactoModel _contactoSeleccionado;
        public ContactoModel ContactoSeleccionado
        {
            get { return _contactoSeleccionado; }
            set
            {
                if (value != null) RunAddMensaje();
                SetProperty(ref _contactoSeleccionado, value);
            }
        }

        public ICommand CmdNuevo { get; set; }

        public ContactosViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
            CmdNuevo = new Command(RunNuevoContacto);
        }

        private async void RunNuevoContacto()
        {
            await _navigator.PushAsync<AddContactoViewModel>(viewModel =>
            {
                viewModel.Amigos = Amigos;
                viewModel.NoAmigos = NoAmigos;
            });
        }
        private async void RunAddMensaje()
        {
            await _navigator.PushAsync<EnviarMensajeViewModel>(viewModel =>
            {
                viewModel.Contacto = ContactoSeleccionado;
                viewModel.Mensaje = new MensajeModel();
            });
        }

    }
}