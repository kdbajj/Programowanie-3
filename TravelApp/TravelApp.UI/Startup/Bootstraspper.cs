using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DataAccess;
using TravelApp.UI.Data;
using TravelApp.UI.ViewModel;

namespace TravelApp.UI.Startup
{
    public class Bootstraspper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<TravelAppDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<DetailsWindow>().AsSelf();
            
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<DetailsViewModel>().AsSelf();

            builder.RegisterType<TravelAppDataService>().As<ITravelAppDataService>();


            return builder.Build();

        }
    }
}
