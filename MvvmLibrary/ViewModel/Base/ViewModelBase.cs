using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmLibrary.ViewModel.Base
{
    public class ViewModelBase:IViewModel
    {

        private bool _isBusy;
        private double _opacity;
        private bool _enabled;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Titulo { get; set; }

        public ViewModelBase()
        {
            IsBusy = false;
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                Opacity = value ? 0.5 : 1;
                Enabled = !value;
                SetProperty(ref _isBusy, value);
            }
        }

        public double Opacity
        {
            get { return _opacity; }
            set { SetProperty(ref _opacity, value); } //nombre == Opacity (llamador de la función)
        }

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                SetProperty(ref _enabled, value);
            }
        }

        protected virtual bool SetProperty<T>(ref T variable,
            T valor, [CallerMemberName] string nombre = null) //coge al "llamador" de la función
        {
            if (object.Equals(variable, valor))
                return false;

            variable = valor;
            OnPropertyChanged(nombre);
            return true;
        }

        //se llama cuando hemos setteado la propiedad
        private void OnPropertyChanged([CallerMemberName] string nombre = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(nombre));
            }
        }

        public void SetState<T>(Action<T> action) where T : class, IViewModel
        {
            if (action != null)
                action(this as T);
            
        }
    }
}
