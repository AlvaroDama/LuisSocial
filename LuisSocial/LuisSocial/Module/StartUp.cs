using Autofac;
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
    public class StartUp:AutofacBootstrapper
    {
        private readonly App _app;

        public StartUp(App app)
        {
            _app = app;
        }

        public override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<LuisSocialModule>();
        }

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            #region General

            viewFactory.Register<LoginViewModel, Login>();

            viewFactory.Register<RegistroViewModel, Registro>();

            viewFactory.Register<PrincipalViewModel, Principal>();

            #endregion


            #region Contactos

            viewFactory.Register<AddContactoViewModel, AddContacto>();

            viewFactory.Register<ContactosViewModel, Contactos>();

            viewFactory.Register<EnviarMensajeViewModel, EnviarMensaje>();

            #endregion


            #region Mensajes

            viewFactory.Register<DetalleMensajeViewModel, DetalleMensaje>();

            viewFactory.Register<MisMensajesViewModel, MisMensajes>();

            #endregion

        }

        protected override void ConfigureApplication(IContainer container)
        {
            var viewFactory = container.Resolve<IViewFactory>();
            var main = viewFactory.Resolve<LoginViewModel>();
            var navPage = new NavigationPage(main); //pone la barra de navegación
            _app.MainPage = navPage;
        }
    }
}
