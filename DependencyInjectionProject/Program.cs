﻿using Autofac;
using System;
using DependencyInjectionProject.Utilities;

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
                var application = scope.Resolve<IApplication>();
                application.Run();
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}