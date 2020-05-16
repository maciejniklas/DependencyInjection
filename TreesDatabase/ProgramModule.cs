using Autofac;
using TreesDatabase.Utilities;

namespace TreesDatabase
{
    class ProgramModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TreeService>().AsSelf();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<ConsoleNotification>().As<INotificationService>();
        }
    }
}
