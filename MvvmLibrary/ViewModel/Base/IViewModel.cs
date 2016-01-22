using System;
using System.ComponentModel;

namespace MvvmLibrary.ViewModel.Base
{
    //el chivato de los cambios en los bindings. Sin esta interfaz, no funcionaría el <<TwoWaysBinding>>
    public interface IViewModel:INotifyPropertyChanged
    {
        string Titulo { get; set; }

        void SetState<T>(Action<T> action) where T : class, IViewModel;

    }
}
