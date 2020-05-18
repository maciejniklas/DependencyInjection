using Autofac;
using DependencyInjectionProject.UI;

namespace DependencyInjectionProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<ProgramModule>();

            var container = containerBuilder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var application = scope.Resolve<MenuCore>();
            }
        }
    }
}
