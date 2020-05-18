﻿using Autofac;
using DependencyInjectionProject.Database;
using DependencyInjectionProject.UI;
using DependencyInjectionProject.Utilities;

namespace DependencyInjectionProject
{
    internal class ProgramModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TreeService>().AsSelf();
            builder.RegisterType<ImageService>().AsSelf();
            builder.RegisterType<DatabaseHandler>().AsSelf();
            builder.RegisterType<MenuCore>().AsSelf();
            builder.RegisterType<ConsoleNotificationService>().As<INotificationService>();
            builder.RegisterType<SQLiteDatabaseModeler>().As<IDatabaseModeler>();
            builder.RegisterType<SQLiteDatabase>().As<IDatabase>();
        }
    }
}
