using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using LuisSocial.View;
using LuisSocial.ViewModel;
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
            viewFactory.Register<LoginViewModel, Login>();
            viewFactory.Register<ContactosViewModel, Contactos>();
            viewFactory.Register<RegistroViewModel, Registro>();
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
