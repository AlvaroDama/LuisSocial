using System;
using Autofac;
using LuisSocial.Service;
using LuisSocial.View;
using LuisSocial.ViewModel;
using MvvmLibrary.Module.Base;
using Xamarin.Forms;

namespace LuisSocial.Module
{
    public class LuisSocialModule:AutofacModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.Register<INavigation>(ctx => App.Current.MainPage.Navigation).SingleInstance();

            builder.RegisterType<ServicioDatos>().As<IServicioMovil>().SingleInstance();

            builder.RegisterType<Login>();
            builder.RegisterType<LoginViewModel>();

            builder.RegisterType<Contactos>();
            builder.RegisterType<ContactosViewModel>();

            builder.RegisterType<Registro>();
            builder.RegisterType<RegistroViewModel>();

            builder.RegisterInstance<Func<Page>>(() =>
            {
                var masterP = Application.Current.MainPage as MasterDetailPage;
                var page = masterP != null ? masterP.Detail : Application.Current.MainPage;

                var navigation = page as IPageContainer<Page>;

                return navigation != null ? navigation.CurrentPage : page;
            });
        }
    }
}