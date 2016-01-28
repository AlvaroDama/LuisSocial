using System;
using Autofac;
using LuisSocial.Service;
using LuisSocial.View;
using LuisSocial.View.Contactos;
using LuisSocial.View.Mensajes;
using LuisSocial.ViewModel;
using LuisSocial.ViewModel.Contactos;
using LuisSocial.ViewModel.Mensajes;
using MvvmLibrary.Factorias;
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
            builder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
            builder.RegisterType<PageProxy>().As<IPage>().SingleInstance();

            #region General

            builder.RegisterType<Login>();
            builder.RegisterType<LoginViewModel>();

            builder.RegisterType<Registro>();
            builder.RegisterType<RegistroViewModel>();

            builder.RegisterType<Principal>();
            builder.RegisterType<PrincipalViewModel>();

            #endregion


            #region Contactos

            builder.RegisterType<AddContacto>();
            builder.RegisterType<AddContactoViewModel>();

            builder.RegisterType<Contactos>();
            builder.RegisterType<ContactosViewModel>();

            builder.RegisterType<EnviarMensaje>();
            builder.RegisterType<EnviarMensajeViewModel>();

            #endregion


            #region Mensajes

            builder.RegisterType<DetalleMensaje>();
            builder.RegisterType<DetalleMensajeViewModel>();

            builder.RegisterType<MisMensajes>();
            builder.RegisterType<MisMensajesViewModel>();

            #endregion


            //ToDo: Registrar nuevas tuplas <View, ViewModel>

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