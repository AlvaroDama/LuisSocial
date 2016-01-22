using Autofac;
using MvvmLibrary.Factorias;
using Xamarin.Forms;

namespace MvvmLibrary.Module
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance(); //singleton

            builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();

            builder.Register(ctx => Application.Current.MainPage.Navigation).SingleInstance();
        }
    }
}
